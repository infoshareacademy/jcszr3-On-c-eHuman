using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        T Get(int id);
        int Add(T entity);
        void Delete(int entityId);
        void Update(T entity);
    }
}
