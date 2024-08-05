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
using PersonelWebAPI.Enums;

namespace PersonelWebAPI.Managers.Concretes
{
    public class CartManager : ICart
    {
        private readonly WebAPIDbContext _context;
        public CartManager(WebAPIDbContext context)
        {
            _context = context;
        }
        public CartResponse AddCart(CartCreateRequest cartCreateRequest)
        {
            Cart cart = new Cart();
            cart.CreatedDate = DateTime.Now;
            cart.PersonelId = cartCreateRequest.PersonelId;
            cart.CartStatus = CartStatus.APPROVAL;
            _context.Carts.Add(cart);
            CartResponse cartResponse = new CartResponse(cart);
            return cartResponse;
        }
        public void DeleteCart(int id)
        {
            var deleteCart = _context.Carts.Find(id);

            if (deleteCart != null)
            {
                _context.Carts.Remove(deleteCart);
            }
        }
        public List<CartResponse> GetAllCarts(int? personelId = null)
        {
            IQueryable<Cart> query = _context.Carts;
            if (personelId != null)
            {
                query = query.Where(p => p.PersonelId == personelId );
            }
            List<CartResponse> cartResponses = query.Select(p => new CartResponse(p))
               .ToList();
            return cartResponses;
        }

        public CartResponse GetCartById(int id)
        {
            Cart cart = _context.Carts.Find(id);
            if (cart == null) 
            {
                return null;
            }
            CartResponse cartResponse = new CartResponse(cart);
            return cartResponse;
        }

        public void PartialUpdateCart(int id, Dictionary<string, object> updates)
        {
            
            var cart = _context.Carts.FirstOrDefault(x => x.Id == id);
            if (cart != null)
            {
                foreach (var update in updates)
                {
                    switch (update.Key.ToLower())
                    {
                        case "cartStatus":
                            CartStatus status;
                            if (Enum.TryParse(update.Value.ToString(), out status))
                            {
                                cart.CartStatus = status;
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
