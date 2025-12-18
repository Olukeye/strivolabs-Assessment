using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using strivolabs_Assessment.Entities;
using strivolabs_Assessment.Repository;

namespace strivolabs_Assessment.Controllers
{
    [ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {

        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe(SubscriptionRequest request)
        {
            //var service = HttpContext.Items["Service"] as Service;

            if (request.ServiceId == null)
                return Unauthorized("Service authentication failed");

            await _subscriptionService.Subscribe(request.ServiceId, request.PhoneNumber);
            return Ok("User subscribed successfully");
        }


        [HttpPost("unsubscribe")]
        public async Task<IActionResult> Unsubscribe([FromBody] SubscriptionRequest request)
        {
            var service = HttpContext.Items["Service"] as Service;
            if (service == null)
                return Unauthorized("Service authentication failed");

            try
            {
                await _subscriptionService.Unsubscribe(service, request.PhoneNumber);
                return Ok("User unsubscribed successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

    }
}
