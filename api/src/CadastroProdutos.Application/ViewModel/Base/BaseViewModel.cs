using Flunt.Notifications;
using System;

namespace CadastroProdutos.Application.ViewModel.Base
{
    public class BaseViewModel : Notifiable
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public BaseViewModel()
        {
            this.CreatedAt = DateTime.Now;
            this.IsActive = true;
        }
    }
}
