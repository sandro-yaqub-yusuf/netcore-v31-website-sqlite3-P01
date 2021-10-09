using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;

namespace KITAB.CRUD.Products.Web.Extensions
{
    public static class RazorExtensions
    {
        public static HtmlString FormataSituacao(this RazorPage page, string situacao = "A")
        {
            if (page is null) return new HtmlString("<span class='badge badge-success'>INDEFINIDO</span>");

            return new HtmlString((situacao == "A" ? "<span class='badge badge-success'>ATIVADO</span>" : "<span class='badge badge-danger'>DESATIVADO</span>"));
        }
    }
}
