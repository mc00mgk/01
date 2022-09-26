using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
         List<Product> _products;
        private Product? productToUpdate;

        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ CategoryId= 1, ProductId= 1, ProductName= "telefon", UnitPrice=100, UnitsInStock=2},
                new Product{ CategoryId= 2, ProductId= 2, ProductName= "pc", UnitPrice=150, UnitsInStock=5},
                new Product{ CategoryId= 3, ProductId= 3, ProductName= "kamera", UnitPrice=100, UnitsInStock=2},
                new Product{ CategoryId= 4, ProductId= 4, ProductName= "powerbank", UnitPrice=100, UnitsInStock=2},
                new Product{ CategoryId= 5, ProductId= 5, ProductName= "kulaklik", UnitPrice=100, UnitsInStock=2}

            }
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete;
            foreach (var p in products)
            {
                if (product.ProductId== p.ProductId)
                {
                    productToDelete = p;    
                }
                _products.Remove(p);


                /* LİNQ İLE KULLANIMI
                 productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId)
                 
     
                */
            }
            {

            }
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
           Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
           productToUpdate.ProductName = product.ProductName;   
           productToUpdate.ProductId = product.ProductId;
           productToUpdate.UnitPrice = product.UnitPrice;   
           productToUpdate.UnitsInStock = product.UnitsInStock;

           
           
        }
        public List<Product> GetAllByCategory(int CategoryId)
        {
            return _products.Where(p => p.CategoryId == CategoryId).ToList();   
        }
        
    }
}
