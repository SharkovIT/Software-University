using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int valueOfInteligence = int.Parse(Console.ReadLine());

            var stackOfBullets = new Stack<int>(bullets);
            var queueOfLocks = new Queue<int>(locks);

            int countShoots = 0;
            int countGunBarrel = 0;

            while (stackOfBullets.Count != 0)
            {
                int bulletSize = stackOfBullets.Peek();
                int lockSize = queueOfLocks.Peek();
                     
                if (bulletSize <= lockSize)
                {
                    Console.WriteLine("Bang!");
                    queueOfLocks.Dequeue();
                    stackOfBullets.Pop();
                    countShoots++;
                    countGunBarrel++;
                }
                else if (bulletSize > lockSize)
                {
                    Console.WriteLine("Ping!");
                    stackOfBullets.Pop();
                    countShoots++;
                    countGunBarrel++;
                }
                if (sizeOfGunBarrel == countGunBarrel && stackOfBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    countGunBarrel = 0;                    
                }
                if (queueOfLocks.Count == 0)
                {
                    break;
                }
            }
            if (queueOfLocks.Count == 0)
            {
                Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${valueOfInteligence - (countShoots * priceOfBullet)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
            }
        }
    }
}
