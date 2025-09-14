using System.Text;

namespace TarGenerator.Tools;

public class TarTools
{
    public static Encoding Ascii { get; } = Encoding.GetEncoding("ASCII");

    public static long FromUnixTimeSeconds(long readOctal)
    {
        throw new System.NotImplementedException();
    }
}