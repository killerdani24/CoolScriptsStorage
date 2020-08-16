// 2020, Killerdani, https://github.com/killerdani24
byte[] ReadFile(string fileName)
{
	var fileInfo = new FileInfo(fileName);
	if (fileInfo.Length >= Math.Pow(2,32))
	{
		Console.WriteLine("ERROR: File bigger than 4.2 Gigabytes");
		Environment.Exit(0);
		return Array.Empty<byte>();
	}
	return File.ReadAllBytes(fileName);	
}

// https://stackoverflow.com/a/24031467
string CalculateMD5Hash(byte[] data)
{
	using (var md5 = System.Security.Cryptography.MD5.Create())
	{
		byte[] hashBytes = md5.ComputeHash(data);

		var sb = new StringBuilder();
		for (int i = 0; i < hashBytes.Length; i++)
			sb.Append(hashBytes[i].ToString("X2"));
		
		return sb.ToString();
	}
}

Console.WriteLine("Please Input Directory: ");
string directoryPath = Console.ReadLine();

Console.WriteLine("READING DIRECTORY... ");

var dirInfo = new DirectoryInfo(directoryPath);
DirectoryInfo[] subDirs = dirInfo.GetDirectories();

// Get all files (including sub-directories)
var filesList = new List<FileInfo>();
filesList.AddRange(dirInfo.GetFiles());   // Current dir
foreach (var subDir in subDirs)           // Sub-Dirs
	filesList.AddRange(subDir.GetFiles());

// Ignore Hash.txt
if (filesList.FindIndex(i => i.FullName == $"{directoryPath}\\Hashes.txt") > -1) // It exists
	filesList.RemoveAt(filesList.FindIndex(i => i.FullName == $"{directoryPath}\\Hashes.txt"));

// Calculate files MD5 hash and add to dictionary
var fileInfoHashKVPList = new List<KeyValuePair<FileInfo, string>>(filesList.Count);

for (int i = 0; i < filesList.Count; i++)
	fileInfoHashKVPList.Add(new KeyValuePair<FileInfo, string>(filesList[i], CalculateMD5Hash(ReadFile(filesList[i].FullName)))); // This became ugly really quickly :|

var toDelFiles = new List<FileInfo>(filesList.Count); // To Delete Files

// Search the dictionary for dupes
int uniqueHashIndex = 0;

using (var sw = new StreamWriter($"{directoryPath}\\Hashes.txt", false))
{
	sw.WriteLine("List Of Files And Their Hashes:");
	foreach (KeyValuePair<FileInfo, string> kvp in fileInfoHashKVPList)
		sw.WriteLine("\t" + kvp);
	
	sw.Write("\n");
	while (true)
	{
		if (uniqueHashIndex >= fileInfoHashKVPList.Count)
			break;

		for (int i = 0; i < fileInfoHashKVPList.Count; i++)
		{
			if (uniqueHashIndex != i && fileInfoHashKVPList[uniqueHashIndex].Value == fileInfoHashKVPList[i].Value)
			{
				sw.WriteLine($"Dupe For Index {uniqueHashIndex} ({fileInfoHashKVPList[uniqueHashIndex].Key.Name}) At Index {i} ({fileInfoHashKVPList[i].Key.Name})");
				toDelFiles.Add(fileInfoHashKVPList[i].Key);
				fileInfoHashKVPList.RemoveAt(i); // Remove unnecessary items from list
			}
		}
		uniqueHashIndex++;
	}
	sw.WriteLine("\nDuplicate Files To Delete:");
	foreach (var item in toDelFiles)
		sw.WriteLine($"\t{item}");
}

// Prompt to delete duplicate files
if (toDelFiles.Count > 0)
{
	Console.WriteLine("Found Duplicate Files: ");
	foreach (var dupeFile in toDelFiles)
		Console.WriteLine(dupeFile.Name);

	Console.WriteLine("Delete These Files?: Y (Yes to All) / N (No To All)");
	var answ = Console.ReadKey(true);
	
	if (answ.Key == ConsoleKey.Y)
	{
		Console.WriteLine("Deleting All Files");
		foreach (var dupeFile in toDelFiles)
			dupeFile.Delete();
	}
	else
		goto End;
}
else
	Console.WriteLine("No Duplicate Files Were Found");

End:
	Console.WriteLine("Extra Information Available In Hashes.txt At The Directory");
