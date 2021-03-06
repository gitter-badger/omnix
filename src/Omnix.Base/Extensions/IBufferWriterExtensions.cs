﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Omnix.Base.Extensions
{
    public static class IBufferWriterExtensions
    {
        public static void Write<T>(this IBufferWriter<T> bufferWriter, ReadOnlySequence<T> sequence)
        {
            var position = sequence.Start;

            while (sequence.TryGet(ref position, out var memory, true))
            {
                if (memory.Length == 0)
                {
                    break;
                }

                bufferWriter.Write(memory.Span);
            }
        }
    }
}
