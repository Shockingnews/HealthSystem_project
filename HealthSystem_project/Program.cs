using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        static int xprequierd = 100;
        static void Main(string[] args)
        {
            //
            //
            //
            UnitTestXPSystem();
            UnitTestHealthSystem();
            TakeDamage(5);
            Heal(50);
            IncreaseXP(150);
            RegenerateShield(200);
            ShowHUD();


        }

        static void ShowHUD()
        {
            Console.WriteLine($"Health: {health}  Shield: {shield}  Lives: {lives}     Xp: {xp}    Level: {level}");
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
            if (0 > damage)
            {
                Console.WriteLine($"error can't take {damage}");
            }
            else if (shield > 0)
            {
                shield -= damage;
                if (shield <= 0)
                {
                    health += shield;
                    shield = 0;
                    if (health <= 0)
                    {
                        health = 0;
                    }
                }
                
            }
            else if(shield <= 0)
            {
                shield = 0;
                health -= damage;
                if (health <= 0)
                {
                    health = 0;
                }
            }
            
        }
        static void Revive()
        {
            if (health <= 0)
            {
                lives -= 1;
                health = 100;
                shield = 100;
                Console.WriteLine($"Lost a life you have {lives} lives left");
            }
            
        }
        static void Heal(int hp)
        {
            if (hp < 0)
            {
                Console.WriteLine($"can't heal");
            }
            else if (health < 100)
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
            if (hp < 0)
            {
                Console.WriteLine($" can't Regenerate Shield");
            }
            else if (shield < 100)
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
            
            if (xp >= xprequierd)
            {
                level += 1;
                xp -= xprequierd;
                xprequierd += 100;
            }
        }

        static void UnitTestHealthSystem()
        {
            Debug.WriteLine("Unit testing Health System started...");

            // TakeDamage()

            // TakeDamage() - only shield
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield and health
            shield = 10;
            health = 100;
            lives = 3;
            TakeDamage(50);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 60);
            Debug.Assert(lives == 3);

            // TakeDamage() - only health
            shield = 0;
            health = 50;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 40);
            Debug.Assert(lives == 3);

            // TakeDamage() - health and lives
            shield = 0;
            health = 10;
            lives = 3;
            TakeDamage(25);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield, health, and lives
            shield = 5;
            health = 100;
            lives = 3;
            TakeDamage(110);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            TakeDamage(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Heal()

            // Heal() - normal
            shield = 0;
            health = 90;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 95);
            Debug.Assert(lives == 3);

            // Heal() - already max health
            shield = 90;
            health = 100;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // Heal() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Heal(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // RegenerateShield()

            // RegenerateShield() - normal
            shield = 50;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - already max shield
            shield = 100;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            RegenerateShield(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Revive()

            // Revive()
            shield = 0;
            health = 0;
            lives = 2;
            Revive();
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 1);

            Debug.WriteLine("Unit testing Health System completed.");
            Console.Clear();
        }

        static void UnitTestXPSystem()
        {
            Debug.WriteLine("Unit testing XP / Level Up System started...");

            // IncreaseXP()

            // IncreaseXP() - no level up; remain at level 1
            xp = 0;
            level = 1;
            IncreaseXP(10);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 1);

            // IncreaseXP() - level up to level 2 (costs 100 xp)
            xp = 0;
            level = 1;
            IncreaseXP(105);
            Debug.Assert(xp == 5);
            Debug.Assert(level == 2);

            // IncreaseXP() - level up to level 3 (costs 200 xp)
            xp = 0;
            level = 2;
            IncreaseXP(210);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 3);

            // IncreaseXP() - level up to level 4 (costs 300 xp)
            xp = 0;
            level = 3;
            IncreaseXP(315);
            Debug.Assert(xp == 15);
            Debug.Assert(level == 4);

            // IncreaseXP() - level up to level 5 (costs 400 xp)
            xp = 0;
            level = 4;
            IncreaseXP(499);
            Debug.Assert(xp == 99);
            Debug.Assert(level == 5);

            Debug.WriteLine("Unit testing XP / Level Up System completed.");
            Console.Clear();
        }
    }
}
