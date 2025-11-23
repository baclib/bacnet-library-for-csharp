namespace BacnetLibrary;

/// <summary>
/// Represents a BACnet Network Address (NAC Address) consisting of a MAC address and network number.
/// The network number extends the MAC address to make it unique within the BACnet internetwork.
/// Note: This struct is intentionally parallel to the BACnet Address.
/// </summary>
/// <param name="macAddress">The MAC address component.</param>
/// <param name="networkNumber">The network number (defaults to <see cref="LocalNetworkNumber"/>).</param>
public readonly struct NacAddress(MacAddress macAddress, ushort networkNumber = NacAddress.LocalNetworkNumber)
{
    /// <summary>
    /// The network number for the local network.
    /// </summary>
    public const ushort LocalNetworkNumber = ushort.MinValue;

    /// <summary>
    /// The network number for the global broadcast.
    /// </summary>
    public const ushort GlobalNetworkNumber = ushort.MaxValue;

    /// <summary>
    /// Gets the MAC address component of this NAC address.
    /// </summary>
    public MacAddress MacAddress => macAddress;

    /// <summary>
    /// Gets the network number component of this NAC address.
    /// </summary>
    public ushort NetworkNumber => networkNumber;

    /// <summary>
    /// Gets a value indicating whether this is a broadcast address (MAC address length is 0).
    /// </summary>
    public bool IsBroadcast => MacAddress.Length == 0;

    /// <summary>
    /// Gets a value indicating whether this is a local network address.
    /// </summary>
    public bool IsLocal => NetworkNumber == LocalNetworkNumber;

    /// <summary>
    /// Gets a value indicating whether this is a local broadcast address.
    /// </summary>
    public bool IsLocalBroadcast => IsLocal && IsBroadcast;

    /// <summary>
    /// Gets a value indicating whether this is a global network address.
    /// </summary>
    public bool IsGlobal => NetworkNumber == GlobalNetworkNumber;

    /// <summary>
    /// Gets a value indicating whether this is a global broadcast address.
    /// </summary>
    public bool IsGlobalBroadcast => IsGlobal && IsBroadcast;

    /// <summary>
    /// Gets a value indicating whether this is a remote network address (neither local nor global).
    /// </summary>
    public bool IsRemote => !IsLocal && !IsGlobal;

    /// <summary>
    /// Gets a value indicating whether this is a remote broadcast address.
    /// </summary>
    public bool IsRemoteBroadcast => IsRemote && IsBroadcast;

    /// <summary>
    /// Gets a value indicating whether this address can be used as a source address.
    /// A sourceable address has a sourceable MAC address and is not global.
    /// </summary>
    public bool IsSourceable => MacAddress.IsSourceable && !IsGlobal;

    /// <summary>
    /// Represents the local broadcast address.
    /// </summary>
    public static readonly NacAddress LocalBroadcast = new(MacAddress.Broadcast, LocalNetworkNumber);

    /// <summary>
    /// Represents the global broadcast address.
    /// </summary>
    public static readonly NacAddress GlobalBroadcast = new(MacAddress.Broadcast, GlobalNetworkNumber);

    public static bool operator ==(NacAddress left, NacAddress right) => left.MacAddress == right.MacAddress && left.NetworkNumber == right.NetworkNumber;

    public static bool operator !=(NacAddress left, NacAddress right) => left.MacAddress != right.MacAddress || left.NetworkNumber != right.NetworkNumber;

    public override bool Equals(object? obj) => obj is NacAddress address && address == this;

    public override int GetHashCode() => HashCode.Combine(MacAddress, NetworkNumber);

    /// <summary>
    /// Returns a string representation of the NAC address in the format "MAC+NetworkNumber".
    /// </summary>
    /// <returns>A string representation of the NAC address.</returns>
    public override string ToString() => $"{MacAddress}+{NetworkNumber}";
}
