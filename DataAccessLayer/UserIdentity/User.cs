using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessLayer.UserIdentity
{
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        
    }
}
