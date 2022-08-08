namespace Way2DevBootcamp.Application.ViewModels {
    public class LoginViewModel {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpireAt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireAt { get; set; }
    }
}