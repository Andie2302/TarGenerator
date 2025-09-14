using System.Threading.Tasks;

namespace TarGenerator.Core.Interfaces;

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
public interface ITarStreamWriteAsync
{
    ValueTask WriteAsync(byte[] buffer, int offset, int count);
    ValueTask FlushAsync();
}
#endif