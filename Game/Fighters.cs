using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    abstract class Fighter : IComparable
    {
        public int Health { get; set; }
        public int AttDMG { get; set; }
        public int AttSpeed { get; set; }
        public int AttRange { get; set; }
        public int Placement { get; set; }

        protected int _reloadTimer = 0;
        public Random rand = new Random();
        public bool CanDamage(Fighter Opponent) {
            if (AttRange + Placement >= Opponent.Placement && Placement - AttRange <= Opponent.Placement && _reloadTimer == 0)
            {
                return true;
            }
            if (_reloadTimer > 0) _reloadTimer--;
            return false;
        }
        public void Damage(Fighter Opponent)
        {
            Opponent.Health -= AttDMG;
        }
        public bool CanTakeDamage()
        {
            if (Health > 0) return true;

            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var Sec = obj as Fighter;
            if(Sec == null) throw new ArgumentException("Object is not a Fighter");
            return Placement - Sec.Placement;
        }
    }
    


}
