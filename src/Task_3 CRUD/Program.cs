using System;
using System.Linq;

namespace Task_3_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DzhusInternetShopDBContext db = new DzhusInternetShopDBContext())
            {
                Medicaments Medicament1 = new Medicaments { Name = "paracetamol" };
                Medicaments Medicament2 = new Medicaments { Name = "aspirin" };

                // Create
                db.Medicaments.AddRange(Medicament1, Medicament2);
                db.SaveChanges();
                //or
                //db.Medicaments.Add(Medicament1);
                //db.Medicaments.Add(Medicament2);
                //db.SaveChanges();
            }

            // Read
            using (DzhusInternetShopDBContext db = new DzhusInternetShopDBContext())
            {
                // we get objects from the database and print to the console
                var medicaments = db.Medicaments.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (Medicaments u in medicaments)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
            }

            // Update
            using (DzhusInternetShopDBContext db = new DzhusInternetShopDBContext())
            {
                // get the first object
                OrderDetails orderDetails = db.OrderDetails.FirstOrDefault();
                if (orderDetails != null)
                {
                    orderDetails.MedicamentId = 4;
                    orderDetails.Price = 999;
                    //update object
                    db.SaveChanges();
                    //or  
                    //db.OrderDetails.Update(orderDetails);                    
                }

                // data after update
                Console.WriteLine("\ndata after update");
                var orderDetails1 = db.OrderDetails.ToList();
                foreach (OrderDetails u in orderDetails1)
                {
                    Console.WriteLine($"{u.OrderId}.{u.MedicamentId} - {u.Price}");
                }
            }
            
            // Delete
            using (DzhusInternetShopDBContext db = new DzhusInternetShopDBContext())
             {
                // get the first object
                Employees employees = db.Employees.FirstOrDefault();
                if (employees != null)
                {
               // delete the object
                db.Employees.Remove(employees);
                db.SaveChanges();
             }

        // data after remove
         Console.WriteLine("\nData after remove");
                 var Employees1 = db.Employees.ToList();
                 foreach (Employees u in Employees1)
                 {
                 Console.WriteLine($"{u.Id}.{u.Fname} - {u.Post}");
                 }

         Console.ReadKey(); 
        }
    }


    }
}
