namespace Files.Comparator;

public class FileComparer : IEqualityComparer<FileInfo>
{
    // compare two given files
    public bool Equals(FileInfo? file1, FileInfo? file2)
    {
        const int bytesToRead = 32000;
        if (file1 == null || file2 == null) return false;
        if (!file1.Exists || !file2.Exists) return false;
        if (file1.Length != file2.Length) return false;
        
        var iterations = (int)Math.Ceiling((double)file1.Length / bytesToRead);

        using var fs1 = file1.OpenRead();
        using var fs2 = file2.OpenRead();
        byte[] one = new byte[bytesToRead];
        byte[] two = new byte[bytesToRead];

        for (int i = 0; i < iterations; i++)
        {
            fs1.Read(one, 0, bytesToRead);
            fs2.Read(two, 0, bytesToRead);

            if (BitConverter.ToInt64(one,0) != BitConverter.ToInt64(two,0))
                return false;
        }
        return true;
    }

    public int GetHashCode(FileInfo obj)
    {
        // don't need to read whole file as it's hash already been compared
        return 1;
    }

    private static string AsString(IEnumerable<byte> bytes)
    {
        return string.Join("", bytes.Select(b => b.ToString("x2")));
    }

}