using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccessLayer.EntityMetaData;
using DataAccessLayer.Repositories.GenericRepositories;

namespace ADOConnectionLayer
{
    public class Repository : IRepository<Course>
    {
        public Course Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public Course SingleOrDefault(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> Find(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Course entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Course> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(Course entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Course> entities)
        {
            throw new NotImplementedException();
        }
    }
}