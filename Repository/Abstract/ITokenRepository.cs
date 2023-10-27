using Microsoft.AspNetCore.Identity;

namespace QuanLiQuanCafe.Repository.Abstract
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
