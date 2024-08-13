using Microsoft.AspNetCore.Mvc;
using PersonelWebAPI.DataAccess;
using PersonelWebAPI.Entities;
using PersonelWebAPI.Enums;
using PersonelWebAPI.JWT;
using PersonelWebAPI.Requests;


namespace PersonelWebAPI.Controllers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;
    private readonly WebAPIDbContext _context;

    public AuthController(JwtTokenService jwtTokenService, WebAPIDbContext context)
    {
        _jwtTokenService = jwtTokenService;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        Personel? personel = _context.Personels.SingleOrDefault(x =>
            x.Email == loginRequest.Email && x.Password == loginRequest.Password);
    
        Admin? admin = null;
        Supplier? supplier = null;

        if (personel == null)
        {
            admin = _context.Admins.SingleOrDefault(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
        }

        if (admin == null && personel == null)
        {
            supplier = _context.Suppliers.SingleOrDefault(x =>
                x.Email == loginRequest.Email && x.Password == loginRequest.Password);
        }

        // Eğer Personel, Admin veya Supplier'dan biri eşleşirse
        if (personel != null || admin != null || supplier != null)
        {
            string email;
            Roles role;

            if (personel != null)
            {
                email = personel.Email;
                role = Roles.PERSONEL; // Rol enum'ınızda Personel gibi bir değer olduğunu varsayıyorum
            }
            else if (admin != null)
            {
                email = admin.Email;
                role = Roles.ADMIN;
            }
            else // supplier != null
            {
                email = supplier.Email;
                role = Roles.SUPPLIER;
            }

            var token = _jwtTokenService.GenerateToken(email, role);
            return Ok(new { Token = token });
        }

        // Eğer kullanıcı bulunamazsa
        return Unauthorized();
    }


}