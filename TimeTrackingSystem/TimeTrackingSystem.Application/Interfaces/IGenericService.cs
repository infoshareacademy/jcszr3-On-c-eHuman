using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        int AddI(T entity);
        string AddS(T entity);
        T EditI(int id);
        T EditS(string id);
        T GetI(int entityId);
        T GetS(string entityId);
        List<T> GetAll();
        void Delete(int id);
        void Update(T entity);

    }
}
