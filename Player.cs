namespace Lab7;

public class Player
{
    public string Name { get; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Gold { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }

    public Player(string name, int maxHealth, int gold)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Gold = gold;
        Level = 1;
        Experience = 0;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            System.Console.WriteLine("Damage must be positive");
            return;
        }
        
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }
    }
    
    public void Heal(int amount)
    {
        if (amount <= 0)
        {
            System.Console.WriteLine("Healing amount must be positive");
            return;
        }
        
        Health += amount;

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void AddExperience(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        Experience += amount;

        while (Experience >= Level * 100)
        {
            Experience -= Level * 100;
            Level++;
            MaxHealth += 10;
            Health = MaxHealth;

            System.Console.WriteLine("Level up! New Level: " + Level);
            System.Console.WriteLine("Maximum health increased to " + MaxHealth);
        }
    }

    public void AddGold(int amount)
    {
        if (amount > 0)
        {
            Gold += amount;
        }
    }

    public bool SpendGold(int amount)
    {
        if (amount <= 0 || Gold < amount)
        {
            return false;
        }

        Gold -= amount;
        return true;
    }
}
