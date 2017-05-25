using System;
using DataAccessLayer.Repositories.GenericRepositories;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }

        int Complete();
    }
}