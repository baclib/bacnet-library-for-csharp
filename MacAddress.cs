namespace Ipv4UdpClient;

public readonly struct MacAddress
{
    public const int MaxLength = 7;

    public MacAddress(params byte[] octets) :
        this(octets.AsSpan())
    {
    }

    public MacAddress(ReadOnlySpan<byte> octets)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(octets.Length, MaxLength, nameof(octets));
        foreach (var octet in octets)
        {
            _value |= octet;
            _value <<= 8;
        }
        _value |= (byte)octets.Length;
    }

    private readonly long _value;

    public MacAddress(long value, int length)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(Length, MaxLength, nameof(length));
        var mask = (1L << (length * 8)) - 1;
        _value = (value & mask) << 8;
        _value |= (byte)length;
    }

    public long Value => _value >> 8;

    public int Length => (byte)_value;

    public bool IsSourceable => Length > 0 && Length < MaxLength;

    public int CopyTo(byte[] buffer, int offset = 0)
    {
        var shift = Length * 8;
        for (int index = 0; index < Length; index++)
        {
            buffer[offset + index] = (byte)(_value >> shift);
            shift -= 8;
        }
        return Length;
    }

    public byte[] GetBytes()
    {
        var buffer = new byte[Length];
        CopyTo(buffer);
        return buffer;
    }

    public static readonly MacAddress Broadcast = new();

    public static bool operator ==(MacAddress left, MacAddress right) => left._value == right._value;

    public static bool operator !=(MacAddress left, MacAddress right) => left._value != right._value;

    public override bool Equals(object? obj) => obj is MacAddress address && address == this;

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => BitConverter.ToString(GetBytes());
}
