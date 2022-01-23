using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Controller
    {
        public List<char> Map; 
        public List<Fighter> EnemyUnits { get; set; }
        public Hero MainChar { get; set; }

        public List<Heal> Heals { get; set; }

        public int Ecount = 0;

        public int HealCount = 0;

        Random rand = new Random();
        public int Length { get; set; }
        public Controller(int len,string name,int maxH) 
        {
            Map = new List<char>();
            EnemyUnits = new List<Fighter>();
            MainChar = new Hero(name, maxH);
            Heals = new List<Heal>();
            Length = len;
        }

        public void GameStart(int EnemyCount)
        {
            //clear Map
            for (int i = 0;i < Length; i++)
            {
                Map.Add('_');
            }
           
            //Add Enemies
            for(int i = 0;i < EnemyCount; i++)
            {
                var len = EnemyUnits.Count;
                if(i % 2 == 0)
                {
                    EnemyUnits.Add(new EnemyMelee());
                }
                else
                {
                    EnemyUnits.Add(new EnemyRanged());
                }
                EnemyUnits[len].Placement = 5 + Length / EnemyCount * i;
            }
            foreach(var enemy in EnemyUnits)
            {
                if(enemy is EnemyRanged)
                {
                    Map[enemy.Placement] = 'R';

                }
                else
                {
                    Map[enemy.Placement] = 'M';
                }
            }
            //add heals
           
            for (int i = 0;i < EnemyCount - 1; i++)
            {
                Heals.Add(new Heal());
                Heals[i].Placement = rand.Next(EnemyUnits[i].Placement,EnemyUnits[i+1].Placement);
                Map[Heals[i].Placement] = '@';
            }
           
            //add hero
            MainChar.Placement = 0;
            Map[MainChar.Placement] = 'H';
        }
        public void Heroaction()
        {
            if(HealCount < Heals.Count)
            {
                if (MainChar.Placement == Heals[HealCount].Placement)
                {
                    Heals[HealCount].Player(MainChar);
                    HealCount++;
                    return;
                }
            }
            
            if(Ecount < EnemyUnits.Count - 1)
            {
                if (EnemyUnits[Ecount].Health <= 0) Ecount++;
            }
            
            if (MainChar.CanMove(EnemyUnits[Ecount]))
            {
                MainChar.move(Map);
            }
            else
            {
                if (MainChar.CanDamage(EnemyUnits[Ecount]))
                {
                    MainChar.Damage(EnemyUnits[Ecount]);
                }
            }
        }
        public void Enemyaction()
        {
            foreach (var unit in EnemyUnits)
            {
                if (unit.Health > 0)
                {
                    if (unit.CanDamage(MainChar))
                    {
                        unit.Damage(MainChar);
                    }
                }
            }
        }
        public void move()
        {
            Map[MainChar.Placement] = '_';
            MainChar.Placement++;
            Map[MainChar.Placement] = 'H';
        }
        public bool checkforwin()
        {
            if (MainChar.Placement == Length - 1) return true;

            return false;
        }
        public bool checkforlose()
        {
            if (MainChar.Health <= 0) return true;

            return false;
        }
        public void display()
        {
            Console.WriteLine($"HP {MainChar.Health}");
            foreach (var c in Map)
            {
                Console.Write(c);

            }
        }
    }
}
