using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KITAB.CRUD.Products.Application.Notificadores;
using KITAB.CRUD.Products.Domain.Models;

namespace KITAB.CRUD.Products.Web.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificadorService _notificadorService;

        public SummaryViewComponent(INotificadorService notificadorService)
        {
            _notificadorService = notificadorService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Notificacao> notificacoes = await Task.FromResult(_notificadorService.ObterNotificacoes()).ConfigureAwait(false);

            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));

            return View();
        }
    }
}
