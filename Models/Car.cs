namespace CarSeller.Models;

public class Car
{
    public int Id { get; set; }
    public User Owner { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Image { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public double Price { get; set; }
}