using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface IGenericService<T>
    {
        int Add(T model);
        void AddList(List<T> model);
        void Delete(int id);
        T Get(int id);
        T Edit(int id);
        void Update(T model);
        
    }
}
