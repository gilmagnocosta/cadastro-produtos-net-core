using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos.Infra.Services.Email.Models
{
    public class ForgotPasswordModel
    {
        public string FirstName { get; set; }
        public string Token { get; set; }
    }
}
