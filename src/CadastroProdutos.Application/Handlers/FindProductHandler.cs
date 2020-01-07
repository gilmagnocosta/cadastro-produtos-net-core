using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CadastroProdutos.Application.Requests;
using CadastroProdutos.Application.ViewModel;
using CadastroProdutos.Domain.Interface.Service;
using CadastroProdutos.Domain.Notifications;

namespace SmartCheck.Application.Handlers
{
    public class FindProductHandler : IRequestHandler<FindProductRequest, ProductViewModel>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        
        
        public FindProductHandler(IMapper mapper, NotificationContext notificationContext, IProductService service)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _service = service;
        }

        public async Task<ProductViewModel> Handle(FindProductRequest request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetById(request.Id);
            return await Task.FromResult(_mapper.Map<ProductViewModel>(entity));
        }
    }
}