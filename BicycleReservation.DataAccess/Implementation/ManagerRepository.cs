using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Manager;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Implementation
{
    public class ManagerRepository : GenericRepository<User, int>, IManagerRepository
    {
        public ManagerRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<BicycleStatisticsResponse> GetBicycleStatistics(string bicycleId)
        {
            var bicycle = context.Bicycles.Include(b => b.Breakdowns).Include(b => b.Services).FirstOrDefault(b => b.Id == bicycleId) ?? throw new Exception("Bicycle with given id does not exist.");

            var records = context.Records.Where(r => r.BicycleId == bicycleId && r.NumberOfHours != null);
            int numberOfRents = await Task.Run(() => records.Count());
            int hoursRented = await Task.Run(() => records.Sum(r => r.NumberOfHours.Value));
            double? creditsSpent = await Task.Run(() => records.Sum(r => r.NumberOfHours * r.CostPerHour));
            int timesServiced = await Task.Run(() => bicycle.Services.Count());
            int timesRepaired = await Task.Run(() => bicycle.Breakdowns.Count(b => b.ResolvedDate == null));

            return new BicycleStatisticsResponse()
            {
                NumberOfRents = numberOfRents,
                HoursRented = hoursRented,
                CreditsSpent = creditsSpent ?? 0,
                TimesServiced = timesServiced,
                TimesRepaired = timesRepaired
            };
        }

        public async Task<OverallStatisticsResponse> GetOverallStatistics()
        {

            var numberOfStations = await Task.Run(() => context.Stations.Count());
            var numberOfBicycles = await Task.Run(() => context.Bicycles.Count());
            var records = await Task.Run(() => context.Records.Where(r => r.NumberOfHours != null));
            var numberOfRents = await Task.Run(() => records.Count());
            var hoursRented = await Task.Run(() => records.Sum(r => r.NumberOfHours.Value));
            var creditsSpent = await Task.Run(() => records.Sum(r => r.NumberOfHours * r.CostPerHour));

            return new OverallStatisticsResponse()
            {
                NumberOfStations = numberOfStations,
                NumberOfBicycles = numberOfBicycles,
                NumberOfRents = numberOfRents,
                HoursRented = hoursRented,
                CreditsSpent = creditsSpent ?? 0
            };
        }

        public async Task<StationStatisticsResponse> GetStationStatistics(int id)
        {
            if(context.Stations.FirstOrDefault(s => s.Id == id) == null)
                throw new Exception("Station with given id does not exist.");
            var numberOfArrivals = context.Records.Where(r => r.EndStationId == id && r.NumberOfHours != null).Count();
            var numberOfDepartures = context.Records.Where(r => r.StartStationId == id && r.NumberOfHours != null).Count();
            // var numberOfBicycles = context.Records.Where(r => r.StartStationId == id && r.NumberOfHours == null).Count();

            var records = context.Records.Include(r => r.Bicycle).ThenInclude(b => b.Breakdowns).Join(context.Bicycles, r => r.BicycleId, b => b.Id, (r, b) => new { r, b })
                .GroupBy(x => x.r.BicycleId)
                .Select(x => x.OrderByDescending(y => y.r.StartDate).Select(x => x.r).FirstOrDefault())
                .ToList();

            int numberOfBicycles = 0;
            int numberOfBreakdowns = 0;

            if (records != null)
            {
                numberOfBicycles = await Task.Run(() => records.Where(x => x.EndStationId == id && !x.Bicycle.Breakdowns.Any(b => b.ResolvedDate == null)).Select(x => x.Bicycle).Count());
                numberOfBreakdowns = await Task.Run(() => records.Where(x => x.EndStationId == id && x.Bicycle.Breakdowns.Any(b => b.ResolvedDate == null)).Select(x => x.Bicycle).Count());
            }
                

            return new StationStatisticsResponse()
            {
                NumberOfArrivals = numberOfArrivals,
                NumberOfDepartures = numberOfDepartures,
                NumberOfBicycles = numberOfBicycles,
                NumberOfBreakdowns = numberOfBreakdowns
            };
        }
    }
}
