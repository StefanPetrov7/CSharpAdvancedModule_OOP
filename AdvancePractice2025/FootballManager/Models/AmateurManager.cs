using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class AmateurManager : Manager
    {

        private const double INIT_RANKING = 15;
        private const double RANKING_MODIFYER = 0.75;


        public AmateurManager(string name) : base(name, INIT_RANKING)
        {
        }

        public override void RankingUpdate(double number)
        {
            number *= RANKING_MODIFYER;
            base.RankingUpdate(number);
        }
    }
}
