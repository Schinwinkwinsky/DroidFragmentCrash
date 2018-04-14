using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DroidFragmentCrash.Models;

namespace DroidFragmentCrash.Data
{
    public interface IInformationManager
    {
        Task<List<Information>> GetInformationListAsync();
    }
}
