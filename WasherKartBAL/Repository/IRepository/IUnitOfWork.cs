using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasherKartBAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WasherKartBAL.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {  
        IUserRepository UserRepository { get; }
        void Save();
    }
}