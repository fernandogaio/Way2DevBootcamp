using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Way2DevBootcamp.Application.Interfaces;
using Way2DevBootcamp.Application.ViewModels;
using Way2DevBootcamp.Identity.Configurations;

namespace Way2DevBootcamp.Identity.Services;
public class IdentityService : IIdentityService {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtOptions _jwtOptions;

    public IdentityService(SignInManager<IdentityUser> signInManager,
                           UserManager<IdentityUser> userManager,
                           IOptions<JwtOptions> jwtOptions) {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<UsuarioViewModelOutput> CadastrarUsuario(UsuarioViewModelInput usuarioCadastro) {
        var identityUser = new IdentityUser {
            UserName = usuarioCadastro.Email,
            Email = usuarioCadastro.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Senha);
        if (result.Succeeded)
            await _userManager.SetLockoutEnabledAsync(identityUser, false);

        var usuarioCadastroOutput = new UsuarioViewModelOutput(result.Succeeded);
        if (!result.Succeeded && result.Errors.Any())
            usuarioCadastroOutput.AdicionarErros(result.Errors.Select(r => r.Description));

        return usuarioCadastroOutput;
    }

    public async Task<UsuarioLoginViewModelOutput> Login(UsuarioLoginViewModelInput usuarioLogin) {
        var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
        if (result.Succeeded)
            return await GerarCredenciais(usuarioLogin.Email);

        var usuarioLoginOutput = new UsuarioLoginViewModelOutput();
        if (!result.Succeeded) {
            if (result.IsLockedOut)
                usuarioLoginOutput.AdicionarErro("Essa conta está bloqueada");
            else if (result.IsNotAllowed)
                usuarioLoginOutput.AdicionarErro("Essa conta não tem permissão para fazer login");
            else if (result.RequiresTwoFactor)
                usuarioLoginOutput.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
            else
                usuarioLoginOutput.AdicionarErro("Usuário ou senha estão incorretos");
        }

        return usuarioLoginOutput;
    }

    public async Task<UsuarioLoginViewModelOutput> LoginSemSenha(string usuarioId) {
        var usuarioLoginOutput = new UsuarioLoginViewModelOutput();
        var usuario = await _userManager.FindByIdAsync(usuarioId);

        if (await _userManager.IsLockedOutAsync(usuario))
            usuarioLoginOutput.AdicionarErro("Essa conta está bloqueada");
        else if (!await _userManager.IsEmailConfirmedAsync(usuario))
            usuarioLoginOutput.AdicionarErro("Essa conta precisa confirmar seu e-mail antes de realizar o login");

        if (usuarioLoginOutput.Sucesso)
            return await GerarCredenciais(usuario.Email);

        return usuarioLoginOutput;
    }

    private async Task<UsuarioLoginViewModelOutput> GerarCredenciais(string email) {
        var user = await _userManager.FindByEmailAsync(email);
        var accessTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: true);
        var refreshTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: false);

        var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
        var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

        var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
        var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

        return new UsuarioLoginViewModelOutput
        (
            sucesso: true,
            accessToken: accessToken,
            refreshToken: refreshToken
        );
    }

    private string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao) {
        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: dataExpiracao,
            signingCredentials: _jwtOptions.SigningCredentials);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private async Task<IList<Claim>> ObterClaims(IdentityUser user, bool adicionarClaimsUsuario) {
        var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
            };

        if (adicionarClaimsUsuario) {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);

            foreach (var role in roles)
                claims.Add(new Claim("role", role));
        }

        return claims;
    }
}