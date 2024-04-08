using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace SalesWebMvc.Models;

public class Seller
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Birth Date")]
    public DateTime BirthDate { get; set; }
    [Display(Name = "Base Salary")]
    [DataType(DataType.Currency)]
    public double BaseSalary { get; set; }
    public Department? Department { get; set; }
    [Display(Name = "Department")]
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
