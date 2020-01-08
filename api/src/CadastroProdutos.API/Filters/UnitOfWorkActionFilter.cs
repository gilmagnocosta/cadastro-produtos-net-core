using Microsoft.AspNetCore.Mvc.Filters;
using CadastroProdutos.Infra.Data.Interface;

namespace CadastroProdutos.API.Filters
{
    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            UnitOfWork = (IUnitOfWork)actionExecutedContext.HttpContext.RequestServices.GetService(typeof(IUnitOfWork));
            if (actionExecutedContext.Exception == null)
            {
                UnitOfWork.Commit();
            }
        }
    }
}
