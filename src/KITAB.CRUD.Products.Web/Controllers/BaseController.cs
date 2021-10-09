using Microsoft.AspNetCore.Mvc;
using KITAB.CRUD.Products.Application.Notificadores;

namespace KITAB.CRUD.Products.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificadorService _notificadorService;

        protected BaseController(INotificadorService notificadorService)
        {
            _notificadorService = notificadorService;
        }

        protected bool OperacaoValida()
        {
            return !_notificadorService.TemNotificacao();
        }
    }
}
