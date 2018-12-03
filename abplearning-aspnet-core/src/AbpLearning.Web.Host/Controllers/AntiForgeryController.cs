using Microsoft.AspNetCore.Antiforgery;
using AbpLearning.Controllers;

namespace AbpLearning.Web.Host.Controllers
{
    public class AntiForgeryController : AbpLearningControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
