﻿
#nullable enable

namespace Omnix.Network.Connection.Multiplexer.V1.Internal
{
    internal enum SessionErrorType : byte
    {
        ConnectFailed = 0,
        MemoryOverflow = 1,
        NotFoundSessionId = 2,
    }

    internal sealed partial class ProfileMessage : Omnix.Serialization.RocketPack.RocketPackMessageBase<ProfileMessage>
    {
        static ProfileMessage()
        {
            ProfileMessage.Formatter = new CustomFormatter();
            ProfileMessage.Empty = new ProfileMessage(0, 0);
        }

        private readonly int __hashCode;

        public ProfileMessage(ulong initialWindowSize, uint maxSessionAcceptQueueSize)
        {
            this.InitialWindowSize = initialWindowSize;
            this.MaxSessionAcceptQueueSize = maxSessionAcceptQueueSize;

            {
                var __h = new System.HashCode();
                if (this.InitialWindowSize != default) __h.Add(this.InitialWindowSize.GetHashCode());
                if (this.MaxSessionAcceptQueueSize != default) __h.Add(this.MaxSessionAcceptQueueSize.GetHashCode());
                __hashCode = __h.ToHashCode();
            }
        }

        public ulong InitialWindowSize { get; }
        public uint MaxSessionAcceptQueueSize { get; }

        public override bool Equals(ProfileMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.InitialWindowSize != target.InitialWindowSize) return false;
            if (this.MaxSessionAcceptQueueSize != target.MaxSessionAcceptQueueSize) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<ProfileMessage>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, ProfileMessage value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.InitialWindowSize != 0)
                    {
                        propertyCount++;
                    }
                    if (value.MaxSessionAcceptQueueSize != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.InitialWindowSize != 0)
                {
                    w.Write((uint)0);
                    w.Write(value.InitialWindowSize);
                }
                if (value.MaxSessionAcceptQueueSize != 0)
                {
                    w.Write((uint)1);
                    w.Write(value.MaxSessionAcceptQueueSize);
                }
            }

            public ProfileMessage Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                ulong p_initialWindowSize = 0;
                uint p_maxSessionAcceptQueueSize = 0;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // InitialWindowSize
                            {
                                p_initialWindowSize = r.GetUInt64();
                                break;
                            }
                        case 1: // MaxSessionAcceptQueueSize
                            {
                                p_maxSessionAcceptQueueSize = r.GetUInt32();
                                break;
                            }
                    }
                }

                return new ProfileMessage(p_initialWindowSize, p_maxSessionAcceptQueueSize);
            }
        }
    }

    internal sealed partial class SessionConnectMessage : Omnix.Serialization.RocketPack.RocketPackMessageBase<SessionConnectMessage>
    {
        static SessionConnectMessage()
        {
            SessionConnectMessage.Formatter = new CustomFormatter();
            SessionConnectMessage.Empty = new SessionConnectMessage(0);
        }

        private readonly int __hashCode;

        public SessionConnectMessage(ulong sessionId)
        {
            this.SessionId = sessionId;

            {
                var __h = new System.HashCode();
                if (this.SessionId != default) __h.Add(this.SessionId.GetHashCode());
                __hashCode = __h.ToHashCode();
            }
        }

        public ulong SessionId { get; }

        public override bool Equals(SessionConnectMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.SessionId != target.SessionId) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<SessionConnectMessage>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, SessionConnectMessage value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.SessionId != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.SessionId != 0)
                {
                    w.Write((uint)0);
                    w.Write(value.SessionId);
                }
            }

            public SessionConnectMessage Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                ulong p_sessionId = 0;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // SessionId
                            {
                                p_sessionId = r.GetUInt64();
                                break;
                            }
                    }
                }

                return new SessionConnectMessage(p_sessionId);
            }
        }
    }

    internal sealed partial class SessionAcceptMessage : Omnix.Serialization.RocketPack.RocketPackMessageBase<SessionAcceptMessage>
    {
        static SessionAcceptMessage()
        {
            SessionAcceptMessage.Formatter = new CustomFormatter();
            SessionAcceptMessage.Empty = new SessionAcceptMessage(0);
        }

        private readonly int __hashCode;

        public SessionAcceptMessage(ulong sessionId)
        {
            this.SessionId = sessionId;

            {
                var __h = new System.HashCode();
                if (this.SessionId != default) __h.Add(this.SessionId.GetHashCode());
                __hashCode = __h.ToHashCode();
            }
        }

        public ulong SessionId { get; }

        public override bool Equals(SessionAcceptMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.SessionId != target.SessionId) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<SessionAcceptMessage>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, SessionAcceptMessage value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.SessionId != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.SessionId != 0)
                {
                    w.Write((uint)0);
                    w.Write(value.SessionId);
                }
            }

            public SessionAcceptMessage Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                ulong p_sessionId = 0;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // SessionId
                            {
                                p_sessionId = r.GetUInt64();
                                break;
                            }
                    }
                }

                return new SessionAcceptMessage(p_sessionId);
            }
        }
    }

    internal sealed partial class SessionUpdateWindowSizeMessage : Omnix.Serialization.RocketPack.RocketPackMessageBase<SessionUpdateWindowSizeMessage>
    {
        static SessionUpdateWindowSizeMessage()
        {
            SessionUpdateWindowSizeMessage.Formatter = new CustomFormatter();
            SessionUpdateWindowSizeMessage.Empty = new SessionUpdateWindowSizeMessage(0, 0);
        }

        private readonly int __hashCode;

        public SessionUpdateWindowSizeMessage(ulong sessionId, ulong size)
        {
            this.SessionId = sessionId;
            this.Size = size;

            {
                var __h = new System.HashCode();
                if (this.SessionId != default) __h.Add(this.SessionId.GetHashCode());
                if (this.Size != default) __h.Add(this.Size.GetHashCode());
                __hashCode = __h.ToHashCode();
            }
        }

        public ulong SessionId { get; }
        public ulong Size { get; }

        public override bool Equals(SessionUpdateWindowSizeMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.SessionId != target.SessionId) return false;
            if (this.Size != target.Size) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<SessionUpdateWindowSizeMessage>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, SessionUpdateWindowSizeMessage value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.SessionId != 0)
                    {
                        propertyCount++;
                    }
                    if (value.Size != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.SessionId != 0)
                {
                    w.Write((uint)0);
                    w.Write(value.SessionId);
                }
                if (value.Size != 0)
                {
                    w.Write((uint)1);
                    w.Write(value.Size);
                }
            }

            public SessionUpdateWindowSizeMessage Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                ulong p_sessionId = 0;
                ulong p_size = 0;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // SessionId
                            {
                                p_sessionId = r.GetUInt64();
                                break;
                            }
                        case 1: // Size
                            {
                                p_size = r.GetUInt64();
                                break;
                            }
                    }
                }

                return new SessionUpdateWindowSizeMessage(p_sessionId, p_size);
            }
        }
    }

    internal sealed partial class SessionDataMessage : Omnix.Serialization.RocketPack.RocketPackMessageBase<SessionDataMessage>, System.IDisposable
    {
        static SessionDataMessage()
        {
            SessionDataMessage.Formatter = new CustomFormatter();
            SessionDataMessage.Empty = new SessionDataMessage(0, false, Omnix.Base.SimpleMemoryOwner<byte>.Empty);
        }

        private readonly int __hashCode;

        public static readonly int MaxDataLength = 262144;

        public SessionDataMessage(ulong sessionId, bool isCompleted, System.Buffers.IMemoryOwner<byte> data)
        {
            if (data is null) throw new System.ArgumentNullException("data");
            if (data.Memory.Length > 262144) throw new System.ArgumentOutOfRangeException("data");

            this.SessionId = sessionId;
            this.IsCompleted = isCompleted;
            _data = data;

            {
                var __h = new System.HashCode();
                if (this.SessionId != default) __h.Add(this.SessionId.GetHashCode());
                if (this.IsCompleted != default) __h.Add(this.IsCompleted.GetHashCode());
                if (!this.Data.IsEmpty) __h.Add(Omnix.Base.Helpers.ObjectHelper.GetHashCode(this.Data.Span));
                __hashCode = __h.ToHashCode();
            }
        }

        public ulong SessionId { get; }
        public bool IsCompleted { get; }
        private readonly System.Buffers.IMemoryOwner<byte> _data;
        public System.ReadOnlyMemory<byte> Data => _data.Memory;

        public override bool Equals(SessionDataMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.SessionId != target.SessionId) return false;
            if (this.IsCompleted != target.IsCompleted) return false;
            if (!Omnix.Base.BytesOperations.SequenceEqual(this.Data.Span, target.Data.Span)) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        public void Dispose()
        {
            _data?.Dispose();
        }

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<SessionDataMessage>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, SessionDataMessage value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.SessionId != 0)
                    {
                        propertyCount++;
                    }
                    if (value.IsCompleted != false)
                    {
                        propertyCount++;
                    }
                    if (!value.Data.IsEmpty)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.SessionId != 0)
                {
                    w.Write((uint)0);
                    w.Write(value.SessionId);
                }
                if (value.IsCompleted != false)
                {
                    w.Write((uint)1);
                    w.Write(value.IsCompleted);
                }
                if (!value.Data.IsEmpty)
                {
                    w.Write((uint)2);
                    w.Write(value.Data.Span);
                }
            }

            public SessionDataMessage Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                ulong p_sessionId = 0;
                bool p_isCompleted = false;
                System.Buffers.IMemoryOwner<byte> p_data = Omnix.Base.SimpleMemoryOwner<byte>.Empty;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // SessionId
                            {
                                p_sessionId = r.GetUInt64();
                                break;
                            }
                        case 1: // IsCompleted
                            {
                                p_isCompleted = r.GetBoolean();
                                break;
                            }
                        case 2: // Data
                            {
                                p_data = r.GetRecyclableMemory(262144);
                                break;
                            }
                    }
                }

                return new SessionDataMessage(p_sessionId, p_isCompleted, p_data);
            }
        }
    }

    internal sealed partial class SessionCloseMessage : Omnix.Serialization.RocketPack.RocketPackMessageBase<SessionCloseMessage>
    {
        static SessionCloseMessage()
        {
            SessionCloseMessage.Formatter = new CustomFormatter();
            SessionCloseMessage.Empty = new SessionCloseMessage(0);
        }

        private readonly int __hashCode;

        public SessionCloseMessage(ulong sessionId)
        {
            this.SessionId = sessionId;

            {
                var __h = new System.HashCode();
                if (this.SessionId != default) __h.Add(this.SessionId.GetHashCode());
                __hashCode = __h.ToHashCode();
            }
        }

        public ulong SessionId { get; }

        public override bool Equals(SessionCloseMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.SessionId != target.SessionId) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<SessionCloseMessage>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, SessionCloseMessage value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.SessionId != 0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.SessionId != 0)
                {
                    w.Write((uint)0);
                    w.Write(value.SessionId);
                }
            }

            public SessionCloseMessage Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                ulong p_sessionId = 0;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // SessionId
                            {
                                p_sessionId = r.GetUInt64();
                                break;
                            }
                    }
                }

                return new SessionCloseMessage(p_sessionId);
            }
        }
    }

    internal sealed partial class SessionErrorMessage : Omnix.Serialization.RocketPack.RocketPackMessageBase<SessionErrorMessage>
    {
        static SessionErrorMessage()
        {
            SessionErrorMessage.Formatter = new CustomFormatter();
            SessionErrorMessage.Empty = new SessionErrorMessage(0, (SessionErrorType)0);
        }

        private readonly int __hashCode;

        public SessionErrorMessage(ulong sessionId, SessionErrorType errorType)
        {
            this.SessionId = sessionId;
            this.ErrorType = errorType;

            {
                var __h = new System.HashCode();
                if (this.SessionId != default) __h.Add(this.SessionId.GetHashCode());
                if (this.ErrorType != default) __h.Add(this.ErrorType.GetHashCode());
                __hashCode = __h.ToHashCode();
            }
        }

        public ulong SessionId { get; }
        public SessionErrorType ErrorType { get; }

        public override bool Equals(SessionErrorMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.SessionId != target.SessionId) return false;
            if (this.ErrorType != target.ErrorType) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<SessionErrorMessage>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, SessionErrorMessage value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.SessionId != 0)
                    {
                        propertyCount++;
                    }
                    if (value.ErrorType != (SessionErrorType)0)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.SessionId != 0)
                {
                    w.Write((uint)0);
                    w.Write(value.SessionId);
                }
                if (value.ErrorType != (SessionErrorType)0)
                {
                    w.Write((uint)1);
                    w.Write((ulong)value.ErrorType);
                }
            }

            public SessionErrorMessage Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                ulong p_sessionId = 0;
                SessionErrorType p_errorType = (SessionErrorType)0;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // SessionId
                            {
                                p_sessionId = r.GetUInt64();
                                break;
                            }
                        case 1: // ErrorType
                            {
                                p_errorType = (SessionErrorType)r.GetUInt64();
                                break;
                            }
                    }
                }

                return new SessionErrorMessage(p_sessionId, p_errorType);
            }
        }
    }

}
