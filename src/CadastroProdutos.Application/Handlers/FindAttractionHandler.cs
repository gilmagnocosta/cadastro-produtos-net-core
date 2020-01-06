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
    public class FindAttractionHandler : IRequestHandler<FindAttractionRequest, ProductViewModel>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IMapper _mapper;
        private readonly IAttractionService _service;
        
        
        public FindAttractionHandler(IMapper mapper, NotificationContext notificationContext, IAttractionService service)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _service = service;
        }

        public async Task<ProductViewModel> Handle(FindAttractionRequest request, CancellationToken cancellationToken)
        {
            var entity = await _service.FindByAsync(request.Id);
            return await Task.FromResult(_mapper.Map<ProductViewModel>(entity));
        }
    }
}