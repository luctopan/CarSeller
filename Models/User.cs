using System.Text.Json.Serialization;

namespace CarSeller.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public string Image { get; set; }
    public string Slug { get; set; }
    public string Bio { get; set; }
    public IList<Car> Cars { get; set; }
}