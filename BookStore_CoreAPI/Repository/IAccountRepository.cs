using BookStore_CoreAPI.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore_CoreAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUP(SignUp signUp);
        Task<string> LogIn(SignIn signIn);



    }
}
