using System;
using System.Runtime.CompilerServices;

namespace Spreads.Serialization.Utf8Json.Internal
{
    internal sealed class BufferPool : ArrayPool<byte>
    {
        public static readonly BufferPool Default = new BufferPool(65535);

        public BufferPool(int bufferLength)
            : base(bufferLength)
        {
        }
    }

    internal class ArrayPool<T>
    {
        readonly int bufferLength;
#if !SPREADS
        readonly object gate;
        int index;
        T[][] buffers;
#endif

        public ArrayPool(int bufferLength)
        {
            this.bufferLength = bufferLength;
#if !SPREADS
            this.buffers = new T[4][];
            this.gate = new object();
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T[] Rent()
        {
#if !SPREADS
            lock (gate)
            {
                if (index >= buffers.Length)
                {
                    Array.Resize(ref buffers, buffers.Length * 2);
                }

                if (buffers[index] == null)
                {
                    buffers[index] = new T[bufferLength];
                }

                var buffer = buffers[index];
                buffers[index] = null;
                index++;

                return buffer;
            }
#else
            return Buffers.BufferPool<T>.Rent(bufferLength);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Return(T[] array)
        {
#if !SPREADS
            if (array.Length != bufferLength)
            {
                throw new InvalidOperationException("return buffer is not from pool");
            }

            lock (gate)
            {
                if (index != 0)
                {
                    buffers[--index] = array;
                }
            }
#else
            Buffers.BufferPool<T>.Return(array);
#endif
        }
    }
}
