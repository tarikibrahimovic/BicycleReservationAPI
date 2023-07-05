using BicycleReservation.Domain.DTO.Manager;
using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IManagerRepository : IGenericRepository<User, int>
    {
        public Task<BicycleStatisticsResponse> GetBicycleStatistics(string bicycleId);
        Task<OverallStatisticsResponse> GetOverallStatistics();
        public Task<StationStatisticsResponse> GetStationStatistics(int id);
    }
}
