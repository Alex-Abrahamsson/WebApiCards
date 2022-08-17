using Microsoft.AspNetCore.Mvc;

namespace webapicards.Controllers;

[ApiController]
[Route("[controller]")]

public class Id : ControllerBase
{
    [HttpGet(Name = "Id")]
    //Get: /Id
    public IEnumerable<string> Get()
    {
        return new List<string> {"Hello world", "I am a sample controller"};
    }
}
