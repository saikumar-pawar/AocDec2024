
string path = $@"{Directory.GetCurrentDirectory()}\input.txt";
Console.WriteLine(TotalDistance(path));

static long TotalDistance(string textFilePath)
{
    long totalDistance = 0;

    if (File.Exists(textFilePath))
    {
        string[] lines = File.ReadAllLines(textFilePath);
        int noOfLines = lines.Length;

        if (noOfLines > 0)
        {
            var arr1 = new int[noOfLines];
            var arr2 = new int[noOfLines];

            for (int i = 0; i < noOfLines; i++)
            {
                string[] values = lines[i].Split("   ");
                arr1[i] = int.Parse(values[0].Trim());
                arr2[i] = int.Parse(values[1].Trim());
            }

            Array.Sort(arr1);
            Array.Sort(arr2);

            for (int i = 0; i < noOfLines; i++)
            {
                totalDistance = totalDistance + Math.Abs(arr1[i] - arr2[i]);
            }
        }
    }

    return totalDistance;
}
