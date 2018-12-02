
using System;
using System.Linq;
using System.Text;

public class Clinic
{
    private Pet[] pets;

    public Clinic(string name, int numberOfRooms)
    {
        this.ValidateRoomCount(numberOfRooms);

        this.Name = name;
        this.pets = new Pet[numberOfRooms];
    }

    public bool HasEmptyRooms => this.pets.Any(r => r == null);

    public string Name { get; }

    public int StartingRoom => this.pets.Length / 2;

    public bool Add(Pet pet)
    {
        bool result = false;

        int currentRoom = this.StartingRoom;

        for (int i = 0; i < this.pets.Length; i++)
        {
            if (i % 2 != 0)
                currentRoom -= i;
            else
                currentRoom += i;

            if (this.pets[currentRoom] == null)
            {
                this.pets[currentRoom] = pet;
                result = true;
                break;
            }
        }

        return result;
    }

    public bool Release()
    {
        int currentRoom = this.StartingRoom;

        for (int i = currentRoom; i < this.pets.Length; i++)
        {
            if (this.pets[i] != null)
            {
                this.pets[i] = null;
                return true;
            }
        }

        for (int i = 0; i < currentRoom; i++)
        {
            if (this.pets[i] != null)
            {
                this.pets[i] = null;
                return true;
            }
        }

        return false;
    }

    public string Print(int index)
    {
        return this.pets[index - 1]?.ToString() ?? "Room empty";
    }

    public string PrintAll()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < this.pets.Length; i++)
        {
            sb.AppendLine(this.pets[i]?.ToString() ?? "Room empty");
        }

        string result = sb.ToString().Trim();

        return result;
    }

    private void ValidateRoomCount(int numberOfRooms)
    {
        if (numberOfRooms % 2 == 0)
            throw new ArgumentException("Invalid Operation!");
    }
}

