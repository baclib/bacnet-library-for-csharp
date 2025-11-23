namespace Ipv4UdpClient;

public readonly struct NacAddress(MacAddress macAddress, ushort networkNumber = NacAddress.LocalNetworkNumber)
{
    public const ushort LocalNetworkNumber = ushort.MinValue;

    public const ushort GlobalNetworkNumber = ushort.MaxValue;

    public MacAddress MacAddress => macAddress;

    public ushort NetworkNumber => networkNumber;

    public bool IsBroadcast => MacAddress.Length == 0;

    public bool IsLocal => NetworkNumber == LocalNetworkNumber;

    public bool IsLocalBroadcast => IsLocal && IsBroadcast;

    public bool IsGlobal => NetworkNumber == GlobalNetworkNumber;

    public bool IsGlobalBroadcast => IsGlobal && IsBroadcast;

    public bool IsRemote => !IsLocal && !IsGlobal;

    public bool IsRemoteBroadcast => IsRemote && IsBroadcast;

    public bool IsSourceable => MacAddress.IsSourceable && !IsGlobal;

    public static readonly NacAddress LocalBroadcast = new(MacAddress.Broadcast, LocalNetworkNumber);

    public static readonly NacAddress GlobalBroadcast = new(MacAddress.Broadcast, GlobalNetworkNumber);

    public static bool operator ==(NacAddress left, NacAddress right) => left.MacAddress == right.MacAddress && left.NetworkNumber == right.NetworkNumber;

    public static bool operator !=(NacAddress left, NacAddress right) => left.MacAddress != right.MacAddress || left.NetworkNumber != right.NetworkNumber;

    public override bool Equals(object? obj) => obj is NacAddress address && address == this;

    public override int GetHashCode() => HashCode.Combine(MacAddress, NetworkNumber);

    public override string ToString() => $"{MacAddress}+{NetworkNumber}";
}
