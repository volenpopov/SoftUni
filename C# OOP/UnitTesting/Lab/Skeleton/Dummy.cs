using System;

public class Dummy : ITarget
{
    private int health;

    public Dummy(int health, int Experience)
    {
        this.health = health;
        this.Experience = Experience;
    }

    public int Health 
    {
        get { return this.health; }
    }

    public int Experience { get; }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.Experience;
    }

    public bool IsDead()
    {
        return this.health <= 0;
    }
}
