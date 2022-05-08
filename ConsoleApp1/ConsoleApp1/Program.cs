using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minBossHealth = 1000;
            int maxBossHealth = 1500;
            int minPlayerHealth = 600;
            int maxPlayerHealth = 1000;
            int bossHealth = random.Next(minBossHealth, maxBossHealth);
            int startPlayerHealt = random.Next(minPlayerHealth, maxPlayerHealth);
            int bossDamage = 70;
            int playerHealth = startPlayerHealt;
            int playerDamage = 55;
            int userCommand;
            int amplifier = 2;
            int summonDamage = 100;
            int healthCoast = 50;
            int healthHeal = 250;
            int summonNumber = 0;
            int exodiaNumber = 0;
            bool isSummond = false;
            Console.WriteLine($"Перед вами ужасный босс, у него {bossHealth} здоровья");

            do
            {
                Console.WriteLine($"У вас {playerHealth} здоровья");
                Console.WriteLine("вам доступны заклинания:");
                Console.WriteLine($"1. Огненая вспышка: наносит {playerDamage} урона");
                Console.WriteLine($"2. Огненный взрыв: наносит {healthCoast} урона вам и двойной урон боссу");
                Console.WriteLine($"3. Призывает саммона за {healthCoast} вашего здоровья, который атакует босса на {summonDamage} во время ваших действий");
                Console.WriteLine($"4. Востановить {healthHeal} здоровья и получить один ход неуязвимости");
                Console.WriteLine($"5. Призвать одну часть экзодии за {healthCoast}, если призванны все 5 частей, уничтожает босса. На данный момент призванно {exodiaNumber}");
                userCommand = Convert.ToInt32(Console.ReadLine());

                switch (userCommand)
                {
                    case 1:
                        Console.WriteLine("Огненная вспышка");
                        bossHealth -= playerDamage;

                        if (isSummond == true)
                        {
                            Console.WriteLine($"Саммон атакавал босса");
                            bossHealth -= summonDamage * summonNumber;
                            Console.WriteLine();
                            Console.WriteLine($"Здоровье босса {bossHealth}");
                        }
                        Console.WriteLine($"Здоровье босса :{bossHealth}");
                        break;
                    case 2:
                        Console.WriteLine("Огненный взрыв");
                        bossHealth -= healthCoast * amplifier;
                        playerHealth -= healthCoast;

                        if (isSummond == true)
                        {
                            Console.WriteLine($"Саммон атакавал босса");
                            bossHealth -= summonDamage * summonNumber;
                            Console.WriteLine();
                            Console.WriteLine($"Здоровье босса {bossHealth}");
                        }
                        Console.WriteLine($"Здоровье босса :{bossHealth}");
                        break;
                    case 3:
                        Console.WriteLine("Вы призвали саммона");
                        playerHealth -= healthCoast;
                        isSummond = true;
                        summonNumber++;
                        Console.WriteLine($"Ваше здоровье равно {playerHealth}");

                        if (isSummond == true)
                        {
                            Console.WriteLine($"Саммон атакавал босса");
                            bossHealth -= summonDamage * summonNumber;
                            Console.WriteLine();
                            Console.WriteLine($"Здоровье босса {bossHealth}");
                        }
                        break;
                    case 4:
                        playerHealth += healthHeal;

                        if (playerHealth + healthHeal > startPlayerHealt)
                        {
                            playerHealth = startPlayerHealt;
                        }
                        Console.WriteLine($"Вы восстановили себе {healthHeal} здоровья, теперь у вас {playerHealth} здоровья");

                        if (isSummond == true)
                        {
                            Console.WriteLine($"Саммон атакавал босса");
                            bossHealth -= summonDamage * summonNumber;
                            Console.WriteLine($"Здоровье босса {bossHealth}");
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Вы призываете часть экзодии");
                        playerHealth -= healthCoast;
                        exodiaNumber++;

                        if (isSummond == true)
                        {
                            Console.WriteLine($"Саммон атакавал босса");
                            bossHealth -= summonDamage * summonNumber;
                            Console.WriteLine($"Здоровье босса {bossHealth}");
                            Console.WriteLine();
                        }
                        if (exodiaNumber == 5)
                        {
                            Console.WriteLine("Вы призвали экзодию");
                            bossHealth = 0;
                            break;
                        }
                        break;
                }

                    Console.WriteLine("Босс ударил вас");
                    playerHealth -= bossDamage;

                    if (playerHealth <= 0)
                    {
                        break;
                    }                
            } while (bossHealth > 1 & playerHealth > 1);

            if (bossHealth <= 0)
            {
                Console.WriteLine("Вы победили");
            }
            if (playerHealth <= 0)
            {
                Console.WriteLine("You died");
            }
        }
    }
}