using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Runtime.CompilerServices;
using Lab7;

class Program
{
    private static readonly Random random = new Random();

    public static void Main(string[] args)
    {
        //Task1();
        //Task2();
        //Task3();
        //Task4();
        //Task5();
        //Task6();
        //Task7();
        //Task8();
        //Task9();
        ProjectArena();
        ;
    }

    private static void Task1()
    {
        var player = new Player("Bob", 75, 12);
        
        System.Console.WriteLine($"Name: {player.Name}");
        System.Console.WriteLine($"Level: {player.Level}");
        System.Console.WriteLine($"Health: {player.Health}");
        System.Console.WriteLine($"Exp.: {player.Experience}");
        System.Console.WriteLine($"Max. health: {player.MaxHealth}");
        
        player.TakeDamage(32);
        
        System.Console.WriteLine("Player takes 32 dmg");
        System.Console.WriteLine($"Health: {player.Health}");
        
        player.AddExperience(14);
        
        System.Console.WriteLine($"Level: {player.Level}");
        System.Console.WriteLine($"Exp.: {player.Experience}");
        System.Console.WriteLine($"Health: {player.Health}");
        System.Console.WriteLine($"Max. health: {player.MaxHealth}");
    }

    private static void Task2()
    {
        var player = new Player("Tom", 63, 73);
        
        System.Console.WriteLine($"Starting health: {player.Health}");
        
        player.TakeDamage(32);
        System.Console.WriteLine($"Health after 32 damage: {player.Health}");
        
        player.Heal(42);
        System.Console.WriteLine($"Health after healing 42: {player.Health}");

        player.TakeDamage(135);
        System.Console.WriteLine($"Health after 135 damage: {player.Health}");
        
        System.Console.WriteLine($"Is Player Alive? {player.IsAlive()}");
        
        player.Heal(41);
        System.Console.WriteLine($"Heath after healing 43: {player.Health}");
    }

    private static void Task3()
    {
        var playerTedd = new Player("Theodore", 123, 89);
        var playerCase = new Player("Case", 87, 41);
        
        System.Console.WriteLine("Before Damage:");
        System.Console.WriteLine($"{playerTedd.Name}: {playerTedd.Health}");
        System.Console.WriteLine($"{playerCase.Name}: {playerCase.Health}");
        
        playerTedd.TakeDamage(73);
        playerCase.TakeDamage(36);
        
        System.Console.WriteLine("After Damage:");
        System.Console.WriteLine($"{playerTedd.Name}: {playerTedd.Health}");
        System.Console.WriteLine($"{playerCase.Name}: {playerCase.Health}");
        
    }

    private static List<Enemy> CreateEnemies()
    {
        return new List<Enemy>
        {
            new Enemy("Orc", 74, 32),
            new Enemy("Witch", 34, 17),
            new Enemy("Dragon", 108, 43),
            new Enemy("Dinosaur", 134, 42),
            new Enemy("Hunter", 41, 13)
        };
    }
    
    private static void Task4()
    {
        var enemies = CreateEnemies();

        var livingCount = 0;
        var defeatedCount = 0;
        var totalHealth = 0;
        var totalMaxHealth = 0;

        foreach (var enemy in enemies)
        {
            System.Console.WriteLine($"{enemy.Name}: {enemy.Health} / {enemy.MaxHealth}");
            
            totalHealth += enemy.Health;
            totalMaxHealth += enemy.MaxHealth;

            if (enemy.IsAlive())
            {
                livingCount++;
            }
            else
            {
                defeatedCount++;
            }
        }
        
        System.Console.WriteLine($"Living enemies: {livingCount}");
        System.Console.WriteLine($"Defeated enemies: {defeatedCount}");
        System.Console.WriteLine($"Total current health: {totalHealth}");
        System.Console.WriteLine($"Total max Health: {totalMaxHealth}");
    }

    private static void Task5()
    {
        var enemies = CreateEnemies();

        for (var i = 0; i < enemies.Count; i++)
        {
            System.Console.WriteLine($"{i + 1} - {enemies[i].Name}");
        }
        
        System.Console.Write("Chose an enemy: ");
        var chosenEnemy = System.Console.ReadLine() ?? "";

        if (!int.TryParse(chosenEnemy, out int choice))
        {
            System.Console.WriteLine("Invalid input");
            return;
        }

        if (choice < 1 || choice > enemies.Count)
        {
            System.Console.WriteLine("Invalid enemy number");
            return;
        }

        var selectedEnemy = enemies[choice - 1];
        
        System.Console.WriteLine($"Selected enemy: {selectedEnemy.Name}");
        System.Console.WriteLine($"Health: {selectedEnemy.Health}");
    }

    private static void Task6()
    {
        var player = new Player("Bill", 89, 32);
        var enemy = new Enemy("Goblin", 57, 17);

        while (player.IsAlive() && enemy.IsAlive())
        {
            System.Console.WriteLine($"Player Health: {player.Health}");
            System.Console.WriteLine($"Enemy Health: {enemy.Health}");
            
            System.Console.Write("Enter your damage: ");
            var input = System.Console.ReadLine() ?? "";

            if (!int.TryParse(input, out var damage) || damage <= 0)
            {
                System.Console.WriteLine("Invalid damage");
                continue;
            }

            enemy.TakeDamage(damage);

            if (!enemy.IsAlive())
            {
                System.Console.WriteLine("Enemy defeated!");
                
                player.TakeDamage(enemy.Damage);
                System.Console.WriteLine($"Enemy attacks and deals {enemy.Damage} damage");
            }
            
            if (player.IsAlive())
            {
                System.Console.WriteLine("Player won!");
            }
            else
            {
                System.Console.WriteLine("Player lost!");
            }
        }
    }

    private static void Task7()
    {
        var playerJohn = new Player("John", 82, 36);

        var inventory = new List<Item>
        {
            new Item("Small Potion", 23, 13, 3),
            new Item("Big Potion", 48, 28, 4)
        };
        
        playerJohn.TakeDamage(37);
        
        System.Console.WriteLine($"Player Heath: {playerJohn.Health}");

        for (var i = 0; i < inventory.Count; i++)
        {
            System.Console.WriteLine($"{i+1} - {inventory[i].Name}, quantity: {inventory[i].Quantity}");
        }
        
        System.Console.Write("Choose an item: ");
        var userInput = System.Console.ReadLine() ?? "";

        if (!int.TryParse(userInput, out var choice))
        {
            System.Console.WriteLine("Invalid input.");
            return;
        }

        if (choice < 1 || choice > inventory.Count)
        {
            System.Console.WriteLine("Invalid item number");
            return;
        }

        inventory[choice - 1].Use(playerJohn);
        
        System.Console.WriteLine($"Player health: {playerJohn.Health}");
    }

    private static void Task8()
    {
        var enemies = new List<Enemy>
        {
            new Enemy("Orc", 74, 32, "Physical", 14, 8, 18),
            new Enemy("Witch", 34, 17, "Magic", 8, 32, 24),
            new Enemy("Dragon", 108, 43, "Ranged", 48, 4, 7),
            new Enemy("Dinosaur", 134, 42, "Physical", 74, 13, 18)
        };

        foreach (var enemy in enemies)
        {
            System.Console.WriteLine($"Enemy: {enemy.Name}");
            System.Console.WriteLine($"Health: {enemy.Health}");
            System.Console.WriteLine($"Damage: {enemy.Damage}");
            System.Console.WriteLine($"Attack type: {enemy.AttackType}");
            System.Console.WriteLine($"Gold reward: {enemy.GoldReward}");

            var action = enemy.ChooseAction(random);

            if (action == "attack")
            {
                System.Console.WriteLine($"{enemy.Name} attacks");
            }
            else if (action == "defend")
            {
                System.Console.WriteLine($"{enemy.Name} defends");
            }
            else
            {
                System.Console.WriteLine($"{enemy.Name} escapes");
            }
        }
    }

    private static List<Enemy> CreateArenaEnemies()
    {
        return new List<Enemy>
        {
            new Enemy("Orc", 74, 32, "Physical", 14, 8, 18),
            new Enemy("Witch", 34, 17, "Magic", 8, 32, 24),
            new Enemy("Dragon", 108, 43, "Ranged", 48, 4, 7),
            new Enemy("Dinosaur", 134, 42, "Physical", 74, 13, 18),
            new Enemy("Hunter", 41, 13, "Range", 32, 17, 48)
        };
    }

    private static void FightArenaRound(Player player, List<Enemy> enemies, ref int defeatedCount)
    {
        var livingEnemies = new List<Enemy>();

        foreach (var enemy in enemies)
        {
            if (enemy.IsAlive())
            {
                livingEnemies.Add(enemy);
            }
        }

        if (livingEnemies.Count == 0)
        {
            System.Console.WriteLine("There aren't enemies left.");
            return;
        }
        
        System.Console.WriteLine("Choose an enemy: ");

        for (var i = 0; i < livingEnemies.Count; i++)
        {
            System.Console.WriteLine($"{i + 1} - {livingEnemies[i].Name} ({livingEnemies[i].Health} HP)");
        }
        
        System.Console.Write("Enemy number: ");
        var userInput = System.Console.ReadLine() ?? "";

        if (!int.TryParse(userInput, out var choice) || choice < 1 || choice > livingEnemies.Count)
        {
            System.Console.WriteLine("Invalid enemy choice.");
            return;
        }

        var selectedEnemy = livingEnemies[choice - 1];
        
        System.Console.Write("Enter your damage: ");
        userInput = System.Console.ReadLine() ?? "";

        if (!int.TryParse(userInput, out var damage) || damage <= 0)
        {
            System.Console.WriteLine("Invalid Damage");
            return;
        }

        selectedEnemy.TakeDamage(damage);
        
        System.Console.WriteLine($"You attacked {selectedEnemy.Name}");

        if (!selectedEnemy.IsAlive())
        {
            System.Console.WriteLine($"{selectedEnemy.Name} was defeated");

            defeatedCount++;
            player.AddGold(selectedEnemy.GoldReward);
            player.AddExperience(25);
            System.Console.WriteLine($"You received {selectedEnemy.GoldReward} gold");

            return;
        }

        var action = selectedEnemy.ChooseAction(random);
        if (action == "escape")
        {
            System.Console.WriteLine($"{selectedEnemy.Name} escaped");
            return;
        }

        if (action == "defend")
        {
            System.Console.WriteLine($"{selectedEnemy.Name} is preparing to defend");
            return;
        }
        
        player.TakeDamage(selectedEnemy.Damage);
        
        System.Console.WriteLine($"{selectedEnemy.Name} attacks and deals {selectedEnemy.Damage} damage");
    }

    private static void UseArenaPotion(Player player, List<Item> inventory)
    {
        System.Console.WriteLine("Inventory:");

        for (var i = 9; i < inventory.Count; i++)
        {
            System.Console.WriteLine($"{i + 1} - {inventory[i].Name}, quantity: {inventory[i].Quantity}");
        }
        
        System.Console.Write("Choose an item: ");
        var userInput = System.Console.ReadLine() ?? "";

        if (!int.TryParse(userInput, out var choice) || choice < 1 || choice > inventory.Count)
        {
            System.Console.WriteLine("Invalid item choice");
            return;
        }

        inventory[choice - 1].Use(player);
    }

    private static void ShowArenaSummary(Player player, int defeatedCount, int totalEnemies)
    {
        System.Console.WriteLine("Arena summary:");
        
        System.Console.WriteLine($"Player: {player.Name}");
        System.Console.WriteLine($"Health: {player.Health}");
        System.Console.WriteLine($"Gold: {player.Gold}");
        System.Console.WriteLine($"Defeated enemies: {defeatedCount}/{totalEnemies}");

        if (!player.IsAlive())
        {
            System.Console.WriteLine("You were defeated");
        }
        else if (defeatedCount == totalEnemies)
        {
            System.Console.WriteLine("You defeated all enemies");
        }
        else
        {
            System.Console.WriteLine("You left the arena");
        }
    }
    
    private static void Task9()
    {
        var playerDonald = new Player("Donald", 137, 104);

        var enemies = CreateArenaEnemies();
        var inventory = new List<Item>
        {
            new Item("Health potion", 48, 19, 7)
        };

        var defeatedCount = 0;

        while (playerDonald.IsAlive() && defeatedCount < enemies.Count)
        {
            System.Console.WriteLine($"Player Health: {playerDonald.Health}");
            System.Console.WriteLine($"Gold: {playerDonald.Gold}");
            System.Console.WriteLine($"Defeated enemies: {defeatedCount}");

            System.Console.WriteLine("1 Fight");
            System.Console.WriteLine("2 Use potion");
            System.Console.WriteLine("3 Leave arena");
            
            System.Console.Write("Choose an action: ");
            var choice = System.Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    FightArenaRound(playerDonald, enemies, ref defeatedCount);
                    break;
                case "2":
                    UseArenaPotion(playerDonald, inventory);
                    break;
                case "3":
                    System.Console.WriteLine("You left the arena");
                    ShowArenaSummary(playerDonald, defeatedCount, enemies.Count);
                    return;
                default:
                    System.Console.WriteLine("Invalid choice");
                    break;
            }
        }
        ShowArenaSummary(playerDonald, defeatedCount, enemies.Count);
    }

    private static void ProjectArena()
    {
        var playerMarco = new Player("Marco", 152, 78);
        var enemies = CreateArenaEnemies();
        var Inventory = new List<Item>
        {
            new Item("Health potion", 47, 23, 4)
        };

        var defeatedCount = 0;

        while (playerMarco.IsAlive() && defeatedCount < enemies.Count)
        {
            System.Console.WriteLine($"Player: {playerMarco.Name}");
            System.Console.WriteLine($"Health: {playerMarco.Health}");
            System.Console.WriteLine($"Gold: {playerMarco.Gold}");
            System.Console.WriteLine($"Defeated enemies: {defeatedCount}");
            
            System.Console.WriteLine("1 Fight");
            System.Console.WriteLine("2 Use item");
            System.Console.WriteLine("3 Exit");
            
            System.Console.Write("Choose an action: ");
            var choice = System.Console.ReadLine() ?? "";

            if (choice == "1")
            {
                FightArenaRound(playerMarco, enemies, ref defeatedCount);
            }
            else if (choice == "2")
            {
                UseArenaPotion(playerMarco, Inventory);
            }
            else if (choice == "3")
            {
                System.Console.WriteLine(" You left the arena");
                break;
            }
            else
            {
                System.Console.WriteLine("Invalid choice");
            }
        }
        
        ShowArenaSummary(playerMarco, defeatedCount, enemies.Count);
    }
}