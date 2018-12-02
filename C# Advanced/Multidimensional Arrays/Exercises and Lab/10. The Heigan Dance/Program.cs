using System;
using System.Linq;

namespace _10._The_Heigan_Dance
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] chamber = new char[15, 15];
            int playerRow = 7;
            int playerColumn = 7;
            int player = 18500;
            double Heigan = 3000000;

            double playerDamage = double.Parse(Console.ReadLine());
            bool cloudAftershock = false;
            string killingSpell = "";

            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string spell = input[0];
                int spellRow = int.Parse(input[1]);
                int spellColumn = int.Parse(input[2]);

                Heigan -= playerDamage;

                if (Heigan <= 0 || player <= 0)
                {
                    if (Heigan > 0) { Console.WriteLine($"Heigan: {Heigan:0.00}"); }
                    else { Console.WriteLine("Heigan: Defeated!"); }

                    if (player > 0) { Console.WriteLine($"Player: {player}"); }
                    else { Console.WriteLine($"Player: Killed by {killingSpell}"); }

                    Console.WriteLine($"Final position: {spellRow}, {spellColumn}");

                    break;
                }

                if (cloudAftershock == true)
                {
                    player -= 3500;
                    if (player <= 0)
                    {
                        killingSpell = "Plague Cloud";
                        if (Heigan <= 0 || player <= 0)
                        {
                            if (Heigan > 0) { Console.WriteLine($"Heigan: {Heigan:0.00}"); }
                            else { Console.WriteLine("Heigan: Defeated!"); }

                            if (player > 0) { Console.WriteLine($"Player: {player}"); }
                            else { Console.WriteLine($"Player: Killed by {killingSpell}"); }

                            Console.WriteLine($"Final position: {spellRow}, {spellColumn}");

                            break;
                        }
                    }
                }

                cloudAftershock = false;

                bool PlayerIsWithinDamagedArea = CheckIfPlayerIsWithinTheDamagedArea(playerRow, playerColumn, spellRow, spellColumn);

                if (PlayerIsWithinDamagedArea)
                {
                    bool moveUp = CheckIfPlayerCanMoveUp(playerRow, spellRow);
                    if (moveUp == true)
                    {
                        playerRow -= 1;
                    }

                    else
                    {
                        bool moveRight = CheckIfPlayerCanMoveRight(playerColumn, spellColumn);
                        if (moveRight == true)
                        {
                            playerColumn += 1;
                        }

                        else
                        {
                            bool moveDown = CheckIfPlayerCanMoveDown(playerRow, spellRow);
                            if (moveDown == true)
                            {
                                playerRow += 1;
                            }

                            else
                            {
                                bool moveLeft = CheckIfPlayerCanMoveLeft(playerColumn, spellColumn);
                                if (moveLeft == true)
                                {
                                    playerColumn -= 1;
                                }

                                else
                                {
                                    switch (spell)
                                    {
                                        case "Cloud":
                                            if (player > 0)
                                            {
                                                player -= 3500;
                                                if (player <= 0)
                                                {
                                                    killingSpell = "Plague Cloud";
                                                    if (Heigan <= 0 || player <= 0)
                                                    {
                                                        if (Heigan > 0) { Console.WriteLine($"Heigan: {Heigan:0.00}"); }
                                                        else { Console.WriteLine("Heigan: Defeated!"); }

                                                        if (player > 0) { Console.WriteLine($"Player: {player}"); }
                                                        else { Console.WriteLine($"Player: Killed by {killingSpell}"); }

                                                        Console.WriteLine($"Final position: {spellRow}, {spellColumn}");

                                                        break;
                                                    }
                                                }
                                            }
                                            cloudAftershock = true;
                                            break;

                                        case "Eruption":
                                            if (player > 0)
                                            {
                                                player -= 6000;
                                                if (player <= 0)
                                                {
                                                    killingSpell = "Eruption";
                                                    if (Heigan <= 0 || player <= 0)
                                                    {
                                                        if (Heigan > 0) { Console.WriteLine($"Heigan: {Heigan:0.00}"); }
                                                        else { Console.WriteLine("Heigan: Defeated!"); }

                                                        if (player > 0) { Console.WriteLine($"Player: {player}"); }
                                                        else { Console.WriteLine($"Player: Killed by {killingSpell}"); }

                                                        Console.WriteLine($"Final position: {spellRow}, {spellColumn}");

                                                        break;
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                            }

                        }
                    }

                }
            }
            Console.WriteLine();
        }

        private static bool CheckIfPlayerCanMoveLeft(int playerColumn, int spellColumn)
        {
            bool moveLeft = true;
            if ((playerColumn - 1 < 0) || (playerColumn - 1 >= spellColumn - 1 && playerColumn - 1 <= spellColumn + 1))
            {
                moveLeft = false;
            }

            return moveLeft;
        }

        private static bool CheckIfPlayerCanMoveDown(int playerRow, int spellRow)
        {
            bool moveDown = true;

            if ((playerRow + 1 > 14) || (playerRow + 1 >= spellRow - 1 && playerRow + 1 <= spellRow + 1))
            {
                moveDown = false;
            }

            return moveDown;
        }

        private static bool CheckIfPlayerCanMoveRight(int playerColumn, int spellColumn)
        {
            bool moveRight = true;
            if ((playerColumn + 1 > 14) || (playerColumn + 1 >= spellColumn - 1 && playerColumn + 1 <= spellColumn + 1))
            {
                moveRight = false;
            }

            return moveRight;
        }

        private static bool CheckIfPlayerCanMoveUp(int playerRow, int spellRow)
        {
            bool moveUp = true;

            if ((playerRow - 1 < 0) || (playerRow - 1 >= spellRow - 1 && playerRow - 1 <= spellRow + 1))
            {
                moveUp = false;
            }

            return moveUp;
        }

        private static bool CheckIfPlayerIsWithinTheDamagedArea(int playerRow, int playerColumn, int spellRow, int spellColumn)
        {
            bool PlayerIsWithinDamagedArea = false;

            if ((playerRow >= spellRow - 1) && (playerRow <= spellRow + 1)
                && (playerColumn >= spellColumn - 1) && (playerColumn <= spellColumn + 1))
            {
                PlayerIsWithinDamagedArea = true;
            }

            return PlayerIsWithinDamagedArea;
        }
    }
}
