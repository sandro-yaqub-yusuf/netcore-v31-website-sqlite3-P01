using Microsoft.AspNetCore.Mvc;

namespace KITAB.CRUD.Products.Web.Extensions
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
