using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    class Program
    {
       /* public static void ClearCorpses(List<Mob> army)
        {
            for (int i = 0; i < army.Count; i++)
            {
                if (army[i].getHP() <= 0)
                {
                    army.Remove(army[i]);
                    break;
                }
            }
        }*/
        public static void Counter( ref int i, List<Mob> army)
        {
            if (i >= (army.Count-1))
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }
        static void Main(string[] args)
        {

            List<Mob> kindArmy = new List<Mob>();
            List<Mob> darkArmy = new List<Mob>();
            Random r = new Random();
            int health;
            kindArmy = Mob.armyForming();
            darkArmy = Mob.armyForming();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"F:\Для сдачи .NET\c# 2 contr\Fight\log.txt", false))
            {
                file.WriteLine("Before battle");
                foreach (Mob u in kindArmy)
                {
                    file.WriteLine("kind " + u.ToString() + "\n");
                }

                foreach (Mob u in darkArmy)
                {
                    file.WriteLine("dark " + u.ToString() + "\n");
                }
                int i = 0;
                int j = 0;
                while (kindArmy.Count != 0 && darkArmy.Count != 0)
                {
                    if (i > (kindArmy.Count - 1)) i = 0;
                    if (j > (darkArmy.Count - 1)) j = 0;
                    Mob kindAttakingMob = kindArmy[i];
                    Mob darkAttackingMob = darkArmy[j];
                    Mob kindAttackedMob = kindArmy[r.Next(kindArmy.Count)];
                    Mob darkAttackedMob = darkArmy[r.Next(darkArmy.Count)];
                    //Console.WriteLine(i + " " + j +"\n");
                    //Console.WriteLine("prior " + kindAttakingMob.getPriority() + " " + darkAttackingMob.getPriority());
                    if (kindAttakingMob.getPriority() < darkAttackingMob.getPriority())
                    {
                        if (kindAttakingMob is Healing)
                        {
                            file.WriteLine("kind " + kindAttakingMob.GetType());
                            ((Healing)kindAttakingMob).healUnits(kindArmy);
                            file.WriteLine("kind " + kindAttakingMob.GetType() + " heal kind units");
                        }
                        else
                        {
                            health = darkAttackedMob.getHP() - kindAttakingMob.getPower();
                            if (health <= 0)
                            {
                                if (darkArmy.IndexOf(darkAttackedMob) < j) j--;
                                darkArmy.Remove(darkAttackedMob);
                                file.WriteLine("kind " + kindAttakingMob.GetType() + " kill dark " + darkAttackedMob.GetType() + "\n");
                            }
                            else
                            {
                                darkAttackedMob.setHP(health);
                                file.WriteLine("kind " + kindAttakingMob.GetType() + " attack dark " + darkAttackedMob.GetType() + " hp " + darkAttackedMob.getHP());
                            }
                        }
                        Counter(ref i, kindArmy);
                    }
                    else
                    {
                        if (kindAttakingMob.getPriority() == darkAttackingMob.getPriority())
                        {
                            switch (r.Next(2))
                            {
                                case 0:
                                    if (kindAttakingMob is Healing)
                                    {
                                        ((Healing)kindAttakingMob).healUnits(kindArmy);
                                        file.WriteLine("kind " + kindAttakingMob.GetType() + " heal kind units");
                                    }
                                    else
                                    {
                                        health = darkAttackedMob.getHP() - kindAttakingMob.getPower();
                                        if (health <= 0)
                                        {
                                            if (darkArmy.IndexOf(darkAttackedMob) < j) j--;
                                            darkArmy.Remove(darkAttackedMob);
                                            file.WriteLine("kind " + kindAttakingMob.GetType() + " kill dark " + darkAttackedMob.GetType() + "\n");
                                        }
                                        else
                                        {
                                            darkAttackedMob.setHP(health);
                                            file.WriteLine("kind " + kindAttakingMob.GetType() + " attack dark " + darkAttackedMob.GetType() + " hp " + darkAttackedMob.getHP() + "\n");
                                        }
                                    }
                                    Counter(ref i, kindArmy);
                                    break;
                                case 1:
                                    if (darkAttackingMob is Healing)
                                    {
                                        ((Healing)darkAttackingMob).healUnits(darkArmy);
                                        file.WriteLine("dark " + darkAttackingMob.GetType() + " heal dark units");
                                    }
                                    else
                                    {
                                        health = kindAttackedMob.getHP() - darkAttackingMob.getPower();
                                        if (health <= 0)
                                        {
                                            if (kindArmy.IndexOf(kindAttackedMob) < i) i--;
                                            kindArmy.Remove(kindAttackedMob);
                                            file.WriteLine("dark " + darkAttackingMob.GetType() + " kill kind " + kindAttackedMob.GetType());
                                        }
                                        else
                                        {
                                            kindAttackedMob.setHP(health);
                                            file.WriteLine("dark " + darkAttackingMob.GetType() + " attack kind " + kindAttackedMob.GetType() + " hp " + kindAttackedMob.getHP());
                                        }
                                    }
                                    Counter(ref j, darkArmy);
                                    break;
                            }
                        }
                        else
                        {
                            if (darkAttackingMob is Healing)
                            {
                                ((Healing)darkAttackingMob).healUnits(darkArmy);
                                file.WriteLine("dark " + darkAttackingMob.GetType() + " heal dark units");
                            }
                            else
                            {
                                health = kindAttackedMob.getHP() - darkAttackingMob.getPower();
                                if (health <= 0)
                                {
                                    if (kindArmy.IndexOf(kindAttackedMob) < i) i--;
                                    kindArmy.Remove(kindAttackedMob);                                    
                                    file.WriteLine("dark " + darkAttackingMob.GetType() + " kill kind " + kindAttackedMob.GetType());
                                }
                                else
                                {
                                    kindAttackedMob.setHP(health);
                                    file.WriteLine("dark " + darkAttackingMob.GetType() + " attack kind " + kindAttackedMob.GetType() + " hp " + kindAttackedMob.getHP());
                                }
                            }
                            Counter(ref j, darkArmy);
                        }
                    }
                }

                file.WriteLine("\nAfter battle\n");
                foreach (Mob u in kindArmy)
                {
                    file.WriteLine("kind" + u.ToString() + " " + u.getHP() + "\n");
                }

                foreach (Mob u in darkArmy)
                {
                    file.WriteLine("dark" + u.ToString() + " " + u.getHP() + "\n");
                }
            }
            /*Console.Write("After battle\n");
            foreach (Mob u in kindArmy)
            {
                Console.Write("kind" + u.ToString() + "\n");
            }

            foreach (Mob u in darkArmy)
            {
                Console.Write("dark" + u.ToString() + "\n");
            }
            Console.ReadKey();*/
        }
    }
}

