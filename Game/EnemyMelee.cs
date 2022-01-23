using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class EnemyMelee : Fighter
    {
        public EnemyMelee()
        {
            Health = rand.Next(10, 20);
            AttDMG = rand.Next(1,5);
            AttRange = 1;
            AttSpeed = 1;
        }
    }
}
