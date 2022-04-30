using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Domain.Interfaces
{
    public interface IFlowProvider
    {
        double GetInterval(double currentTime, double lambda);
    }
}
