using Microsoft.AspNetCore.Mvc;

namespace DrReceiver.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("/")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult Redirect() => Redirect("swagger"); //Redirect("api/test");
}
