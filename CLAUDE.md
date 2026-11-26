# Rnd - Development Guidelines for Claude Code

## Project Overview

**Rnd** is a library of cryptographically secure random value generators for .NET:

- **RndF** (NuGet package `Rnd`, namespace `RndF`) - numbers, booleans, bytes, characters, dates and times, GUIDs, strings, passphrases, and array shuffling
- **RndF.Sodium** (NuGet package `Rnd.Sodium`) - an `IRng` that uses libsodium through `Sodium.Core`

Published on [NuGet](https://www.nuget.org/packages/rnd/). User documentation is in the [Wiki](https://github.com/bfren/rnd/wiki).

## Development Workflow

### Building & Testing

```bash
# Restore dependencies
dotnet restore RndF.slnx

# Build solution (-warnaserror fails on any warning, as CI does)
dotnet build RndF.slnx --no-restore --configuration Debug -warnaserror

# Run all tests (Microsoft.Testing.Platform, set in global.json, needs --solution)
dotnet test --solution RndF.slnx --no-restore --no-build --configuration Debug
```

These match the shared CI workflow (`bfren/dotnet/.github/workflows/test.yml`), which runs with `style: false` so the build is the only style check. `dotnet test Test.csproj` finds no tests under Microsoft.Testing.Platform, so always use `--solution`.

The test projects are excluded from Release builds of the solution, so run tests in Debug.

### Supported .NET Versions

Rnd targets **.NET 8, 9, 10 and 11** (`net8.0;net9.0;net10.0;net11.0`, set in `src/Directory.Build.props` and `tests/Directory.Build.props`). Tests run on every target framework. `global.json` sets the test runner only and does not pin an SDK, so the installed SDK must support .NET 11.

## Code Style & Quality

### EditorConfig Rules
The project uses [EditorConfig](https://editorconfig.org) for consistent formatting:
- **Indent**: tabs (size 4) in `.cs` files, 2 spaces in XML/JSON/YAML and project files (`*.csproj`, `*.props`, `*.slnx`), 4 spaces elsewhere
- **Line endings**: LF (`.editorconfig` and `.gitattributes`), so files written by tools that save LF need no conversion. Don't convert files to CRLF.
- **Charset**: UTF-8
- **Trailing whitespace**: Trimmed in every file type except Markdown, where two trailing spaces are a line break
- **File header**: every C# file starts with the two-line `// Rnd: …` / `// Copyright (c) bfren …` header (IDE0073, an error in `src`)

`.editorconfig` only holds settings that differ from the .NET defaults (`dotnet new editorconfig`), and matches Wrap's apart from the file headers.

### Style Checking
The build is the only style gate. `AnalysisLevel` is `11.0-recommended`, pinned so a newer SDK can't add rules that fail CI, and `TreatWarningsAsErrors` is on when `CI=true`, so any warning fails CI while a local build only shows it. The exception is NU1901 (a low-severity vulnerability), which stays a warning: moderate and above fail (`Directory.Packages.props`). Run `dotnet build -warnaserror` to see exactly what CI will reject.

Only a few rules are warnings: IDE0005 (unnecessary `using`), IDE0055 (formatting), IDE0060 (unused parameter), IDE1006 (naming), IDE0073 (file header, an error in `src`), the CA rules in `11.0-recommended`, and the compiler, nullability and XML doc warnings. Every other style preference is a suggestion: it shows in the editor and never fails anything. Use `dotnet format style` to apply fixes, not as a check. Add a pragma only for a single real exception.

### XML Doc Comments
`GenerateDocumentationFile` is on for every build (`src/Directory.Build.props`), and the comments become the NuGet IntelliSense text, so they must be accurate. When writing or correcting them:

**Scope and safety**
- Change only `///` lines. Never change code, and never reorder or rename members while editing docs.
- Describe what the code does now. Read the member body before writing. If the code looks wrong, report it rather than documenting it.
- Some behaviour is intended, not a bug. Document it, don't report it:
  - The number properties on `Rnd` (`Rnd.Int`, `Rnd.Lng`, `Rnd.UInt32`, `Rnd.Double` and the rest) return values between `10000` and `19999` inclusive, not the full range. Callers (for example `Wrap.Testing.IdGenerator`) rely on these small values. The `NumberF.Get*()` methods give the full range.
  - Every function draws its bytes from `Rnd.Generator` except `GuidF.Get`, which calls `Guid.NewGuid`.
  - `NumberF.Get*` ranges are inclusive at both ends, and `min` must be less than `max` (and at least `0` for signed types).

**Content**
- `<summary>`: one sentence in the imperative for methods ("Return a random…", "Generate…") and "Gets…" for properties.
- `<param>`, `<typeparam>` and `<returns>`: one each, matching the signature. Properties get no `<returns>`.
- `<returns>` covers every outcome. For example, `ByteF.Get` returns an empty array when `length` is `0` or less.
- `<exception>` says when it is thrown, e.g. `<exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <paramref name="min"/>.</exception>`.
- `<remarks>`: only for non-obvious behaviour such as null handling, allocation, culture or ranges. Wrap a code sample in `<code>` and escape generics in it as `&lt;T&gt;`.
- Recheck any remark that justifies a design choice against the code and the language as they are now.
- Write keywords as `<see langword="null"/>`, `true` and `false` the same way, and literals or expressions as `<c>…</c>` (so `<c>0</c>`, not `<see langword="0"/>`).
- Say "non-negative" rather than "positive" when `0` is included.

**Reuse**
- Use `<inheritdoc/>` for interface or override members only after you have opened the base member and read its docs. If they are stale or describe another type, write explicit docs instead and report the stale base.
- Use `<inheritdoc cref="…"/>` for overload families. Point it at a member with the same parameter names, otherwise the `<param>` text is lost or wrong.
- Never let a property inherit from a method with parameters: the inherited `<param>` text describes arguments the property doesn't have.

**crefs**
- A cref can also point at an internal or private member (`<see cref="AllChars"/>`), but IntelliSense users can't see those, so prefer `<c>…</c>` with the value in public docs.

**Verify** (both must be clean)
1. `dotnet build <project> --no-restore --no-incremental -warnaserror`: no warnings, including CS1572–CS1574, CS1580, CS1587 and CS1591.
2. In `bin/Debug/net10.0/RndF.xml` (or `RndF.Sodium.xml`), every `cref="…"` must resolve to the intended symbol prefix (`T:` type, `P:` property, `M:` method, `F:` field) and none may start with `!:`.

## Project Structure

```
/src/
  ├── RndF/                # Main library (package Rnd)
  │   ├── Exceptions/      # Exceptions thrown by the generators
  │   ├── Extensions/      # Array extensions (Shuffle)
  │   ├── Functions/       # Rnd.BooleanF, ByteF, CharF, DateF, DateTimeF, GuidF, NumberF, StringF, TimeF
  │   ├── Properties/      # Word lists (Resources.resx; Resources.Designer.cs is generated)
  │   └── Rnd*.cs          # Rnd shortcut properties (Rnd.Int, Rnd.Str, Rnd.Guid…) and Rnd.For
  └── RndF.Sodium/         # libsodium IRng (package Rnd.Sodium)

/tests/
  ├── Tests.RndF/
  └── Tests.RndF.Sodium/
```

## Key Implementation Notes

### Random Generation
- **One source of bytes**: `Rnd.Generator` (an `IRng`, default `DefaultRng` using `RandomNumberGenerator`) supplies every random byte. Implement `IRng.Fill(Span<byte>)` to avoid an allocation per call.
- **Integers**: `NumberF.GetInRange` draws uniformly without modulo bias. Public `NumberF.Get*` methods check their arguments and then call it.
- **Floating point**: `NumberF.Get()` returns `0` to `1` inclusive and the `GetSingle`/`GetDouble` methods scale it.
- **Shortcut properties**: the `Rnd` properties (`Rnd.Int`, `Rnd.Str`, `Rnd.Pass`…) are for tests and keep values small and readable.

### Testing
- xUnit v3 on Microsoft.Testing.Platform, with `Using Include="Xunit"` and implicit usings in `tests/Directory.Build.props`
- Internals are visible to `Tests.<ProjectName>`
- Test classes must be `public`, including the outer class of nested test classes. xUnit silently skips an `internal` class, so its tests never run.
- `Helpers` (e.g. `Helpers.CheckBounds`, `Helpers.MaximumLessThanMinimum`) holds the shared assertions; use them for new number tests

## Guidelines for Changes

### When Adding Features
1. Add to the matching `Functions/<Type>F` folder, or `Rnd*.cs` for a shortcut property
2. Add corresponding tests
3. Build with `-warnaserror` and fix every warning
4. Ensure all tests pass on every target framework

### When Fixing Bugs
1. Add a test case that reproduces the bug first, and check that it fails
2. Fix the bug in the implementation
3. Verify the test passes
4. Run full test suite to check for regressions

### When Updating Dependencies
- Changes to Directory.Packages.props affect all projects
- Verify all tests pass after dependency updates

### Before Acting
Ask first before deleting files or branches, resetting history, force-pushing, changing CI workflows, or pushing to `main`.

## License

MIT - Copyright (c) 2021-2026 bfren (unless otherwise stated)
