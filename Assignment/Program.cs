//This assignment is done by Jaspreet Singh A00274134 and Nidhi Ramteke A00250309 

using System;

// Define the InventoryItem class
public class InventoryItem
{
    public double Weight { get; }
    public double Volume { get; }

    public InventoryItem(double weight, double volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

// Define the derived classes for each item
public class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05) { }
}

public class Bow : InventoryItem
{
    public Bow() : base(1.0, 4.0) { }
}

public class Rope : InventoryItem
{
    public Rope() : base(1.0, 1.5) { }
}

public class Water : InventoryItem
{
    public Water() : base(2.0, 3.0) { }
}

public class Food : InventoryItem
{
    public Food() : base(1.0, 0.5) { }
}

public class Sword : InventoryItem
{
    public Sword() : base(5.0, 3.0) { }
}

// Define the Pack class
public class Pack
{
    private readonly int maxItems;
    private readonly double maxWeight;
    private readonly double maxVolume;
    private InventoryItem[] items;
    private int itemCount;
    private double totalWeight;
    private double totalVolume;

    public Pack(int maxItems, double maxWeight, double maxVolume)
    {
        this.maxItems = maxItems;
        this.maxWeight = maxWeight;
        this.maxVolume = maxVolume;
        items = new InventoryItem[maxItems];
    }

    public bool Add(InventoryItem item)
    {
        if (itemCount == maxItems || totalWeight + item.Weight > maxWeight || totalVolume + item.Volume > maxVolume)
        {
            return false;
        }

        items[itemCount++] = item;
        totalWeight += item.Weight;
        totalVolume += item.Volume;

        return true;
    }

    public int ItemCount
    {
        get { return itemCount; }
    }

    public double TotalWeight
    {
        get { return totalWeight; }
    }

    public double TotalVolume
    {
        get { return totalVolume; }
    }

    public int MaxItems
    {
        get { return maxItems; }
    }

    public double MaxWeight
    {
        get { return maxWeight; }
    }

    public double MaxVolume
    {
        get { return maxVolume; }
    }
}

// Define the program class
public class Program
{
    public static void Main()
    {
        Pack pack = new Pack(10 , 30 , 20 );

        while (true)
        {
            Console.WriteLine($"Pack is currently at {pack.ItemCount}/{pack.MaxItems} items, {pack.TotalWeight}/{pack.MaxWeight} weight, and {pack.TotalVolume}/{pack.MaxVolume} volume. What do you want to add?");
            Console.WriteLine("1 - Arrow");
            Console.WriteLine("2 - Bow");
            Console.WriteLine("3 - Rope");
            Console.WriteLine("4 - Water");
            Console.WriteLine("5 - Food");
            Console.WriteLine("6 - Sword");
            Console.WriteLine("7 - Gather your pack and venture forth");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 7)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            InventoryItem item;
            switch (choice)
            {
                case 1: // Arrow
                    if (pack.Add(new Arrow()))
                    {
                        Console.WriteLine("Added Arrow to pack.");
                    }
                    else
                    {
                        Console.WriteLine("Pack is full or too heavy/big to add Arrow.");
                    }
                    break;
                case 2: // Bow
                    if (pack.Add(new Bow()))
                    {
                        Console.WriteLine("Added Bow to pack.");
                    }
                    else
                    {
                        Console.WriteLine("Pack is full or too heavy/big to add Bow.");
                    }
                    break;
                case 3: // Rope
                    if (pack.Add(new Rope()))
                    {
                        Console.WriteLine("Added Rope to pack.");
                    }
                    else
                    {
                        Console.WriteLine("Pack is full or too heavy/big to add Rope.");
                    }
                    break;
                case 4: // Water
                    if (pack.Add(new Water()))
                    {
                        Console.WriteLine("Added Water to pack.");
                    }
                    else
                    {
                        Console.WriteLine("Pack is full or too heavy/big to add Water.");
                    }
                    break;
                case 5: // Food
                    if (pack.Add(new Food()))
                    {
                        Console.WriteLine("Added Food to pack.");
                    }
                    else
                    {
                        Console.WriteLine("Pack is full or too heavy/big to add Food.");
                    }
                    break;
                case 6: // Sword
                    if (pack.Add(new Sword()))
                    {
                        Console.WriteLine("Added Sword to pack.");
                    }
                    else
                    {
                        Console.WriteLine("Pack is full or too heavy/big to add Sword.");
                    }
                    break;
                case 7: // Gather your pack and venture forth
                    Console.WriteLine("Ventureing Forth.");
                    break;
                default:
                    Console.WriteLine("Could not fit this item into the pack.");
                    break;
            }

        }
    }
}
