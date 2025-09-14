using System.Threading.Tasks;
using TarGenerator.Core.Interfaces;
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
namespace TarGenerator.Core
{
    public partial class TarReader : ITarStreamReadAsync
    {
        public ValueTask<int> ReadAsync(byte[] buffer, int offset, int count) => new(BaseStream.ReadAsync(buffer, offset, count));
    }
}
#endif