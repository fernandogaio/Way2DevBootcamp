using Microsoft.AspNetCore.Identity;
using Way2DevBootcamp.Identity.Results;

namespace Way2DevBootcamp.Identity.Interfaces;
public interface IIdentityService {
    Task<IdentityResult> AddUser(IdentityUser user, string password);
    Task<LoginResult> Login(string email, string password);
    Task<LoginResult> LoginWithoutPassword(string userId);
}