using System.ComponentModel.DataAnnotations;

namespace Way2DevBootcamp.Application.ViewModels;

public class UsuarioLoginViewModelInput {
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Senha { get; set; }
}