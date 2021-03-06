﻿
#nullable enable

namespace Omnix.Network
{
    public sealed partial class OmniAddress : Omnix.Serialization.RocketPack.RocketPackMessageBase<OmniAddress>
    {
        static OmniAddress()
        {
            OmniAddress.Formatter = new CustomFormatter();
            OmniAddress.Empty = new OmniAddress(string.Empty);
        }

        private readonly int __hashCode;

        public static readonly int MaxValueLength = 8192;

        public OmniAddress(string value)
        {
            if (value is null) throw new System.ArgumentNullException("value");
            if (value.Length > 8192) throw new System.ArgumentOutOfRangeException("value");

            this.Value = value;

            {
                var __h = new System.HashCode();
                if (this.Value != default) __h.Add(this.Value.GetHashCode());
                __hashCode = __h.ToHashCode();
            }
        }

        public string Value { get; }

        public override bool Equals(OmniAddress? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.Value != target.Value) return false;

            return true;
        }

        public override int GetHashCode() => __hashCode;

        private sealed class CustomFormatter : Omnix.Serialization.RocketPack.IRocketPackFormatter<OmniAddress>
        {
            public void Serialize(Omnix.Serialization.RocketPack.RocketPackWriter w, OmniAddress value, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                {
                    uint propertyCount = 0;
                    if (value.Value != string.Empty)
                    {
                        propertyCount++;
                    }
                    w.Write(propertyCount);
                }

                if (value.Value != string.Empty)
                {
                    w.Write((uint)0);
                    w.Write(value.Value);
                }
            }

            public OmniAddress Deserialize(Omnix.Serialization.RocketPack.RocketPackReader r, int rank)
            {
                if (rank > 256) throw new System.FormatException();

                // Read property count
                uint propertyCount = r.GetUInt32();

                string p_value = string.Empty;

                for (; propertyCount > 0; propertyCount--)
                {
                    uint id = r.GetUInt32();
                    switch (id)
                    {
                        case 0: // Value
                            {
                                p_value = r.GetString(8192);
                                break;
                            }
                    }
                }

                return new OmniAddress(p_value);
            }
        }
    }

}
