namespace SalesWebMvc.Models.ViewModels;

public class SellerFormVIewModel
{
    public Seller? Seller { get; set; }
    public ICollection<Department>? Departments { get; set; }
}
