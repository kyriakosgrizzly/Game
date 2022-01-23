using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Heal
    {
        public int Hp { get; set; }

        public int Placement { get; set; }
        Random rand = new Random();
        public Heal()
        {
            Hp = rand.Next(5, 20);
        }
        public void Player(Hero hero)
        {
            if (hero.CanBeHealed())
            {
                hero.heal(Hp);
            }
        }
    
    }
}
