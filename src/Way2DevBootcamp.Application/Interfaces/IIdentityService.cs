using Way2DevBootcamp.Application.ViewModels;

namespace Way2DevBootcamp.Application.Interfaces;

public interface IIdentityService {
    Task<UsuarioViewModelOutput> CadastrarUsuario(UsuarioViewModelInput usuarioCadastro);
    Task<UsuarioLoginViewModelOutput> Login(UsuarioLoginViewModelInput usuarioLogin);
    Task<UsuarioLoginViewModelOutput> LoginSemSenha(string usuarioId);
}