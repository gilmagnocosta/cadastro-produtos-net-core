using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CadastroProdutos.Application.Requests;
using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Domain.Interface.Service;
using CadastroProdutos.Domain.Notifications;
using CadastroProdutos.Domain.Validations;

namespace CadastroProdutos.Application.Handlers
{
    class DeleteProductHandler: IRequestHandler<DeleteProductRequest, int?>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public DeleteProductHandler(IMapper mapper, NotificationContext notificationContext, IProductService productService)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _productService = productService;
        }

        public async Task<int?> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            await _productService.DeleteAsync(request.Id);

            return null;
        }
    }
}
