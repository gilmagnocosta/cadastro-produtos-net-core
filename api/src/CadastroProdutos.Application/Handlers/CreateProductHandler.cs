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
    class CreateProductHandler: IRequestHandler<CreateProductRequest, int?>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CreateProductHandler(IMapper mapper, NotificationContext notificationContext, IProductService productService)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _productService = productService;
        }

        public async Task<int?> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product entity = _mapper.Map<CreateProductRequest, Product>(request);

            entity.Validate(entity, new ProductValidator());
            if (entity.Invalid)
            {
                _notificationContext.AddNotifications(entity.ValidationResult);
                return null;
            }

            await _productService.AddAsync(entity);

            if (_notificationContext.HasNotifications) return null;

            return entity.Id;
        }
    }
}
