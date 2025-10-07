using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem_project
{
    internal class Program
    {
        static int health = 100;
        static int shield = 50;
        static int lives = 3;
        static int xp = 0;
        static int level = 1;
        static void Main(string[] args)
        {
            //
            //
            //
            TakeDamage(200);
            Heal(50);
            RegenerateShield(200);
            ShowHUD();


        }

        static void ShowHUD()
        {
            Console.WriteLine($"Health: {health}  Shield: {shield}  Lives: {lives}");
            if(health <= 10)
            {
                Console.WriteLine("Imminent Danger ");
            }
            else if (health <= 50)
            {
                Console.WriteLine("Badly Hurt ");
            }
            else if (health <= 75)
            {
                Console.WriteLine("Hurt ");
            }
            else if (health <= 90)
            {
                Console.WriteLine("Healthy ");
            }
            else if (health == 100)
            {
                Console.WriteLine("Perfect Health ");
            }
        }

        static void TakeDamage(int damage)
        {
            if (shield > 0)
            {
                shield -= damage;
                if (shield <= 0)
                {
                    health += shield;
                    shield = 0;
                    Revive();
                }
            }
            else if(shield <= 0)
            {
                health -= damage;
                Revive();
            }
            
        }
        static void Revive()
        {
            if (health <= 0)
            {
                lives -= 1;
                health = 100;
                Console.WriteLine($"Lost a life you have {lives} lives left");
            }
        }
        static void Heal(int hp)
        {
            if (health < 100)
            {
                health += hp;
                if (health > 100)
                {
                    health = 100;
                }
            }
            else
            {
                Console.WriteLine($"Health is {health} can't heal");
            }
        }
        static void RegenerateShield(int hp)
        {
            if (shield < 100)
            {
                shield += hp;
                if (shield > 100)
                {
                    shield = 100;
                }
            }
            else
            {
                Console.WriteLine($"Shield is {shield} can't regenerate");
            }
        }
        static void IncreaseXP(int exp)
        {
            xp += exp;
            int xprequierd = 100;
            if (xp >= xprequierd)
            {
                level += 1;
            }
        }
    }
}
