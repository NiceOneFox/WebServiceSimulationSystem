using Bll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Domain.Entities
{
    public class PoissonianFlowProvider : IFlowProvider
    {
        private static readonly Random _random = new();
        public double GetInterval(double currentTime, double lambda)
        {
            return currentTime + (-1.0 / lambda) * Math.Log(_random.NextDouble());
        }
    }
}
