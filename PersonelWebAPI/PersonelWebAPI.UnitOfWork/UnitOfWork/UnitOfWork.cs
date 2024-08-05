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

    public UnitOfWork(WebAPIDbContext context)
    {
        this._context = context;
        PersonelRepository = new PersonelManager(_context);
        AdminRepository = new AdminManager(_context);
        AddresRepository = new AddresManager(_context);
        SupplierRepository = new SupplierManager(_context);
    }

    public int Commit()
    {
        return _context.SaveChanges();
    }
    
}