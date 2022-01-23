using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Hero : Fighter
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
      
        public bool CanBeHealed()
        {
            if (Health <= MaxHealth)
            {
                return true;
            }
            else return false;
        }
        public void heal(int hp)
        {
            Health += hp;
            if (Health > MaxHealth) Health = MaxHealth;

        }

        public bool CanMove(Fighter enemy)
        {
            if (AttRange + Placement >= enemy.Placement && Placement - AttRange <= enemy.Placement && enemy.Health > 0)
            {
                return false;
            }
            return true;

        }
        public void move(List<char> Map)
        {
            Map[Placement] = '_';
            Placement++;
            Map[Placement] = 'H';
        }
        public Hero(string name, int maxH)
        {
            Name = name;
            MaxHealth = maxH;
            Health = maxH;
            AttDMG = 5;
            AttRange = 1;
            AttSpeed = 1;
        }
    }
}
