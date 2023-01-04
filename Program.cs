

using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

#region Departments
var departmentRepo = new DapperDepartmentRepository(conn);

departmentRepo.InsertDepartment("Car Audio");

var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();
}
#endregion

var productRepo = new DapperProductRepository(conn);

var productUpdated = productRepo.GetProduct(944);

productUpdated.ProductID = 944;
productUpdated.Name = "Updated Cassio Stereo";
productUpdated.Price = 140.50;
productUpdated.OnSale = false;
productUpdated.CategoryID = 2;
productUpdated.StockLevel = 3;

productRepo.UpdateProduct(productUpdated);

var products = productRepo.GetAllProducts();
foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
    Console.WriteLine();
}