# TarGenerator

A lightweight, cross-platform TAR archive generator library for .NET, designed to provide simple and efficient TAR file creation and extraction capabilities.

## 📋 Project Status

> **⚠️ Work in Progress**: This library is currently in early development. The API is not yet stable and breaking changes may occur.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-Multiple%20Targets-blue.svg)](#supported-platforms)

## 🎯 Goals

TarGenerator aims to provide:
- **Simple API** for TAR archive operations
- **Cross-platform** compatibility across all .NET implementations
- **Streaming support** for memory-efficient operations
- **POSIX TAR standard** compliance
- **Async/await pattern** support for modern applications

## 🚀 Quick Start

> **Note**: These examples show the planned API. Implementation is still in progress.

```csharp
using TarGenerator;

// Create a TAR archive
using var fileStream = File.Create("archive.tar");
using var tarWriter = new TarWriter(fileStream);

// Add files
tarWriter.AddFile("documents/readme.txt", File.ReadAllBytes("readme.txt"));
tarWriter.AddFile("config/app.json", File.ReadAllBytes("app.json"));

// Add directories
tarWriter.AddDirectory("logs/");
```

```csharp
// Extract a TAR archive
using var fileStream = File.OpenRead("archive.tar");
using var tarReader = new TarReader(fileStream);

while (tarReader.GetNextEntry() is TarEntry entry)
{
    if (entry.IsFile)
    {
        File.WriteAllBytes(entry.Name, tarReader.ReadEntryData());
    }
    else if (entry.IsDirectory)
    {
        Directory.CreateDirectory(entry.Name);
    }
}
```

## 🔧 Supported Platforms

TarGenerator targets multiple .NET implementations for maximum compatibility:

| Target Framework | Version | Status |
|------------------|---------|---------|
| .NET Standard | 1.0 - 2.1 | ✅ Planned |
| .NET Framework | 4.5.1, 4.8.1 | ✅ Planned |
| .NET Core | 3.1 | ✅ Planned |
| .NET | 5.0 - 9.0 | ✅ Planned |

## 📦 Installation

> **Coming Soon**: Package will be available on NuGet once initial implementation is complete.

```bash
dotnet add package TarGenerator
```

## 📚 Documentation

### Basic Usage

#### Creating TAR Archives

```csharp
using var tarWriter = new TarWriter(outputStream);

// Add a file with custom metadata
tarWriter.AddFile("path/file.txt", data, new TarEntryOptions
{
    Mode = UnixFileMode.RegularFile | UnixFileMode.UserRead | UnixFileMode.UserWrite,
    ModificationTime = DateTime.UtcNow
});

// Add directory structure
tarWriter.AddDirectory("project/src/");
tarWriter.AddFile("project/src/main.cs", sourceCode);
```

#### Reading TAR Archives

```csharp
using var tarReader = new TarReader(inputStream);

foreach (var entry in tarReader.Entries)
{
    Console.WriteLine($"Entry: {entry.Name} ({entry.Size} bytes)");
    
    if (entry.IsFile)
    {
        var data = tarReader.ReadEntryData();
        // Process file data
    }
}
```

#### Async Operations

```csharp
// Async writing (on supported platforms)
await using var tarWriter = new TarWriter(stream);
await tarWriter.AddFileAsync("large-file.dat", dataStream);
await tarWriter.FlushAsync();

// Async reading
await using var tarReader = new TarReader(stream);
while (await tarReader.GetNextEntryAsync() is TarEntry entry)
{
    var data = await tarReader.ReadEntryDataAsync();
    // Process data
}
```

## 🏗️ Architecture

The library is built with a clean, extensible architecture:

- **Core Layer**: Base classes and interfaces for stream operations
- **TAR Implementation**: POSIX TAR format handling
- **Public API**: High-level, user-friendly interfaces

```
TarGenerator/
├── Core/
│   ├── Interfaces/     # Stream operation contracts
│   ├── TarBase.cs      # Base functionality
│   ├── TarReader.cs    # TAR reading operations
│   └── TarWriter.cs    # TAR writing operations
└── Models/             # TAR entry and header models (planned)
```

## 🔄 TODO List

### Phase 1: Core TAR Implementation
- [ ] **TAR Header Structure**
  - [ ] Implement 512-byte TAR header format
  - [ ] Support all POSIX TAR header fields
  - [ ] Header checksum calculation and validation
  - [ ] Handle long filenames (GNU/POSIX extensions)

- [ ] **File Operations**
  - [ ] Add file entries to TAR archives
  - [ ] Add directory entries to TAR archives
  - [ ] File metadata preservation (permissions, timestamps)
  - [ ] Symbolic link support
  - [ ] Hard link support

- [ ] **Reading/Extraction**
  - [ ] Parse TAR headers correctly
  - [ ] Extract files with proper metadata
  - [ ] Handle different entry types (file, directory, symlink)
  - [ ] Validate archive integrity

### Phase 2: API Enhancement
- [ ] **Public API Design**
  - [ ] `TarEntry` model class
  - [ ] `TarEntryOptions` for metadata
  - [ ] Fluent API for archive building
  - [ ] Progress reporting interfaces

- [ ] **Stream Operations**
  - [ ] Memory-efficient streaming
  - [ ] Large file support (>2GB)
  - [ ] Compression integration hooks
  - [ ] Seekable stream optimization

### Phase 3: Advanced Features
- [ ] **Format Support**
  - [ ] GNU TAR extensions
  - [ ] POSIX.1-2001 (pax) format
  - [ ] Handle sparse files
  - [ ] Unicode filename support

- [ ] **Performance**
  - [ ] Optimize for large archives
  - [ ] Parallel processing options
  - [ ] Memory usage optimization
  - [ ] Benchmark suite

### Phase 4: Quality & Documentation
- [ ] **Testing**
  - [ ] Unit tests (90%+ coverage)
  - [ ] Integration tests with real TAR files
  - [ ] Performance benchmarks
  - [ ] Cross-platform testing
  - [ ] Edge case handling

- [ ] **Documentation**
  - [ ] Complete XML documentation
  - [ ] Usage examples and tutorials
  - [ ] Performance guidelines
  - [ ] Migration guides

- [ ] **NuGet Package**
  - [ ] Package metadata completion
  - [ ] Semantic versioning strategy
  - [ ] Release notes automation
  - [ ] Symbol packages

### Phase 5: DevOps & Maintenance
- [ ] **CI/CD Pipeline**
  - [ ] GitHub Actions workflow
  - [ ] Automated testing on multiple platforms
  - [ ] Automatic NuGet publishing
  - [ ] Code quality gates

- [ ] **Community**
  - [ ] Contributing guidelines
  - [ ] Issue templates
  - [ ] Code of conduct
  - [ ] Release process documentation

## 🧪 Testing

```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## 🤝 Contributing

Contributions are welcome! This is an open-source learning project.

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- TAR format specification: [POSIX.1-2001](https://pubs.opengroup.org/onlinepubs/9699919799/utilities/pax.html)
- Inspired by the need for a simple, cross-platform TAR library in .NET

---

**Note**: This is a work-in-progress library. Star ⭐ the repository to follow development progress!