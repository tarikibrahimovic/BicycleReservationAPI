﻿using BicycleReservation.Domain.DTO.Admin;
using BicycleReservation.Domain.DTO.User;
using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IAdminRepository : IGenericRepository<User, int>
    {
        public Task<Station> AddStation(AddStationRequest request);
        public Task<Bicycle> AddBicycle(int stationId, AddBicycleRequest request);
        public Task<bool> DeleteUser(int id);
        public Task<bool> PromoteUser(PromoteRequest request);
        public Task<List<UserDTO>> GetAllUsers();
    }
}
