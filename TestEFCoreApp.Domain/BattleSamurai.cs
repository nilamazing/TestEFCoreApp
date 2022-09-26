using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFCoreApp.Domain
{
    public class BattleSamurai
    {
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }
        public DateTime BattleDate { get; set; }
    }
}
