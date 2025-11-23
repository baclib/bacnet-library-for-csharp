namespace BacnetLibrary.Tests;

public class MacAddressTests
{
    [Fact]
    public void Constructor_WithByteArray_CreatesCorrectMacAddress()
    {
        // Arrange
        byte[] octets = [0x01, 0x02, 0x03, 0x04];

        // Act
        var macAddress = new MacAddress(octets);

        // Assert
        Assert.Equal(4, macAddress.Length);
        Assert.Equal(octets, macAddress.GetBytes());
    }

    [Fact]
    public void Constructor_WithSpan_CreatesCorrectMacAddress()
    {
        // Arrange
        ReadOnlySpan<byte> octets = stackalloc byte[] { 0xAA, 0xBB, 0xCC };

        // Act
        var macAddress = new MacAddress(octets);

        // Assert
        Assert.Equal(3, macAddress.Length);
        var bytes = macAddress.GetBytes();
        Assert.Equal(0xAA, bytes[0]);
        Assert.Equal(0xBB, bytes[1]);
        Assert.Equal(0xCC, bytes[2]);
    }

    [Fact]
    public void Constructor_WithValueAndLength_CreatesCorrectMacAddress()
    {
        // Arrange
        long value = 0x010203;
        int length = 3;

        // Act
        var macAddress = new MacAddress(value, length);

        // Assert
        Assert.Equal(length, macAddress.Length);
        Assert.Equal(value, macAddress.Value);
    }

    [Fact]
    public void Constructor_WithTooManyOctets_ThrowsException()
    {
        // Arrange
        byte[] octets = [0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08];

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new MacAddress(octets));
    }

    [Fact]
    public void Constructor_WithMaxLength_Succeeds()
    {
        // Arrange
        byte[] octets = [0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07];

        // Act
        var macAddress = new MacAddress(octets);

        // Assert
        Assert.Equal(MacAddress.MaxLength, macAddress.Length);
        Assert.Equal(octets, macAddress.GetBytes());
    }

    [Fact]
    public void Broadcast_HasZeroLength()
    {
        // Act
        var broadcast = MacAddress.Broadcast;

        // Assert
        Assert.Equal(0, broadcast.Length);
        Assert.Empty(broadcast.GetBytes());
    }

    [Fact]
    public void IsSourceable_WithValidLength_ReturnsTrue()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);

        // Act & Assert
        Assert.True(macAddress.IsSourceable);
    }

    [Fact]
    public void IsSourceable_WithZeroLength_ReturnsFalse()
    {
        // Arrange
        var macAddress = MacAddress.Broadcast;

        // Act & Assert
        Assert.False(macAddress.IsSourceable);
    }

    [Fact]
    public void IsSourceable_WithMaxLength_ReturnsFalse()
    {
        // Arrange
        byte[] octets = [0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07];
        var macAddress = new MacAddress(octets);

        // Act & Assert
        Assert.False(macAddress.IsSourceable);
    }

    [Fact]
    public void CopyTo_CopiesCorrectBytes()
    {
        // Arrange
        byte[] octets = [0x11, 0x22, 0x33];
        var macAddress = new MacAddress(octets);
        byte[] buffer = new byte[10];

        // Act
        int copied = macAddress.CopyTo(buffer, 2);

        // Assert
        Assert.Equal(3, copied);
        Assert.Equal(0x11, buffer[2]);
        Assert.Equal(0x22, buffer[3]);
        Assert.Equal(0x33, buffer[4]);
    }

    [Fact]
    public void GetBytes_ReturnsCorrectArray()
    {
        // Arrange
        byte[] expected = [0xAA, 0xBB, 0xCC, 0xDD];
        var macAddress = new MacAddress(expected);

        // Act
        var actual = macAddress.GetBytes();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Equality_SameMacAddresses_AreEqual()
    {
        // Arrange
        var mac1 = new MacAddress(0x010203, 3);
        var mac2 = new MacAddress(0x010203, 3);

        // Act & Assert
        Assert.True(mac1 == mac2);
        Assert.False(mac1 != mac2);
        Assert.True(mac1.Equals(mac2));
        Assert.Equal(mac1.GetHashCode(), mac2.GetHashCode());
    }

    [Fact]
    public void Equality_DifferentMacAddresses_AreNotEqual()
    {
        // Arrange
        var mac1 = new MacAddress(0x010203, 3);
        var mac2 = new MacAddress(0x040506, 3);

        // Act & Assert
        Assert.False(mac1 == mac2);
        Assert.True(mac1 != mac2);
        Assert.False(mac1.Equals(mac2));
    }

    [Fact]
    public void Equality_DifferentLengths_AreNotEqual()
    {
        // Arrange
        var mac1 = new MacAddress(0x0102, 2);
        var mac2 = new MacAddress(0x0102, 3);

        // Act & Assert
        Assert.False(mac1 == mac2);
        Assert.True(mac1 != mac2);
    }

    [Fact]
    public void ToString_ReturnsHyphenSeparatedHex()
    {
        // Arrange
        byte[] octets = [0xAA, 0xBB, 0xCC];
        var macAddress = new MacAddress(octets);

        // Act
        var result = macAddress.ToString();

        // Assert
        Assert.Equal("AA-BB-CC", result);
    }

    [Fact]
    public void ToString_BroadcastAddress_ReturnsEmptyString()
    {
        // Arrange
        var broadcast = MacAddress.Broadcast;

        // Act
        var result = broadcast.ToString();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Value_ReturnsCorrectValue()
    {
        // Arrange
        byte[] octets = [0x12, 0x34, 0x56];
        var macAddress = new MacAddress(octets);

        // Act
        long value = macAddress.Value;

        // Assert
        Assert.Equal(0x123456, value);
    }
}
