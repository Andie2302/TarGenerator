using System;
using System.IO;

namespace TarGenerator.Core
{
    public abstract partial class TarBase(Stream baseStream) : IDisposable
    {
        protected readonly Stream BaseStream = baseStream ?? throw new ArgumentNullException(nameof(baseStream));
        protected bool IsDisposed = false;

        public void Dispose()
        {
            if (IsDisposed) return;
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            if (disposing) BaseStream.Dispose();
            IsDisposed = true;
        }
    }
}