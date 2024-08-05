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
    public class CartDetailManager : ICartDetail
    {
        private readonly WebAPIDbContext _context;
        public CartDetailManager(WebAPIDbContext context)
        {
            _context = context;
        }
        public CartDetailResponse AddCartDetail(CartDetailCreateRequest cartDetailCreateRequest)
        {
            CartDetail cartDetail = new CartDetail();
            cartDetail.CreatedDate = DateTime.Now;
            cartDetail.CartId = cartDetailCreateRequest.CartId;
            cartDetail.ProductId = cartDetailCreateRequest.ProductId;
            cartDetail.InstantPrice = cartDetailCreateRequest.InstantPrice;
            _context.CartDetails.Add(cartDetail);
            CartDetailResponse cartDetailResponse = new CartDetailResponse(cartDetail);
            return cartDetailResponse;
        }
        public void DeleteCartDetail(int id)
        {
            var deleteCartDetail = _context.CartDetails.Find(id);

            if (deleteCartDetail != null)
            {
                _context.CartDetails.Remove(deleteCartDetail);
            }
        }
        public List<CartDetailResponse> GetAllCartDetails(int? cartId = null, int? productId = null)
        {
            IQueryable<CartDetail> query = _context.CartDetails;
            if (cartId != null)
            {
                query = query.Where(query => query.CartId == cartId);
            }
            else if (productId != null)
            {
                query = query.Where(query => query.ProductId == productId);
            }
            List<CartDetailResponse> cartDetailResponses = query.Select(p => new CartDetailResponse(p))
               .ToList();
            return cartDetailResponses;
        }

        public CartDetailResponse GetCartDetailById(int id)
        {
            CartDetail cartDetail = _context.CartDetails.Find(id);
            if (cartDetail == null) 
            {
                return null;
            }
            CartDetailResponse cartDetailResponse = new CartDetailResponse(cartDetail);
            return cartDetailResponse;
        }

        public void PartialUpdateCartDetail(int id, Dictionary<string, object> updates)
        {
            
            var CartDetail = _context.CartDetails.FirstOrDefault(x => x.Id == id);
            if (CartDetail != null)
            {
                foreach (var update in updates)
                {
                    switch (update.Key.ToLower())
                    {
                        case "instantPrice":
                            if (int.TryParse(update.Value.ToString(), out int instantPrice))
                            {
                                CartDetail.InstantPrice = instantPrice;
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
