﻿//using FluentValidation;
//using Way2DevBootcamp.Application.Commands;
//using Way2DevBootcamp.Domain.Interfaces;

//namespace Way2DevBootcamp.Application.Validators;
//public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand> {
//    public CreateUsuarioCommandValidator() {
//        RuleFor(u => u.Email)
//            .NotEmpty().WithMessage("Email é obrigatório.")
//            .EmailAddress().WithMessage("Email inválido.");

//        RuleFor(u => u.Senha)
//            .NotEmpty().WithMessage("A senha é obrigatória.")
//            .Length(6, 50).WithMessage("A senha deve ter entre 6 e 50 caracteres.");

//        RuleFor(u => u.SenhaConfirmacao)
//            .Equal(u => u.Senha).WithMessage("Senhas não conferem.");
//    }
//}