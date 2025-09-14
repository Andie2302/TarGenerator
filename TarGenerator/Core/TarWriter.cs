using System.IO;
using System.Threading.Tasks;
using TarGenerator.Core.Interfaces;

namespace TarGenerator.Core;

public partial class TarWriter(Stream baseStream) : TarBase(baseStream), ITarStreamWrite
{
    public void Write(byte[] buffer, int offset, int count) => BaseStream.Write(buffer, offset, count);

    public void Flush() => BaseStream.Flush();
}