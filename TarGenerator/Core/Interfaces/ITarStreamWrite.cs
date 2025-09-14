namespace TarGenerator.Core.Interfaces;

public interface ITarStreamWrite
{
    void Write(byte[] buffer, int offset, int count);
    void Flush();
}

