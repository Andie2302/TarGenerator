using System.Threading.Tasks;
using TarGenerator.Core.Interfaces;

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
namespace TarGenerator.Core
{
    public partial class TarWriter : ITarStreamWriteAsync
    {
        public ValueTask WriteAsync(byte[] buffer, int offset, int count) =>
            new(BaseStream.WriteAsync(buffer, offset, count));

        public ValueTask FlushAsync() => new(BaseStream.FlushAsync());
    }
}
#endif