using System;
using System.Threading.Tasks;

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
namespace TarGenerator.Core
{
    public abstract partial class TarBase : IAsyncDisposable
    {
        public virtual async ValueTask DisposeAsync()
        {
            if (IsDisposed) return;
            await BaseStream.DisposeAsync().ConfigureAwait(false);
            IsDisposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
#endif