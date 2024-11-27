namespace Orders.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> Orders = new();

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        return Ok(Orders);
    }

    [HttpPost]
    public ActionResult CreateOrder(Order order)
    {
        Orders.Add(order);
        return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateOrder(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest("Id in the URL and order object do not match");
        }

        var existingOrder = Orders.FirstOrDefault(o => o.Id == id);

        if (existingOrder == null)
        {
            return NotFound();
        }

        existingOrder.UserId = order.UserId;
        existingOrder.ProductName = order.ProductName;
        existingOrder.Price = order.Price;

        return NoContent(); // No content to return after successful update
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteOrder(int id)
    {
        var order = Orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        Orders.Remove(order);

        return NoContent(); // No content to return after successful deletion
    }
}
