using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class ProfessionalManager : Manager
    {
        private const double INIT_RANKING = 60;
        private const double RANKING_MODIFYER = 1.5;

        public ProfessionalManager(string name) : base(name, INIT_RANKING)
        {
            
        }

        public override void RankingUpdate(double number)
        {
            number *= RANKING_MODIFYER;
            base.RankingUpdate(number);
        }
    }
}
