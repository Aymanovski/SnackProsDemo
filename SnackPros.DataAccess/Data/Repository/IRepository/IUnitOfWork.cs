using System;
using System.Collections.Generic;
using System.Text;

namespace SnackPros.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        // All the work in a single transaction or batch with a save function to push to database
        ICategoryRepository Category { get; }

        void Save();
    }
}
