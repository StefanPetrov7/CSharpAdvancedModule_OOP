using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class SeniorManager : Manager
    {
        private const double INIT_RANKING = 30;
        public SeniorManager(string name) : base(name, INIT_RANKING)
        {
        }
    }
}
