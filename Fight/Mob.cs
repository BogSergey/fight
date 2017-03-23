using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//parent class for all fighters
namespace Fight
{
    public abstract class Mob
    {
        private int maxHP;
        private int power;
        private int priority;
        private int HP;
        Random r = new Random();


        public Mob(int hp, int power, int priority)
        {
            this.maxHP = hp;
            this.power = power;
            this.priority = priority;
            this.HP = hp;
        }
        public Mob()
        {

        }

        public int getHP()
        {
            return HP;
        }

        public void setHP(int HP)
        {
            this.HP = HP;
        }

        public int getMaxHP()
        {
            return maxHP;
        }
        public int getPower()
        {
            return power;
        }

        public void setMaxHP(int maxHP)
        {
            this.maxHP = maxHP;
        }

        public void setPower(int power)
        {
            this.power = power;
        }

        public int getPriority()
        {
            return priority;
        }

        public void setPriority(int priority)
        {
            this.priority = priority;
        }

        public int getHealing()
        {
            return HP;
        }
        public static List<Mob> armyForming()// random forming army 
        {
            Random r = new Random(DateTime.Now.Millisecond);
            List<Mob> army = new List<Mob>();
            //army.Add(new AttackTower());
            for (int i = 0; i < 10; i++)
            {
                switch (r.Next(7))
                {
                    case 0:
                        {
                            army.Add(new Archer());
                            break;
                        }
                    case 1:
                        {
                            army.Add(new Warrior());
                            break;
                        }
                    case 2:
                        {
                            army.Add(new Cavalry());
                            break;
                        }
                    case 3:
                        {
                            army.Add(new CavalryArcher());
                            break;
                        }
                    case 4:
                        {
                            army.Add(new Healer());
                            break;
                        }
                    case 5:
                        {
                            army.Add(new AttackTower());
                            break;
                        }
                    case 6:
                        {
                            army.Add(new HealingTower());
                            break;
                        }
                }
            }
            army.Sort((a, b) => a.getPriority().CompareTo(b.getPriority()));//sorting creatures by priority
            return army;
        }

    }
}
