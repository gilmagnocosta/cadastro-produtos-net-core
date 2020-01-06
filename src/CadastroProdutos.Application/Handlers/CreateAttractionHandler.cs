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
    class CreateAttractionHandler: IRequestHandler<CreateAttractionRequest, int?>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IAttractionService _attractionService;
        private readonly IMapper _mapper;

        public CreateAttractionHandler(IMapper mapper, NotificationContext notificationContext, IAttractionService attractionService)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _attractionService = attractionService;
        }

        public async Task<int?> Handle(CreateAttractionRequest request, CancellationToken cancellationToken)
        {
            Attraction entity = _mapper.Map<CreateAttractionRequest, Attraction>(request, opt =>
            {
                opt.AfterMap((request, dest) =>
                {
                    dest.Category = new AttractionCategory()
                    {
                        Id = request.CategoryId
                    };
                });
            });

            entity.Validate(entity, new AttractionValidator());
            if (entity.Invalid)
            {
                _notificationContext.AddNotifications(entity.ValidationResult);
                return null;
            }

            await _attractionService.AddAsync(entity);

            if (_notificationContext.HasNotifications) return null;

            return entity.Id;
        }
    }
}
