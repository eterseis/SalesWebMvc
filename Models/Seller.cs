using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace SalesWebMvc.Models;

public class Seller
{
    public int Id { get; set; }
    [Required]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
    public string? Name { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Birth Date")]
    public DateTime BirthDate { get; set; }

    [Required]
    [Range(100.00, 50000.00, ErrorMessage = "{0} must be from {1} to {2}")]
    [Display(Name = "Base Salary")]
    [DataType(DataType.Currency)]
    public double BaseSalary { get; set; }
    public Department? Department { get; set; }
    public int DepartmentId { get; set; }
    public ICollection<SalesRecord> Sales { get; set; } = [];

    public Seller() { }
    public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }

    public void AddSales(SalesRecord sr)
    {
        Sales.Add(sr);
    }
    public void RemoveSales(SalesRecord sr)
    {
        Sales.Remove(sr);
    }
    public double TotalSales(DateTime initial, DateTime final)
    {
        return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
    }
}
