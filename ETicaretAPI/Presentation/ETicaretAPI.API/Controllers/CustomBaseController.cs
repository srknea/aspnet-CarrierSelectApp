using ETicaretAPI.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction] // Aşağıdaki fonksiyon end-point değildir...
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            /* 204'ü geriye bir data dönmediğimiz sadece işlemin başarılı olduğunu client'a söylemek
            istediğimiz durumlarda kullanırız. Örneğin bir kayıt ekleme işlemi yaptık ve geriye 
            bir data dönmek istemiyoruz veya bir kayıt silme işlemi yaptık ve geriye bir data dönmek 
            istemiyoruz. Bu durumlardada da 204 dönebiliriz. */

            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
