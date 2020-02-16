using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebServices.Services;

namespace ViewModel.ViewModel.Login
{
    public class LoginViewModel
    {
        private LoginService service = new LoginService();

        public LoginViewModel()
        {

        }


        public async Task<bool> Login(string username, string pass)
        {
            var res = await service.Login(username, pass);

            return res;
        }
    }
}
