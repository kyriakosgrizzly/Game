using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class EnemyRanged:Fighter
    {
        public EnemyRanged()
        {
            Health = rand.Next(5, 10);
            AttDMG = rand.Next(1, 3);
            AttRange = rand.Next(5,10);
            AttSpeed = 1;
        }
    }
}
