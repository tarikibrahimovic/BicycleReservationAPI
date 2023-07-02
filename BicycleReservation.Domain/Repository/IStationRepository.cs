﻿using BicycleReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.Domain.Repository
{
    public interface IStationRepository : IGenericRepository<Station, int>
    {
        public Task<List<Station>> GetAll();
    }
}
