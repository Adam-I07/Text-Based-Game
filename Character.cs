using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Rpg_Game
{
    class Character
    {
        private string name;
        public string _name { get { return name; } set { name = value; } }
        private float _health = 100;
        
        public float _bankBalance = 100;
        public void Greeting()
        {
            Console.WriteLine("Your name is " + name + ", your bank balance currently stands at £" + bankBalance + " and your health currently stands at " + health);
        }

        public float bankBalance
        {
            get
            {
                return _bankBalance;
            }
            set
            {
                _bankBalance = value;
            }
        }
        public void money_lost(int _money_loss)
        {
            bankBalance -= _money_loss;
        }

        public void money_gained(int _money_gained)
        {
            bankBalance += _money_gained;
        }

        public void CheckStats()
        {
            
            Console.WriteLine(name + " currently you have £" + bankBalance + " and your health currently stands at " + health + ".");
        }

        public float health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public void damage(int _dmg)
        {
            health -= _dmg;
        }

        public void stillAlive()
        {
            if (health == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVERR!!!!!!");
                Console.WriteLine("You have lost all your health!");
                System.Environment.Exit(1);
            }
            else
            {
                ;
            }
        }

        public void stillHaveMoney()
        {
            if (bankBalance == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVERR!!!!!!");
                Console.WriteLine("You have ran out of money and couldnt pay resulted in you getting KILLED!!!");
                System.Environment.Exit(1);
            }
            else
            {
                ;
            }
        }

    }
}
