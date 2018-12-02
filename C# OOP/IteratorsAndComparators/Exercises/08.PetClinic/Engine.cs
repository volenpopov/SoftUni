
using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private List<Pet> pets;
    private List<Clinic> clinics;

    public Engine()
    {
        this.pets = new List<Pet>();
        this.clinics = new List<Clinic>();
    }

    public void Run()
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] args = Console.ReadLine().Split();
            string command = args[0];

            switch (command)
            {
                case "Create":
                    string elementToCreate = args[1];

                    if (elementToCreate == "Pet")
                    {
                        Pet pet = new Pet(args[2], int.Parse(args[3]), args[4]);
                        this.pets.Add(pet);
                    }

                    else
                    {
                        try
                        {
                            Clinic clinic = new Clinic(args[2], int.Parse(args[3]));
                            this.clinics.Add(clinic);
                        }

                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;

                case "Add":
                    string petName = args[1];
                    string clinicName = args[2];

                    Pet petToAdd = this.pets.First(p => p.Name == petName);

                    Clinic currentClinic = this.clinics.First(c => c.Name == clinicName);
                    Console.WriteLine(currentClinic.Add(petToAdd));
                    break;

                case "Release":
                    string clinicReleaseName = args[1];
                    Clinic clinicRelease = this.clinics.First(c => c.Name == clinicReleaseName);
                    Console.WriteLine(clinicRelease.Release());
                    break;

                case "HasEmptyRooms":
                    string clinicCheckName = args[1];
                    Clinic clinicToCheck = this.clinics.First(c => c.Name == clinicCheckName);
                    Console.WriteLine(clinicToCheck.HasEmptyRooms);
                    break;

                case "Print":
                    if (args.Length == 3)
                    {
                        int roomIndex = int.Parse(args[2]);
                        Clinic clinicToPrint = this.clinics.First(c => c.Name == args[1]);
                        Console.WriteLine(clinicToPrint.Print(roomIndex));
                    }
                    else
                    {
                        Clinic clinicToPrint = this.clinics.First(c => c.Name == args[1]);
                        Console.WriteLine(clinicToPrint.PrintAll());
                    }
                    break;
            }
        }
    }
}

