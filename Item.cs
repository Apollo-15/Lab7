namespace Lab7;

public class Item
{
    public string Name { get; set; }
    public int HealAmount { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public Item(string name, int healAmount, int price, int quantity)
    {
        Name = name;
        HealAmount = healAmount;
        Price = price;
        Quantity = quantity;
    }

    public bool Use(Player player)
    {
        if (Quantity <= 0)
        {
            System.Console.WriteLine("You don't have this item.");
            return false;
        }

        if (!player.IsAlive())
        {
            System.Console.WriteLine("A defeated player can't use items.");
            return false;
        }

        if (player.Health >= player.MaxHealth)
        {
            System.Console.WriteLine("Your heath is already full.");
            return false;
        }

        player.Heal(HealAmount);
        Quantity--;
        
        System.Console.WriteLine($"{player.Name} used {Name} and restored {HealAmount} hp");

        return true;
    }
}