using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.Models.Order;
using WebServices.Services;

namespace ViewModel.ViewModel.Login
{
    public class LoginViewModel:BaseViewModel
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

        public async Task SignUp(Customer cus)
        {
            await service.SignUp(cus);   
        }
    }
}
