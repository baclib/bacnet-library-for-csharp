namespace BacnetLibrary;

/// <summary>
/// Represents a BACnet MAC address with up to 7 bytes.
/// The 8th byte stores the length of the address.
/// </summary>
public readonly struct MacAddress
{
    /// <summary>
    /// Maximum length of a MAC address in bytes.
    /// </summary>
    public const int MaxLength = 7;

    /// <summary>
    /// Initializes a new instance of the <see cref="MacAddress"/> struct from an array of bytes.
    /// </summary>
    /// <param name="octets">The MAC address octets.</param>
    public MacAddress(params byte[] octets) :
        this(octets.AsSpan())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MacAddress"/> struct from a span of bytes.
    /// </summary>
    /// <param name="octets">The MAC address octets.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of octets exceeds <see cref="MaxLength"/>.</exception>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="MacAddress"/> struct from a long value and length.
    /// </summary>
    /// <param name="value">The MAC address value.</param>
    /// <param name="length">The length of the MAC address in bytes.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the length exceeds <see cref="MaxLength"/>.</exception>
    public MacAddress(long value, int length)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(length, MaxLength, nameof(length));
        var mask = (1L << (length * 8)) - 1;
        _value = (value & mask) << 8;
        _value |= (byte)length;
    }

    /// <summary>
    /// Gets the MAC address value (without the length byte).
    /// </summary>
    public long Value => _value >> 8;

    /// <summary>
    /// Gets the length of the MAC address in bytes.
    /// </summary>
    public int Length => (byte)_value;

    /// <summary>
    /// Gets a value indicating whether this MAC address can be used as a source address.
    /// A sourceable address has a length greater than 0 and less than <see cref="MaxLength"/>.
    /// </summary>
    public bool IsSourceable => Length > 0 && Length < MaxLength;

    /// <summary>
    /// Copies the MAC address bytes to the specified buffer.
    /// </summary>
    /// <param name="buffer">The destination buffer.</param>
    /// <param name="offset">The offset in the buffer at which to start copying.</param>
    /// <returns>The number of bytes copied (equal to <see cref="Length"/>).</returns>
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

    /// <summary>
    /// Gets the MAC address as a byte array.
    /// </summary>
    /// <returns>A byte array containing the MAC address octets.</returns>
    public byte[] GetBytes()
    {
        var buffer = new byte[Length];
        CopyTo(buffer);
        return buffer;
    }

    /// <summary>
    /// Represents a broadcast MAC address (length of 0).
    /// </summary>
    public static readonly MacAddress Broadcast = new();

    public static bool operator ==(MacAddress left, MacAddress right) => left._value == right._value;

    public static bool operator !=(MacAddress left, MacAddress right) => left._value != right._value;

    public override bool Equals(object? obj) => obj is MacAddress address && address == this;

    public override int GetHashCode() => _value.GetHashCode();

    /// <summary>
    /// Returns a string representation of the MAC address in hexadecimal format.
    /// </summary>
    /// <returns>A string in the format "XX-XX-XX-XX-XX-XX-XX" where each XX is a hexadecimal octet.</returns>
    public override string ToString() => BitConverter.ToString(GetBytes());
}
