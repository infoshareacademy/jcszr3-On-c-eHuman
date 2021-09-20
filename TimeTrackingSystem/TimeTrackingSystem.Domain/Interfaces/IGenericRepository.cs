using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetI(int id);
        T GetS(string id);
        int Add(T entity);
        void Delete(int entityId);
        void Edit(T entity);
        void Update(T entity);
    }
}
