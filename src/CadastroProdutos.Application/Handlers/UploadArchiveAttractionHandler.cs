using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CadastroProdutos.Application.Requests;
using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Domain.Enums;
using CadastroProdutos.Domain.Interface.Service;
using CadastroProdutos.Domain.Notifications;
using CadastroProdutos.Domain.Validations;

namespace CadastroProdutos.Application.Handlers
{
    class UploadArchiveAttractionHandler: IRequestHandler<UploadMediaAttractionRequest, int?>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IAttractionService _attractionService;
        private readonly IMapper _mapper;

        public UploadArchiveAttractionHandler(IMapper mapper, NotificationContext notificationContext, IAttractionService attractionService)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _attractionService = attractionService;
        }

        public async Task<int?> Handle(UploadMediaAttractionRequest request, CancellationToken cancellationToken)
        {
            if (request.File == null || request.File.Length == 0)
            {
                _notificationContext.AddNotification("upload", "Informe o arquivo para realizar o upload");
                return null;
            }

            Archive entity = new Archive()
            {
                FileName = string.Concat(Path.GetRandomFileName(), Path.GetExtension(request.File.FileName)),
                Name = request.Name,
                Description = request.Description,
                FileExtension = Path.GetExtension(request.File.FileName),
                ArchiveType = ArchiveTypeEnum.Image,
                ContentType = request.File.ContentType,
                IsMain = request.IsMain
            };

            entity.Validate(entity, new ArchiveValidator());

            if (entity.Invalid)
            {
                _notificationContext.AddNotifications(entity.ValidationResult);
                return null;
            }

            await _attractionService.AddArchive(request.AttractionId, entity, request.File);

            if (_notificationContext.HasNotifications) return null;

            return entity.Id;
        }
    }
}
