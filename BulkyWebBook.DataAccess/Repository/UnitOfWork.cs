using BulkyWebBook.DataAccess.Data;
using BulkyWebBook.DataAccess.Repository.IRepository;
using BulkyWebBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWebBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IcategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext db) 
        {

            _db = db;
            Category = new CategoryRepository(_db);

        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
