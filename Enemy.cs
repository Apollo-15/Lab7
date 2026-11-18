namespace Lab7;

public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Damage { get; set; }
    public string AttackType { get; set; }
    public int GoldReward { get; set; }
    public int DefenseChance { get; set; }
    public int EscapeChance { get; set; }
    public bool IsDefending { get; set; }

    public Enemy(string name, int health, int damage, string attackType = "Normal", int goldReward = 10, 
        int defenseChance = 0, int escapeChance = 0)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        Damage = damage;
        AttackType = attackType;
        GoldReward = goldReward;
        DefenseChance = defenseChance;
        EscapeChance = escapeChance;
        IsDefending = false;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }

        if (IsDefending)
        {
            damage = damage / 2;
            IsDefending = false;
            System.Console.WriteLine($"{Name} blocked part of the damage!");
        }
        
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public string ChooseAction(System.Random random)
    {
        int chance = random.Next(1, 101);
        if (chance <= EscapeChance)
        {
            return "escape";
        }

        chance = random.Next(1, 101);

        if (chance <= DefenseChance)
        {
            IsDefending = true;
            return "defend";
        }

        return "attack";
    }
}
