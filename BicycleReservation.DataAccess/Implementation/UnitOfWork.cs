﻿using BicycleReservation.DataAccess.Context;
using BicycleReservation.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleReservation.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext context { get; set; }
        public IHttpContextAccessor acc { get; set; }
        public UnitOfWork(DataContext context, IConfiguration _configuration, IHttpContextAccessor acc)
        {
            this.context = context;
            this.acc = acc;
            UserRepository = new UserRepository(context, _configuration, acc, this);
            AuthRepository = new AuthRepository(context, _configuration, acc);
            AdminRepository = new AdminRepository(context, acc);
            StationRepository = new StationRepository(context, acc);
            BicycleRepository = new BicycleRepository(context);
            ClientRepository = new ClientRepository(context, acc);
            ServicerRepository = new ServicerRepository(context, acc);
            ManagerRepository = new ManagerRepository(context);
        }

        public IUserRepository UserRepository { get; set; }
        public IAuthRepository AuthRepository { get; set; }
        public IAdminRepository AdminRepository { get; set; }
        public IStationRepository StationRepository { get; set; }
        public IBicycleRepository BicycleRepository { get; set; }
        public IClientRepository ClientRepository { get; set; }
        public IServicerRepository ServicerRepository { get; set; }
        public IManagerRepository ManagerRepository { get; set; }
        
        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
