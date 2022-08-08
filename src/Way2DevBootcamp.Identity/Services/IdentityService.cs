using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Way2DevBootcamp.Identity.Configurations;
using Way2DevBootcamp.Identity.Enumerators;
using Way2DevBootcamp.Identity.Interfaces;
using Way2DevBootcamp.Identity.Results;

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

    public async Task<IdentityResult> AddUser(IdentityUser user, string password) {
        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
            await _userManager.SetLockoutEnabledAsync(user, false);

        return result;
    }

    public async Task<LoginResult> Login(string email, string password) {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, true);
        
        if (!result.Succeeded) {
            if (result.IsLockedOut)
                return new LoginResult(EnumLoginResultErrors.IsLockedOut);
            else if (result.IsNotAllowed)
                return new LoginResult(EnumLoginResultErrors.IsNotAllowed);
            else if (result.RequiresTwoFactor)
                return new LoginResult(EnumLoginResultErrors.RequiresTwoFactor);
            else
                return new LoginResult(EnumLoginResultErrors.InvalidCredentials);
        }

        return await GenerateCredentials(email);
    }

    public async Task<LoginResult> LoginWithoutPassword(string userId) {
        var user = await _userManager.FindByIdAsync(userId);

        if (await _userManager.IsLockedOutAsync(user))
            return new LoginResult(EnumLoginResultErrors.IsLockedOut);
        else if (!await _userManager.IsEmailConfirmedAsync(user))
            return new LoginResult(EnumLoginResultErrors.EmailNotConfirmed);

        return await GenerateCredentials(user.Email);
    }

    private async Task<LoginResult> GenerateCredentials(string email) {
        var user = await _userManager.FindByEmailAsync(email);
        var accessTokenClaims = await GetClaims(user, addClaimsUser: true);
        var refreshTokenClaims = await GetClaims(user, addClaimsUser: false);

        var dateExpirationAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
        var dateExpirationRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

        var accessToken = GenerateToken(accessTokenClaims, dateExpirationAccessToken);
        var refreshToken = GenerateToken(refreshTokenClaims, dateExpirationRefreshToken);

        return new LoginResult(accessToken, refreshToken, dateExpirationAccessToken, dateExpirationRefreshToken);
    }

    private string GenerateToken(IEnumerable<Claim> claims, DateTime dateExpiration) {
        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: dateExpiration,
            signingCredentials: _jwtOptions.SigningCredentials);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private async Task<IList<Claim>> GetClaims(IdentityUser user, bool addClaimsUser) {
        var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
            };

        if (addClaimsUser) {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);

            foreach (var role in roles)
                claims.Add(new Claim("role", role));
        }

        return claims;
    }
}