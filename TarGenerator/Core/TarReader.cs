using System.IO;
using TarGenerator.Core.Interfaces;

namespace TarGenerator.Core;

public partial class TarReader(Stream baseStream) : TarBase(baseStream), ITarStreamRead
{
    public int Read(byte[] buffer, int offset, int count) => BaseStream.Read(buffer, offset, count);
}