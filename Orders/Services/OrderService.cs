namespace Orders.Services;

[HttpGet("user/{userId}")]
public async Task<ActionResult<User>> GetUser(int userId)
{
    var httpClient = new HttpClient();
    var response = await httpClient.GetStringAsync($"http://localhost:8080/api/users/{userId}");
    var user = JsonConvert.DeserializeObject<User>(response);
    return Ok(user);
}