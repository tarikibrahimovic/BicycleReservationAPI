using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        //giving access to the repositories
        IUserRepository UserRepository { get; }
        IAuthRepository AuthRepository { get; }
        IAdminRepository AdminRepository { get; }
        IStationRepository StationRepository { get; }
        IBicycleRepository BicycleRepository { get; }
        IClientRepository ClientRepository { get; }
        int Save();
    }
}
