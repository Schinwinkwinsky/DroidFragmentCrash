using System;
using System.Threading.Tasks;

namespace DroidFragmentCrash.Data
{
    public interface IAccountManager
    {
        Task SignInAsync();
        void SignOut();
    }
}
