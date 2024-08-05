using PersonelWebAPI.DataAccess;
using PersonelWebAPI.Services.Abstract;
using PersonelWebAPI.Managers.Concretes;

namespace PersonelWebAPI.UnitOfWork.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly WebAPIDbContext _context;
    public IPersonel PersonelRepository { get; private set; }
    public IAdmin AdminRepository { get; private set; }
    public IAddres AddresRepository { get; private set; }
    public ISupplier SupplierRepository { get; private set; }
    public IProduct ProductRepository { get; private set; }
    public ICart CartRepository { get; private set; }
    public ICartDetail CartDetailRepository { get; private set; }
    public ICategory CategoryRepository { get; private set; }
    public ISales SalesRepository { get; private set; }
    public UnitOfWork(WebAPIDbContext context)
    {
        this._context = context;
        PersonelRepository = new PersonelManager(_context);
        AdminRepository = new AdminManager(_context);
        AddresRepository = new AddresManager(_context);
        SupplierRepository = new SupplierManager(_context);
        ProductRepository = new ProductManager(_context);
        CartRepository = new CartManager(_context);
        CartDetailRepository = new CartDetailManager(_context);
        CategoryRepository = new CategoryManager(_context);
        SalesRepository = new SaleManager(_context);
    }

    public int Commit()
    {
        return _context.SaveChanges();
    }
    
}