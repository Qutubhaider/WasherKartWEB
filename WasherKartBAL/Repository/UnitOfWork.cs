using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasherKartBAL.Data;
using WasherKartBAL.Repository.IRepository;
using WasherKartBAL.Repository;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WasherKartBAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext moDatabaseContext;
        public UnitOfWork(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
            UserRepository = new UserRepository(moDatabaseContext);
        }

        public IUserRepository UserRepository { get; private set; }

        public void Dispose()
        {
            moDatabaseContext.Dispose();
        }
        public void Save()
        {
            moDatabaseContext.SaveChanges();
        }
    }
}