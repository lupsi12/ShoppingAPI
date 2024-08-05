using PersonelWebAPI.Services.Abstract;

namespace PersonelWebAPI.UnitOfWork.UnitOfWork;

public interface IUnitOfWork
{
    IPersonel PersonelRepository { get; }
    IAdmin AdminRepository { get; }
    IAddres AddresRepository { get; }
    ISupplier SupplierRepository { get; }
    int Commit();
}