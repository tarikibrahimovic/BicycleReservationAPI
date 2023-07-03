﻿using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.DTO.Admin;
using BicycleReservation.Domain.Entities;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Implementation
{
    public class AdminRepository : GenericRepository<User, int>, IAdminRepository
    {
        private readonly IHttpContextAccessor _acc;
        public AdminRepository(DataContext context, IHttpContextAccessor acc) : base(context)
        {
            _acc = acc;
        }

        public async Task<Bicycle> AddBicycle(int stationId, AddBicycleRequest request)
        {
            int userId = int.Parse(_acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
            var stationExists = context.Stations.Any(x => x.Id == stationId);
            if (!stationExists)
                throw new Exception("Station does not exist");
            var bicycleExists = context.Bicycles.Any(x => x.Id == request.Id);
            if (bicycleExists)
                throw new Exception("Bicycle ID already exists");


            var lockCode = "";
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                lockCode += random.Next(0, 9).ToString();
            }

            var bicycle = new Bicycle
            {
                Id = request.Id,
                Naziv = request.Naziv,
                LockCode = lockCode,
                Type = request.Type
            };

            var record = new Record
            {
                BicycleId = request.Id,
                UserId = userId,
                StartDate = DateTime.UtcNow,
                NumberOfHours = null,
                CostPerHour = null,
                StartStationId = stationId,
                EndStationId = stationId
            };

            await context.Bicycles.AddAsync(bicycle);
            await context.Records.AddAsync(record);
            await context.SaveChangesAsync();
            return bicycle;
        }

        public async Task<Station> AddStation(AddStationRequest request)
        {
            var station = new Station
            {
                Name = request.Name,
                Lat = request.Lat,
                Lng = request.Lng
            };

            await context.Stations.AddAsync(station);
            await context.SaveChangesAsync();
            return station;
        }
    }
}