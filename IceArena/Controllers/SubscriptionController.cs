using IceArena.Data.Models;
using IceArena.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IceArena.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
       private readonly ISubscriptionService _subscriptionService;

       public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubscription(int id)
        {
            var subscription = await _subscriptionService.GetSubscriptionAsync(id);
            return subscription != null ? Ok(subscription) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSubscriptions()
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptionsByAsync();
            return Ok(subscriptions);   
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubscription([FromBody] Subscription subscription)
        {
            await _subscriptionService.CreateSubscriptionByAsync(subscription);
            return CreatedAtAction(nameof(GetSubscription), new { id = subscription.Id }, subscription);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubscription(int id, [FromBody] Subscription subscription)
        {
            if (id != subscription.Id) return BadRequest("Id mismatch");
            await _subscriptionService.UpdateSubscriptionByAsync(subscription);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSubscription(int id)
        {
            await _subscriptionService.DeleteSubscriptionByAsync(id);
            return NoContent();
        }

    }
}
