using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroidFragmentCrash.Data
{
    public interface IDataManager<T>
    {
        Task<List<T>> GetAllAsync();
    }
}
