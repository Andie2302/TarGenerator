namespace TarGenerator.Core.Interfaces
{
    public interface ITarStreamRead
    {
        int Read(byte[] buffer, int offset, int count);
    }
}