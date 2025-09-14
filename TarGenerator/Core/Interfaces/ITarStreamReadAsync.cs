using System.Threading.Tasks;

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
namespace TarGenerator.Core.Interfaces
{
    public interface ITarStreamReadAsync
    {
        ValueTask<int> ReadAsync(byte[] buffer, int offset, int count);
    }
}
#endif