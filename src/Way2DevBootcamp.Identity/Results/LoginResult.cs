using Way2DevBootcamp.Identity.Enumerators;

namespace Way2DevBootcamp.Identity.Results;
public class LoginResult {
    public string AccessToken { get; private set; }
    public DateTime AccessTokenExpireAt { get; private set; }
    public string RefreshToken { get; private set; }
    public DateTime RefreshTokenExpireAt { get; private set; }
    public EnumLoginResultErrors? Error { get; private set; }

    public LoginResult(string accessToken,
                       string refreshToken,
                       DateTime accessTokenExpireAt,
                       DateTime refreshTokenExpireAt) {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        AccessTokenExpireAt = accessTokenExpireAt;
        RefreshTokenExpireAt = refreshTokenExpireAt;
    }

    public LoginResult(EnumLoginResultErrors error)
        => Error = error;
}