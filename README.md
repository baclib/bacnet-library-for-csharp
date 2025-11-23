# BACnet Library for C#

A modern C# implementation of the BACnet protocol stack, providing comprehensive stack and object functionalities for building BACnet-compliant applications.

## Overview

This library is a **from-scratch implementation** of the Building Automation and Control Networks (BACnet) protocol, built to incorporate decades of knowledge and best practices from both the BACnet protocol evolution and modern software development.

Written in modern C#, this implementation leverages state-of-the-art software engineering practices, including:

- Clean architecture and SOLID principles
- Modern asynchronous programming patterns
- Comprehensive error handling and diagnostics
- Memory-efficient and performant code
- Testable and maintainable design

By starting fresh, we can apply lessons learned from existing implementations while utilizing the latest language features and frameworks available in the .NET ecosystem. This approach enables us to create a robust foundation for developing BACnet clients, servers, and devices that meet today's performance, security, and maintainability standards.

## Features

- **Modern C# Implementation**: Built with the latest C# features and best practices
- **BACnet Protocol Stack**: Complete implementation of the BACnet communication stack
- **Object Model Support**: Comprehensive BACnet object functionalities
- **Standards Compliant**: Follows related ASHRAE standards and recommendations
- **Extensible Architecture**: Designed for easy extension and customization

## Getting Started

### Prerequisites

- .NET 8.0 or later
- Visual Studio Code
- Visual Studio 2022 or compatible IDE (optional)

### Installation

Clone the repository:

```bash
git clone https://github.com/baclib/bacnet-library-for-csharp.git
cd bacnet-library-for-csharp
```

### Building

```bash
dotnet build
```

### Usage

```csharp
// Example usage will be added as the library develops
```

## Project Structure

The library is organized to provide clear separation of concerns:

- **Protocol Stack**: Core BACnet protocol implementation
- **Object Model**: BACnet object types and properties
- **Services**: BACnet services (Read, Write, COV, etc.)
- **Transport**: Network transport layer implementations

## BACnet Protocol Support

This library aims to support:

### Transport Layer Support

- **BACnet/IP (IPv4)** - BACnet over IPv4 networks (Annex J)
- **BACnet/SC** - BACnet Secure Connect for secure WebSocket communication (Addendum 135-2016bj)
- **BACnet MS/TP** - Master-Slave/Token-Passing for RS-485 networks (Clause 9)

### Protocol Features

- BACnet objects and services as defined in ASHRAE Standard 135
- Device discovery and management
- Read/Write Property services
- Change of Value (COV) notifications
- Alarm and event management
- ...

## Contributing

We welcome contributions from the community! Please see our [CONTRIBUTING.md](CONTRIBUTING.md) file for guidelines on how to contribute to this project.

## License

This project is licensed under the BSD 2-Clause License - see the [LICENSE](LICENSE) file for details.

## Support

For questions, issues, or feature requests, please use the GitHub issue tracker.

## Roadmap

### Phase 1: Foundation
- [ ] Core protocol stack implementation
- [ ] Basic object model support
- [ ] BACnet/IP (IPv4) transport layer
- [ ] Essential services (ReadProperty, WriteProperty, ...)
- [ ] Device discovery

### Phase 2: Enhanced Features
- [ ] BACnet/SC (Secure Connect) transport layer
- [ ] Security features and authentication
- [ ] COV support
- [ ] Advanced services (ReadPropertyMultiple, WritePropertyMultiple, ...)
- [ ] Example applications

### Phase 3: Serial & Advanced
- [ ] BACnet MS/TP transport layer
- [ ] Performance optimizations
- [ ] Comprehensive documentation
- [ ] Unit and integration tests
- [ ] Production-ready release

## Acknowledgments

This project is maintained by The BAClib Initiative and contributors from the BACnet community.

### Tribute to Existing Open Source BACnet Implementations

While this library is built from the ground up, we acknowledge and pay tribute to the pioneering open source BACnet implementations that have paved the way and made significant contributions to the BACnet community:

- **[BACnet Stack by Steve Karg](https://github.com/bacnet-stack/bacnet-stack)**: A comprehensive C implementation that has been instrumental in advancing BACnet adoption and understanding. Steve Karg and the many contributors to this project have provided invaluable reference implementations and demonstrated best practices that have benefited the entire BACnet ecosystem.

- The broader open source BACnet community whose collective knowledge, documentation, and real-world implementations have been essential in understanding the nuances of the protocol.

These projects have made BACnet more accessible and have been invaluable learning resources. Our from-scratch approach aims to complement the ecosystem by bringing modern C# and .NET capabilities to BACnet development, building upon the foundation of knowledge that these projects have established.

---

> [!IMPORTANT]
> **Note**: This library is under active development. APIs may change as the project evolves.
