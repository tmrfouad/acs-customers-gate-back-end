using System.ComponentModel.DataAnnotations;

public class ShippingData {
    [Key]
    public int id { get; set; }
    public string apartment { get; set; }
    public string email { get; set; }
    public string floor { get; set; }
    public string first_name { get; set; }
    public string street { get; set; }
    public string building { get; set; }
    public string phone_number { get; set; }
    public string postal_code { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public string last_name { get; set; }
    public string state { get; set; }
    public Order order { get; set; }
}