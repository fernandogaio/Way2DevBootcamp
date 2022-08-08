namespace Way2DevBootcamp.Identity.Enumerators;
public enum EnumLoginResultErrors {
    IsLockedOut = 1,
    IsNotAllowed = 2,
    RequiresTwoFactor = 3,
    EmailNotConfirmed = 4,
    InvalidCredentials = 5
}