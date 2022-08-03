using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Way2DevBootcamp.Identity.Data;
public class IdentityDataContext : IdentityDbContext {
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options) { }
}