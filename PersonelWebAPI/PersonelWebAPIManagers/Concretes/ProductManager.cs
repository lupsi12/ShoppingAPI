using PersonelWebAPI.DataAccess;
using PersonelWebAPI.Entities;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Managers.Concretes
{
    public class ProductManager : IProduct
    {
        private readonly WebAPIDbContext _context;
        public ProductManager(WebAPIDbContext context)
        {
            _context = context;
        }
        public ProductResponse AddProduct(ProductCreateRequest productCreateRequest)
        {
            Product product = new Product();
            product.CreatedDate = DateTime.Now;
            product.Name = productCreateRequest.Name;
            product.Description = productCreateRequest.Description;
            product.Stock = productCreateRequest.Stock;
            product.Price = productCreateRequest.Price;
            product.CategoryId = productCreateRequest.CategoryId;
            product.SupplierId = productCreateRequest.SupplierId;
            _context.Products.Add(product);
            ProductResponse productResponse = new ProductResponse(product);
            return productResponse;
        }
        public void DeleteProduct(int id)
        {
            var deleteProduct = _context.Products.Find(id);

            if (deleteProduct != null)
            {
                _context.Products.Remove(deleteProduct);
            }
        }
        public List<ProductResponse> GetAllProducts(string? name = null)
        {
            IQueryable<Product> query = _context.Products;
            if (name != null )
            {
                query = query.Where(p => p.Name == name );
            }
            
            List<ProductResponse> productResponses = query.Select(p => new ProductResponse(p))
               .ToList();
            return productResponses;
        }

        public ProductResponse GetProductById(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null) 
            {
                return null;
            }
            ProductResponse productResponse = new ProductResponse(product);
            return productResponse;
        }

        public void PartialUpdateProduct(int id, Dictionary<string, object> updates)
        {
            
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                foreach (var update in updates)
                {
                    switch (update.Key.ToLower())
                    {
                        case "description":
                            product.Description = update.Value.ToString();
                            break;
                        case "name":
                            product.Name = update.Value.ToString();
                            break;
                        case "stock":
                            product.Stock = int.Parse(update.Value.ToString());
                            break;
                        case "price":
                            product.Price = int.Parse(update.Value.ToString());
                            break;
                        case "updateddate":
                            if (DateTime.TryParse(update.Value.ToString(), out DateTime updateddate))
                            {
                                product.UpdatedDate = updateddate;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
