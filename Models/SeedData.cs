using SalesWebMvc.Models;
using SalesWebMvc.Data;
using SalesWebMvc.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SalesWebMvcContext
        (serviceProvider.GetRequiredService<DbContextOptions<SalesWebMvcContext>>()))
        {
            if (context.Department.Any() || context.Seller.Any() || context.SalesRecord.Any())
            {
                return;
            }
            //Departments
            var d1 = new Department(1, "Computers");
            var d2 = new Department(2, "Eletronics");
            var d3 = new Department(3, "Fashion");
            var d4 = new Department(4, "Books");
            //Sellers
            var s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            var s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            var s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            var s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            var s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            var s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);
            //SalesRecord
            var r1 = new SalesRecord(1, new DateTime(2024, 04, 25), 11000.0, SaleStatus.BILLED, s1);
            var r2 = new SalesRecord(2, new DateTime(2024, 04, 4), 7000.0, SaleStatus.BILLED, s5);
            var r3 = new SalesRecord(3, new DateTime(2024, 04, 13), 4000.0, SaleStatus.CANCELED, s4);
            var r4 = new SalesRecord(4, new DateTime(2024, 04, 1), 8000.0, SaleStatus.BILLED, s1);
            var r5 = new SalesRecord(5, new DateTime(2024, 04, 21), 3000.0, SaleStatus.BILLED, s3);
            var r6 = new SalesRecord(6, new DateTime(2024, 04, 15), 2000.0, SaleStatus.BILLED, s1);
            var r7 = new SalesRecord(7, new DateTime(2024, 04, 28), 13000.0, SaleStatus.BILLED, s2);
            var r8 = new SalesRecord(8, new DateTime(2024, 04, 11), 4000.0, SaleStatus.BILLED, s4);
            var r9 = new SalesRecord(9, new DateTime(2024, 04, 14), 11000.0, SaleStatus.PENDING, s6);
            var r10 = new SalesRecord(10, new DateTime(2024, 04, 7), 9000.0, SaleStatus.BILLED, s6);
            var r11 = new SalesRecord(11, new DateTime(2024, 04, 13), 6000.0, SaleStatus.BILLED, s2);
            var r12 = new SalesRecord(12, new DateTime(2024, 04, 25), 7000.0, SaleStatus.PENDING, s3);
            var r13 = new SalesRecord(13, new DateTime(2024, 04, 29), 10000.0, SaleStatus.BILLED, s4);
            var r14 = new SalesRecord(14, new DateTime(2024, 04, 4), 3000.0, SaleStatus.BILLED, s5);
            var r15 = new SalesRecord(15, new DateTime(2024, 04, 12), 4000.0, SaleStatus.BILLED, s1);
            var r16 = new SalesRecord(16, new DateTime(2024, 05, 5), 2000.0, SaleStatus.BILLED, s4);
            var r17 = new SalesRecord(17, new DateTime(2024, 05, 1), 12000.0, SaleStatus.BILLED, s1);
            var r18 = new SalesRecord(18, new DateTime(2024, 05, 24), 6000.0, SaleStatus.BILLED, s3);
            var r19 = new SalesRecord(19, new DateTime(2024, 05, 22), 8000.0, SaleStatus.BILLED, s5);
            var r20 = new SalesRecord(20, new DateTime(2024, 05, 15), 8000.0, SaleStatus.BILLED, s6);
            var r21 = new SalesRecord(21, new DateTime(2024, 05, 17), 9000.0, SaleStatus.BILLED, s2);
            var r22 = new SalesRecord(22, new DateTime(2024, 05, 24), 4000.0, SaleStatus.BILLED, s4);
            var r23 = new SalesRecord(23, new DateTime(2024, 05, 19), 11000.0, SaleStatus.CANCELED, s2);
            var r24 = new SalesRecord(24, new DateTime(2024, 05, 12), 8000.0, SaleStatus.BILLED, s5);
            var r25 = new SalesRecord(25, new DateTime(2024, 05, 31), 7000.0, SaleStatus.BILLED, s3);
            var r26 = new SalesRecord(26, new DateTime(2024, 05, 6), 5000.0, SaleStatus.BILLED, s4);
            var r27 = new SalesRecord(27, new DateTime(2024, 05, 13), 9000.0, SaleStatus.PENDING, s1);
            var r28 = new SalesRecord(28, new DateTime(2024, 05, 7), 4000.0, SaleStatus.BILLED, s3);
            var r29 = new SalesRecord(29, new DateTime(2024, 05, 23), 12000.0, SaleStatus.BILLED, s5);
            var r30 = new SalesRecord(30, new DateTime(2024, 05, 12), 5000.0, SaleStatus.BILLED, s2);

            context.Department.AddRange(d1, d2, d3, d4);
            context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10
            , r11, r12, r13, r14, r15, r16, r17, r18, r19, r20
            , r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

            context.SaveChanges();
        }
    }
}
