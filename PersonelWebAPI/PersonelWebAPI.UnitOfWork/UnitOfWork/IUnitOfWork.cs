using PersonelWebAPI.Services.Abstract;

namespace PersonelWebAPI.UnitOfWork.UnitOfWork;

public interface IUnitOfWork
{
    IPersonel PersonelRepository { get; }
    IAdmin AdminRepository { get; }
    IAddres AddresRepository { get; }
    ISupplier SupplierRepository { get; }
    IProduct ProductRepository { get; }
    ICart CartRepository { get; }
    ICartDetail CartDetailRepository { get; }
    ICategory CategoryRepository { get; }
    ISales SalesRepository { get; }
    int Commit();
}