// 2020, Killerdani, https://github.com/killerdani24
Console.WriteLine("Manually Write File Location? Or Else The Script Will Automatically Load Files dir1.txt and dir2.txt" + "(Y:yes | N:no)");
string answ = Console.ReadLine();
answ = answ.ToLower();

bool MANUAL = false;
if (answ == "y")
	MANUAL = true;

#if MANUAL
Console.WriteLine(@"Please type in the file location and/or file name. WITHOUT Quotation marks (")" + "\n" + 
				  @"Example: List\\DirLS1.txt or List/DirLS1.txt");
string dir1 = Console.ReadLine();

Console.WriteLine("Please Input Second File: ");
string dir2 = Console.ReadLine();

string[] dir1List = File.ReadAllLines(dir1);
string[] dir2List = File.ReadAllLines(dir2);
#endif

string[] dir1List = File.ReadAllLines(".\\dir1.txt");
string[] dir2List = File.ReadAllLines(".\\dir2.txt");

string[] biggerArray  = new string[dir2List.Length > dir1List.Length ? dir2List.Length : dir1List.Length];
string[] smallerArray = new string[dir2List.Length > dir1List.Length ? dir1List.Length : dir2List.Length];

bool foundSame = false;

if (dir2List.Length > dir1List.Length)
{
    dir2List.CopyTo(biggerArray, 0);
    dir1List.CopyTo(smallerArray, 0);
}
else
{
    dir1List.CopyTo(biggerArray, 0);
    dir2List.CopyTo(smallerArray, 0);
}

// Write output to Diff.txt
using (var sw = new StreamWriter(".\\Diff.txt", flase, Encoding.Unicode))
{
    // Find the unique files in the bigger array
    sw.WriteLine("Unique Files In Bigger Directory: ");
    for (int i = 0; i < biggerArray.Length; i++)
    {
        foundSame = false;
        for (int j = 0; j < smallerArray.Length; j++)
        {
            if (biggerArray[i] == smallerArray[j])
            {
                foundSame = true;
                break;
            }
            else
                continue;
        }
        if (!foundSame)
            sw.WriteLine($"\t{biggerArray[i]}");
    }

    // Find the unique file in the smaller array
    sw.WriteLine("Unique Files In Smaller Array: ");
    for (int i = 0; i < smallerArray.Length; i++)
    {
        foundSame = false;
        for (int j = 0; j < biggerArray.Length; j++)
        {
            if (smallerArray[i] == biggerArray[j])
            {
                foundSame = true;
                break;
            }
            else
                continue;
        }
        if (!foundSame)
            sw.WriteLine($"\t{smallerArray[i]}");
    }
}