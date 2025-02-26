List<int> dungeonMap = new List<int> ();
for (int i = 0; i < 9; i++)
{
    int random = new Random().Next(1, 5);
    dungeonMap.Add(random);
}

string diff = "";
while (diff != "1" && diff != "2" && diff != "3")
{
    Console.WriteLine("Choose difficulty from 1 to 3!");
    diff = Console.ReadLine();
}

int diffn = int.Parse(diff);

int hp = 100, posions = 3, gold = 0, arrows = 5;
bool bow = true, sword = true;
List<int> inventory = new List<int>();

for (int i = 0; i < 9; i++)
{
    Console.WriteLine ($"------------------------\nRoom {i+1}");
    switch (dungeonMap[i])
    {
        case 1:
            Console.WriteLine("Monster!");
            monsterFight();
            break;
        case 2:
            Console.WriteLine("Trap!");
            hp -= new Random().Next(10, 20);
            break;
        case 3:
            Console.WriteLine("Chest!");
            chest();
            break;
        case 4:
            Console.WriteLine("Trader!");
            trader();
            break;
        case 5:
            Console.WriteLine("Nothing!");
            break;
    }
    if (hp <= 0)
    {
        Console.WriteLine("You died!");
        break;
    } else
    {
        Console.WriteLine("----------------------------------\nBoss fight!");
        monsterFight(true);
    }
}


void monsterFight(bool boss = false)
{
    int multiplier = boss ? 2 : 1;
    int monsterHp = new Random().Next(20, 50) * multiplier * diffn;

    while (monsterHp > 0 && hp > 0)
    {
        Console.WriteLine("Enter 1 to use sword or 2 to use bow");
        string val = Console.ReadLine();
        switch (val)
        {
            case "1":
                monsterHp -= new Random().Next(10, 20);
                break;
            case "2":
                if (arrows == 0)
                {
                    Console.WriteLine("No arrows left!");
                    continue;
                }
                monsterHp -= new Random().Next(5, 15);
                arrows--;
                break;
            default:
                Console.WriteLine("Enter 1 or 2!");
                continue;
        }
        hp -= new Random().Next(5, 15);
        Console.WriteLine($"Monster has now {monsterHp} hp");
        Console.WriteLine($"You have now {hp} hp");
    }
}

async void chest ()
{
    int num1 = new Random().Next(10, 20);
    int num2 = new Random().Next(10, 20);
    Console.WriteLine($"Enter answer: {num1} + {num2}");
    string ans = "";
    ans = Console.ReadLine();
    bool good = false;
    while (!good)
    {
        try
        {
            int ansn = int.Parse(ans);
            if (ansn == num1 + num2)
            {
                good = true;
            }
        }
        catch (Exception)
        {

            throw;
        }
        if (!good)
        {
            Console.WriteLine("Another try!");
            ans = Console.ReadLine();
        }
    }
    switch (new Random().Next(1, 3))
    {
        case 1:
            posions++;
            Console.WriteLine($"You got a posions! YOu have now {posions} posions");
            break;
        case 2:
            gold += 10;
            Console.WriteLine($"You got 10 gold! YOu have now {gold} gold");
            break;
        case 3:
            arrows += 5;
            Console.WriteLine($"You got 5 arrows! YOu have now {arrows} arrows");
            break;
        default:
            break;
    }
}


void trader()
{
    Console.WriteLine("Do you wanna get posions for 30 gold? (enter y or n)");
    string val = "";
    while (val != "y" && val != "n")
    {
        val = Console.ReadLine();
        if (val != "y" && val != "n")
        {
            Console.WriteLine("Do you wanna get posions for 30 gold? (enter y or n)");
        }
    }
    if (val == "y")
    {
        if (gold >= 30)
        {
            if (posions == 5)
            {
                Console.WriteLine("You already have 5 posions!");
            } else
            {
                posions++;
                gold -= 30;
                Console.WriteLine("Deal!");
            }
        } else
        {
            Console.WriteLine("YOu do not have 30 gold!");
        }
    } else
    {
        Console.WriteLine("Okay!");
    }
    Console.WriteLine($"You have now {posions} posions and {gold} gold");
}