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
    public class SaleManager : ISales
    {
        private readonly WebAPIDbContext _context;
        public SaleManager(WebAPIDbContext context)
        {
            _context = context;
        }
        public SaleResponse AddSale(SaleCreateRequest saleCreateRequest)
        {
            Sale sale = new Sale();
            sale.CreatedDate = DateTime.Now;
            sale.CartId = saleCreateRequest.CartId;
            _context.Sales.Add(sale);
            SaleResponse saleResponse = new SaleResponse(sale);
            return saleResponse;
        }
        public void DeleteSale(int id)
        {
            var deleteSale = _context.Sales.Find(id);

            if (deleteSale != null)
            {
                _context.Sales.Remove(deleteSale);
            }
        }
        public List<SaleResponse> GetAllSales(int? cartId = null)
        {
            IQueryable<Sale> query = _context.Sales;
            if (cartId != null)
            {
                query = query.Where(p => p.CartId == cartId);
            }
            List<SaleResponse> saleResponses = query.Select(p => new SaleResponse(p))
               .ToList();
            return saleResponses;
        }

        public SaleResponse GetSaleById(int id)
        {
            Sale sale = _context.Sales.Find(id);
            if (sale == null) 
            {
                return null;
            }
            SaleResponse saleResponse = new SaleResponse(sale);
            return saleResponse;
        }

        public void PartialUpdateSale(int id, Dictionary<string, object> updates)
        {
            
            var sale = _context.Sales.FirstOrDefault(x => x.Id == id);
            if (sale != null)
            {
                foreach (var update in updates)
                {
                    switch (update.Key.ToLower())
                    {
                        // case "description":
                        //     Sale.Description = update.Value.ToString();
                        //     break;
                        // default:
                        //     break;
                    }
                }
            }
        }
    }
}
