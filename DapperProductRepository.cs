using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;

    public DapperProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Products> GetAllProducts()
    {
        return _conn.Query<Products>("SELECT * FROM products;");
    }
    public void CreateProduct(string name, double price, int categoryID)
    {

    }
    public Products GetProduct(int id)
    {
        return _conn.QuerySingle<Products>("SELECT * FROM products WHERE ProductID = @id;", 
            new { id = id });
    }

    public void UpdateProduct(Products product)
    {
        _conn.Execute("UPDATE products " +
            "SET Name = @name, " +
            "Price = @price, " +
            "CategoryID = @catid, " +
            "OnSale = @onSale, " +
            "StockLevel = @stock " +
            "WHERE ProductID = @id;",
            new 
            { 
                id = product.ProductID, 
                name = product.Name, 
                price = product.Price, 
                catid = product.CategoryID, 
                onSale = product.OnSale, 
                stock = product.StockLevel });
    }
}
