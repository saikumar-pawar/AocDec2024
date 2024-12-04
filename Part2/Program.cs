
List<List<int>> reports = GetReports();
int noOfSafeReports = SafeReportsCount(reports);
Console.WriteLine(noOfSafeReports);

static List<List<int>> GetReports()
{
    List<List<int>> reports = new List<List<int>>()
    { 
        new List<int> { 7, 6, 4, 2, 1 },
        new List<int> { 1, 2, 7, 8, 9 },
        new List<int> { 9, 7, 6, 2, 1 },
        new List<int> { 1, 3, 2, 4, 5 },
        new List<int> { 8, 6, 4, 4, 1 },
        new List<int> { 1, 3, 6, 7, 9 }
    };

    return reports;
}

static int SafeReportsCount(List<List<int>> reports)
{
    int noOfSafeReports = 0;

    if (reports != null && reports.Count > 0)
    {
        int noOfReports = reports.Count;

        for (int i = 0; i < noOfReports; i++)
        {
            List<int> report = reports[i];

            if (report != null)
            {
                int noOfLevels = report.Count;

                if (noOfLevels == 1)
                {
                    noOfSafeReports++;
                }
                else
                {
                    bool isIncreasing = report[1] > report[0] ? true : false;
                    bool isDecreasing = !isIncreasing;

                    for (int j = 1; j < noOfLevels; j++)
                    {
                        int prevElement = report[j - 1];
                        int curElement = report[j];
                        int absoluteDifference = Math.Abs(prevElement - curElement);

                        if (absoluteDifference < 1 || absoluteDifference > 3)
                        {
                            break;
                        }
                        else if ((isIncreasing && curElement < prevElement) || (isDecreasing && curElement > prevElement))
                        {
                            break;
                        }
                        else if ((isIncreasing && curElement > prevElement) || (isDecreasing && curElement < prevElement))
                        {
                            if (j == noOfLevels - 1)
                            {
                                noOfSafeReports++;
                            }
                        }
                    }
                }
            }
        }
    }

    return noOfSafeReports;
}
