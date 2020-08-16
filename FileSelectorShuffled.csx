// 2020, Killerdani, https://github.com/killerdani24
Console.Write("Use The Current Directory As Input ? (Y: Yes | N: No): ");
string useCurrentDir = Console.ReadLine();
useCurrentDir = useCurrentDir.ToLower();

DirectoryInfo df;
string dirLoc;

if (useCurrentDir == "y")
    df = new DirectoryInfo(@".\");
if (useCurrentDir == "n")
{
    Console.WriteLine("Please Type In The Directory (Without Quotes)");
    dirLoc = Console.ReadLine();
    df = new DirectoryInfo(dirLoc);
}

DirectoryInfo[] subDirectories = df.GetDirectories();
List<FileInfo> fileInfo = new List<FileInfo>();

fileInfo.AddRange(df.GetFiles());
foreach (var subdirectory in subDirectories)
    fileInfo.AddRange(subdirectory.GetFiles());

var rnd = new Random(); // Seems like System.Random is faster than Lehmer Random!

FileInfo[] files = new FileInfo[fileInfo.Count];
FileInfo[] filesShuffled = new FileInfo[fileInfo.Count];
int j;

fileInfo.CopyTo(files);

for (int i = 0; i < files.Length; i++)
{
    filesShuffled[i] = files[i];
}

// First Shuffle
for (int i = 0; i <= files.Length - 2; i++)
{
    j = rnd.Next(i, files.Length);
    FileInfo t = filesShuffled[j];
    filesShuffled[j] = filesShuffled[i];
    filesShuffled[i] = t;
}

Console.Write("Re-shuffle the list for better \"Random-ness\" ? (Y: Yes | N: No): ");
string answ = Console.ReadLine();
answ = answ.ToLower();

if (answ == "y")
{
    // Reshuffle
    Console.WriteLine("Reshuffling ...");
    for (int j = 0; j < 5; j++)
    {
        for (int i = 0; i <= files.Length - 2; i++)
        {
            j = rnd.Next(i, files.Length);
            FileInfo t = filesShuffled[j];
            filesShuffled[j] = filesShuffled[i];
            filesShuffled[i] = t;
        }
    }
}

int count = 0;
while (true)
{
    Console.WriteLine("Press Any Enter To Advance Through List ");
    Console.ReadLine();
    Console.WriteLine("\t" + filesShuffled[count].Name + "\n");
    count++;	
}
