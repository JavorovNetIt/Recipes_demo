using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Data.Services.Contracts
{
    public interface IBaseService<T>
    {
        List<T> GetAllModels();
        T GetModelByID(int id);

        T GetModelByName(string name);

        void Save(T model);
    }
}
