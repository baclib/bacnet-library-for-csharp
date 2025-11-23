namespace BacnetLibrary.Tests;

public class NacAddressTests
{
    [Fact]
    public void Constructor_WithDefaults_CreatesLocalAddress()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);

        // Act
        var nacAddress = new NacAddress(macAddress);

        // Assert
        Assert.Equal(macAddress, nacAddress.MacAddress);
        Assert.Equal(NacAddress.LocalNetworkNumber, nacAddress.NetworkNumber);
    }

    [Fact]
    public void Constructor_WithNetworkNumber_CreatesCorrectAddress()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        ushort networkNumber = 1234;

        // Act
        var nacAddress = new NacAddress(macAddress, networkNumber);

        // Assert
        Assert.Equal(macAddress, nacAddress.MacAddress);
        Assert.Equal(networkNumber, nacAddress.NetworkNumber);
    }

    [Fact]
    public void LocalBroadcast_IsCorrect()
    {
        // Act
        var localBroadcast = NacAddress.LocalBroadcast;

        // Assert
        Assert.True(localBroadcast.IsLocalBroadcast);
        Assert.True(localBroadcast.IsLocal);
        Assert.True(localBroadcast.IsBroadcast);
        Assert.Equal(NacAddress.LocalNetworkNumber, localBroadcast.NetworkNumber);
        Assert.Equal(MacAddress.Broadcast, localBroadcast.MacAddress);
    }

    [Fact]
    public void GlobalBroadcast_IsCorrect()
    {
        // Act
        var globalBroadcast = NacAddress.GlobalBroadcast;

        // Assert
        Assert.True(globalBroadcast.IsGlobalBroadcast);
        Assert.True(globalBroadcast.IsGlobal);
        Assert.True(globalBroadcast.IsBroadcast);
        Assert.Equal(NacAddress.GlobalNetworkNumber, globalBroadcast.NetworkNumber);
        Assert.Equal(MacAddress.Broadcast, globalBroadcast.MacAddress);
    }

    [Fact]
    public void IsBroadcast_WithBroadcastMac_ReturnsTrue()
    {
        // Arrange
        var nacAddress = new NacAddress(MacAddress.Broadcast, 100);

        // Act & Assert
        Assert.True(nacAddress.IsBroadcast);
    }

    [Fact]
    public void IsBroadcast_WithNonBroadcastMac_ReturnsFalse()
    {
        // Arrange
        var nacAddress = new NacAddress(new MacAddress(0x010203, 3), 100);

        // Act & Assert
        Assert.False(nacAddress.IsBroadcast);
    }

    [Fact]
    public void IsLocal_WithLocalNetworkNumber_ReturnsTrue()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        var nacAddress = new NacAddress(macAddress, NacAddress.LocalNetworkNumber);

        // Act & Assert
        Assert.True(nacAddress.IsLocal);
    }

    [Fact]
    public void IsLocal_WithNonLocalNetworkNumber_ReturnsFalse()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        var nacAddress = new NacAddress(macAddress, 100);

        // Act & Assert
        Assert.False(nacAddress.IsLocal);
    }

    [Fact]
    public void IsGlobal_WithGlobalNetworkNumber_ReturnsTrue()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        var nacAddress = new NacAddress(macAddress, NacAddress.GlobalNetworkNumber);

        // Act & Assert
        Assert.True(nacAddress.IsGlobal);
    }

    [Fact]
    public void IsGlobal_WithNonGlobalNetworkNumber_ReturnsFalse()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        var nacAddress = new NacAddress(macAddress, 100);

        // Act & Assert
        Assert.False(nacAddress.IsGlobal);
    }

    [Fact]
    public void IsRemote_WithRemoteNetworkNumber_ReturnsTrue()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        var nacAddress = new NacAddress(macAddress, 100);

        // Act & Assert
        Assert.True(nacAddress.IsRemote);
        Assert.False(nacAddress.IsLocal);
        Assert.False(nacAddress.IsGlobal);
    }

    [Fact]
    public void IsRemoteBroadcast_WithRemoteNetworkAndBroadcastMac_ReturnsTrue()
    {
        // Arrange
        var nacAddress = new NacAddress(MacAddress.Broadcast, 100);

        // Act & Assert
        Assert.True(nacAddress.IsRemoteBroadcast);
        Assert.True(nacAddress.IsRemote);
        Assert.True(nacAddress.IsBroadcast);
    }

    [Fact]
    public void IsSourceable_WithSourceableMacAndNonGlobalNetwork_ReturnsTrue()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        var nacAddress = new NacAddress(macAddress, 100);

        // Act & Assert
        Assert.True(nacAddress.IsSourceable);
    }

    [Fact]
    public void IsSourceable_WithGlobalNetwork_ReturnsFalse()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        var nacAddress = new NacAddress(macAddress, NacAddress.GlobalNetworkNumber);

        // Act & Assert
        Assert.False(nacAddress.IsSourceable);
    }

    [Fact]
    public void IsSourceable_WithBroadcastMac_ReturnsFalse()
    {
        // Arrange
        var nacAddress = new NacAddress(MacAddress.Broadcast, 100);

        // Act & Assert
        Assert.False(nacAddress.IsSourceable);
    }

    [Fact]
    public void Equality_SameAddresses_AreEqual()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        var nac1 = new NacAddress(macAddress, 100);
        var nac2 = new NacAddress(macAddress, 100);

        // Act & Assert
        Assert.True(nac1 == nac2);
        Assert.False(nac1 != nac2);
        Assert.True(nac1.Equals(nac2));
        Assert.Equal(nac1.GetHashCode(), nac2.GetHashCode());
    }

    [Fact]
    public void Equality_DifferentMacAddresses_AreNotEqual()
    {
        // Arrange
        var mac1 = new MacAddress(0x010203, 3);
        var mac2 = new MacAddress(0x040506, 3);
        var nac1 = new NacAddress(mac1, 100);
        var nac2 = new NacAddress(mac2, 100);

        // Act & Assert
        Assert.False(nac1 == nac2);
        Assert.True(nac1 != nac2);
        Assert.False(nac1.Equals(nac2));
    }

    [Fact]
    public void Equality_DifferentNetworkNumbers_AreNotEqual()
    {
        // Arrange
        var macAddress = new MacAddress(0x010203, 3);
        var nac1 = new NacAddress(macAddress, 100);
        var nac2 = new NacAddress(macAddress, 200);

        // Act & Assert
        Assert.False(nac1 == nac2);
        Assert.True(nac1 != nac2);
        Assert.False(nac1.Equals(nac2));
    }

    [Fact]
    public void ToString_ReturnsCorrectFormat()
    {
        // Arrange
        var macAddress = new MacAddress([0xAA, 0xBB, 0xCC]);
        var nacAddress = new NacAddress(macAddress, 1234);

        // Act
        var result = nacAddress.ToString();

        // Assert
        Assert.Equal("AA-BB-CC+1234", result);
    }

    [Fact]
    public void ToString_LocalBroadcast_ReturnsCorrectFormat()
    {
        // Act
        var result = NacAddress.LocalBroadcast.ToString();

        // Assert
        Assert.Equal($"+{NacAddress.LocalNetworkNumber}", result);
    }

    [Fact]
    public void ToString_GlobalBroadcast_ReturnsCorrectFormat()
    {
        // Act
        var result = NacAddress.GlobalBroadcast.ToString();

        // Assert
        Assert.Equal($"+{NacAddress.GlobalNetworkNumber}", result);
    }

    [Fact]
    public void Constants_HaveCorrectValues()
    {
        // Assert
        Assert.Equal(ushort.MinValue, NacAddress.LocalNetworkNumber);
        Assert.Equal(ushort.MaxValue, NacAddress.GlobalNetworkNumber);
    }
}
