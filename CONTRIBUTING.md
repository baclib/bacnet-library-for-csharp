# Contributing to BACnet Library for C#

Thank you for your interest in contributing to the BACnet Library for C#! We welcome contributions from the community and appreciate your efforts to help improve this project.

## Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Getting Started](#getting-started)
- [How to Contribute](#how-to-contribute)
- [Development Workflow](#development-workflow)
- [Coding Standards](#coding-standards)
- [Commit Guidelines](#commit-guidelines)
- [Pull Request Process](#pull-request-process)
- [Reporting Bugs](#reporting-bugs)
- [Requesting Features](#requesting-features)
- [Questions and Support](#questions-and-support)

## Code of Conduct

This project adheres to the Contributor Covenant [Code of Conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to baclib@mailbox.org.

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Git
- A code editor (Visual Studio Code, Visual Studio 2022, or JetBrains Rider)
- Basic understanding of the BACnet protocol (helpful but not required)

### Setting Up Your Development Environment

1. **Fork the repository** on GitHub
2. **Clone your fork** locally:
   ```bash
   git clone https://github.com/YOUR_USERNAME/bacnet-library-for-csharp.git
   cd bacnet-library-for-csharp
   ```
3. **Add the upstream remote**:
   ```bash
   git remote add upstream https://github.com/baclib/bacnet-library-for-csharp.git
   ```
4. **Build the project**:
   ```bash
   dotnet build
   ```
5. **Run tests** (when available):
   ```bash
   dotnet test
   ```

## How to Contribute

There are many ways to contribute to this project:

- **Code contributions**: Implement new features, fix bugs, or improve performance
- **Documentation**: Improve or add documentation, examples, and tutorials
- **Testing**: Write tests, report bugs, or verify fixes
- **Design**: Propose architectural improvements or API designs
- **Community**: Help answer questions and support other users

## Development Workflow

1. **Create a new branch** for your work:
   ```bash
   git checkout -b feature/your-feature-name
   ```
   Use prefixes like:
   - `feature/` for new features
   - `fix/` for bug fixes
   - `docs/` for documentation changes
   - `refactor/` for code refactoring
   - `test/` for test additions or improvements

2. **Make your changes** following the coding standards

3. **Test your changes** thoroughly

4. **Commit your changes** following the commit guidelines

5. **Keep your branch updated**:
   ```bash
   git fetch upstream
   git rebase upstream/main
   ```

6. **Push to your fork**:
   ```bash
   git push origin feature/your-feature-name
   ```

7. **Open a Pull Request** on GitHub

## Coding Standards

### C# Style Guidelines

- Follow [Microsoft's C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use **PascalCase** for class names, method names, and properties
- Use **camelCase** for local variables and parameters
- Use **_camelCase** for private fields (with underscore prefix)
- Use meaningful and descriptive names
- Keep methods focused and concise (Single Responsibility Principle)

### Code Quality

- Write **clean, readable code** with appropriate comments
- Follow **SOLID principles** and clean architecture patterns
- Use **async/await** for asynchronous operations
- Implement proper **error handling** and logging
- Write **XML documentation comments** for public APIs
- Avoid code duplication (DRY principle)

### Example

```csharp
namespace BACnet.Protocol.Services
{
    /// <summary>
    /// Provides functionality for reading BACnet properties.
    /// </summary>
    public class ReadPropertyService : IReadPropertyService
    {
        private readonly ILogger<ReadPropertyService> _logger;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadPropertyService"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public ReadPropertyService(ILogger<ReadPropertyService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        /// <summary>
        /// Reads a property value from a BACnet device asynchronously.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="propertyId">The property identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The property value.</returns>
        public async Task<PropertyValue> ReadPropertyAsync(
            uint deviceId,
            ObjectIdentifier objectId,
            PropertyIdentifier propertyId,
            CancellationToken cancellationToken = default)
        {
            // Implementation
        }
    }
}
```

## Commit Guidelines

Write clear and meaningful commit messages:

### Format

```
<type>(<scope>): <subject>

<body>

<footer>
```

### Types

- `feat`: A new feature
- `fix`: A bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting, missing semi-colons, etc.)
- `refactor`: Code refactoring without changing functionality
- `test`: Adding or updating tests
- `chore`: Maintenance tasks, dependency updates, etc.
- `perf`: Performance improvements

### Examples

```
feat(services): add ReadPropertyMultiple service implementation

Implement the ReadPropertyMultiple service according to ASHRAE 135-2020.
This allows reading multiple properties in a single request.

Closes #42
```

```
fix(transport): resolve connection timeout in BACnet/IP

The connection was timing out due to incorrect socket configuration.
Updated the socket options to use proper timeout values.

Fixes #78
```

## Pull Request Process

1. **Ensure your code builds** without errors or warnings
2. **Update documentation** if you've changed APIs or functionality
3. **Add or update tests** for your changes
4. **Update the README.md** if necessary
5. **Fill out the PR template** completely
6. **Link related issues** in the PR description
7. **Ensure CI checks pass** (when configured)
8. **Request review** from maintainers
9. **Address review feedback** promptly and professionally

### PR Title Format

Use the same format as commit messages:
```
feat(scope): brief description of changes
```

### What Happens Next

- Maintainers will review your PR
- You may be asked to make changes
- Once approved, a maintainer will merge your PR
- Your contribution will be acknowledged in release notes

## Reporting Bugs

Found a bug? Please help us fix it!

### Before Submitting

- Check the [issue tracker](https://github.com/baclib/bacnet-library-for-csharp/issues) to see if it's already reported
- Verify the bug exists in the latest version
- Collect relevant information about your environment

### Submitting a Bug Report

Open an issue with the following information:

- **Title**: Clear and descriptive summary
- **Description**: Detailed description of the bug
- **Steps to Reproduce**: Numbered steps to reproduce the behavior
- **Expected Behavior**: What you expected to happen
- **Actual Behavior**: What actually happened
- **Environment**:
  - OS and version
  - .NET version
  - Library version
- **Additional Context**: Logs, screenshots, or code samples

## Requesting Features

Have an idea for a new feature?

### Before Submitting

- Check if the feature is already in the [roadmap](README.md#roadmap)
- Search existing issues for similar requests
- Consider if it fits the project's scope and goals

### Submitting a Feature Request

Open an issue with:

- **Title**: Clear description of the feature
- **Problem Statement**: What problem does this solve?
- **Proposed Solution**: How should it work?
- **Alternatives**: Other approaches you've considered
- **Additional Context**: Use cases, examples, or mockups
- **BACnet Compliance**: Relevant ASHRAE standards or addenda

## Questions and Support

### Where to Ask Questions

- **General questions**: Open a [GitHub Discussion](https://github.com/baclib/bacnet-library-for-csharp/discussions)
- **Bug reports**: Open an [issue](https://github.com/baclib/bacnet-library-for-csharp/issues)
- **Security concerns**: Email baclib@mailbox.org directly

### Getting Help

- Review existing documentation and examples
- Search closed issues for similar questions
- Be specific and provide context when asking questions

## Recognition

We value all contributions! Contributors will be:

- Listed in release notes
- Acknowledged in the project documentation
- Part of building a better BACnet ecosystem

## License

By contributing to this project, you agree that your contributions will be licensed under the BSD 2-Clause License, the same license as the project.

---

Thank you for contributing to the BACnet Library for C#! Your efforts help make building automation more accessible and modern.
