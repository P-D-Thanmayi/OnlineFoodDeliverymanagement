using FoodDeliveryProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace FoodDeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressServices _address;
        public AddressController(AddressServices address)
        {
            _address = address;
        }

        [HttpDelete("delete/address/{id}")]
        public ActionResult DeleteAddressById(int id)
        {
            var result = _address.DeleteAddress(id);
            if (result == false)
            {
                return BadRequest("Provided id is not found");
            }
            return Ok(result);
        }
    }
}
