using LlamachantDemoCRM.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamachantDemoCRM.Module.Interfaces
{
    public interface IHaveClient
    {
        Client Client { get; }
    }
}
