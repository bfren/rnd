# Changelog

All notable changes to Rnd are listed here. The format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

Entries up to 10.4.0 come from the GitHub release notes. The 11.0.0 entry comes from the commits and pull requests, and includes everything in `11.0.0-beta.1` (18 November 2026). The `v10.2.7` tag and the nine `8.1.0` betas, from `8.1.0-beta.220315.1` (15 March 2022) to `8.1.0-beta.220326.1` (26 March 2022), had no release notes and are not listed.

## [Unreleased]

## [11.0.0] - 2026-11-26

### Changed

- **Breaking:** `StringF.ShortWordList` and `StringF.LongWordList` are `Lazy<ImmutableArray<string>>` instead of `Lazy<string[]>`, so callers can't change the built-in lists.
- **Breaking:** `StringF.Passphrase` takes its word list as `IReadOnlyList<string>` instead of `string[]`. Arrays and lists still work, but code built against 10.x must be rebuilt.
- **Breaking:** setting `Rnd.Generator` to `null` throws `ArgumentNullException`.
- **Breaking:** `Chars.Special` uses only ASCII characters: `£` and `¬` are replaced by `%` and `?`.
- `StringF.Get` and `Rnd.Str` build the characters for each combination of classes once, instead of on every call.
- Passphrases from the built-in word lists skip the check for empty words.
- XML doc comments checked and corrected throughout, including the `10000` to `19999` range of the `Rnd` number properties.

### Fixed

- Random dates were not uniform: some days of the month were up to four times as likely as others. `DateF.Get`, `DateTimeF.Get`, `Rnd.Date` and `Rnd.DateTime` now make every date from 1 January 0001 to 31 December 9999 equally likely.
- `NumberF.GetSingle` and `NumberF.GetDouble` could return a value just above `max` because of rounding.
- `StringF.Get` with only undefined `Chars` flags throws `InvalidCharsException`, instead of an unrelated exception. Undefined flags alongside defined ones are ignored.
- The `MaximumLessThanMinimumException` from `CharF.Get` named `CharF` instead of `Get`.
- The long word list had `FALSE` in upper case. It is now `false`.

## [10.4.0] - 2026-11-13

### Added

- .NET 11 as a target framework.

### Changed

- Packages are published to NuGet with trusted publishing.
- Updated packages.

## [10.3.0] - 2026-11-07

### Added

- `IRng.Fill(Span<byte>)`, so random numbers no longer allocate. It has a default implementation, so existing `IRng` implementations still work.

### Changed

- **Breaking:** `Rnd.Guid` and `GuidF.Get` return random version 4 GUIDs on every target framework, instead of version 7 GUIDs on .NET 9 and later.
- **Breaking:** `StringF.Get` throws `InvalidCharsException` for a length of `0` or less.
- **Breaking:** `NumberF.GetDouble` and `NumberF.GetSingle` throw `ArgumentOutOfRangeException` for NaN or infinity.
- **Breaking:** `StringF.Passphrase` throws `InvalidPassphraseException` when the word list contains a `null` or empty word.
- Booleans, dates, times and shuffles use `Rnd.Generator`, so a custom `IRng` supplies every random byte.

### Fixed

- Random integers were biased: the smallest and largest values were half as likely as the rest.
- 64- and 128-bit random integers didn't use all of their random bits.
- Combining `Hexademical` with `Number` or `Upper` counted the shared characters twice.

## [10.2.9] - 2026-10-23

### Changed

- Updated packages.

## [10.2.8] - 2026-09-16

### Changed

- Updated packages.

## [10.2.6] - 2026-08-14

### Changed

- Updated packages.

## [10.2.5] - 2026-07-03

### Changed

- Updated packages.

## [10.2.4] - 2026-05-16

### Changed

- Updated packages.

## [10.2.3] - 2026-04-22

### Changed

- Updated packages.

## [10.2.2] - 2026-03-06

### Changed

- `Rnd.Guid` and `GuidF.Get` return RFC 4122 GUIDs: version 7 on .NET 9 and later, version 4 before that. They used to be 16 random bytes.
- Performance improvements, including `StringF.Passphrase`.
- Improved XML doc comments for the number and time functions.
- Updated packages.

## [10.2.1] - 2026-02-17

### Changed

- Updated packages.

## [10.2.0] - 2026-01-29

### Added

- `NumberF.GetInt128` and `NumberF.GetUInt128`, and the `Rnd.Int128` and `Rnd.UInt128` properties.
- The `Rnd.Single` and `Rnd.Double` properties.

### Removed

- **Breaking:** the `Rnd.Dbl`, `Rnd.Sht`, `Rnd.Ptr`, `Rnd.USht`, `Rnd.UInt`, `Rnd.ULng` and `Rnd.UPtr` properties. Use `Rnd.Double`, `Rnd.Int16`, `Rnd.IntPtr`, `Rnd.UInt16`, `Rnd.UInt32`, `Rnd.UInt64` and `Rnd.UIntPtr`.

## [10.1.3] - 2026-01-29

### Added

- `Rnd` number properties named after their full type: `Int16`, `Int32`, `Int64`, `IntPtr`, `UInt16`, `UInt32`, `UInt64` and `UIntPtr`.

## [10.1.2] - 2026-01-27

### Changed

- The copyright year is 2026.

## [10.1.1] - 2026-01-24

### Changed

- No changes to the library. The tests moved to xUnit v3.

## [10.1.0] - 2026-01-18

### Added

- `CharF.Get` and `Rnd.Char` for random characters.

### Changed

- Updated packages.

## [10.0.3] - 2025-11-21

### Added

- .NET 10 as a target framework.

## [10.0.2] - 2025-10-17

### Changed

- The copyright year is 2025.
- Updated packages.

## [10.0.1] - 2025-08-20

### Changed

- Updated packages.

## [10.0.0] - 2025-07-04

### Changed

- Updated packages.

### Removed

- **Breaking:** .NET 6 and 7 as target frameworks.

## [9.2.2] - 2025-04-04

### Changed

- Updated packages.

## [9.2.1] - 2025-02-28

### Changed

- Updated packages.

## [9.2.0] - 2024-11-15

### Added

- .NET 9 as a target framework.

## [9.1.1] - 2024-10-18

### Added

- `NumberF.GetIntPtr` and `NumberF.GetUIntPtr`, and the `Rnd.Ptr` and `Rnd.UPtr` properties, for `nint` and `nuint`.

## [9.1.0] - 2024-10-18

### Added

- The `Rnd.Sodium` package: an `IRng` that uses libsodium.
- `NumberF.GetInt16` and `NumberF.GetUInt16`, and the `Rnd.Sht` and `Rnd.USht` properties, for `short` and `ushort`.

## [9.0.4] - 2024-10-18

### Changed

- Updated packages.

## [9.0.3] - 2024-07-30

### Changed

- Updated packages.

## [9.0.2] - 2024-06-06

### Changed

- Updated packages.

## [9.0.1] - 2024-04-13

### Changed

- **Breaking:** `Chars` moved to the root `RndF` namespace.
- Updated packages.

## [9.0.0] - 2024-04-01

### Changed

- **Breaking:** character classes are a bitwise `Chars` enum, so classes are combined with `|`.
- The copyright year is 2024.
- Updated packages.

### Removed

- **Breaking:** the dependency on MaybeF. Functions return their value and throw on invalid input, instead of returning `Maybe<T>`.

## [8.5.2] - 2024-03-21

### Changed

- Updated packages.

## [8.5.1] - 2024-03-02

### Changed

- Updated packages.

## [8.5.0] - 2024-01-01

### Added

- .NET 8 as a target framework.
- `StringF.ShortWordList` and `StringF.LongWordList` are public.

### Changed

- More US spellings replaced in the word lists.

## [8.4.10] - 2023-10-28

### Fixed

- Loading the hexadecimal characters.

## [8.4.9] - 2023-10-28

### Added

- The `Hexademical` character class for `StringF`.

### Changed

- US spellings removed from the word lists.
- Updated packages.

## [8.4.8] - 2023-10-10

### Changed

- Updated packages.

## [8.4.7] - 2023-08-10

### Changed

- Updated packages.

## [8.4.6] - 2023-07-28

### Changed

- Updated packages.

## [8.4.5] - 2023-06-15

### Changed

- Updated packages.

## [8.4.4] - 2023-02-15

### Changed

- The copyright year is 2023.
- Updated packages.

## [8.4.3] - 2023-01-18

### Changed

- Packages are managed centrally.

## [8.4.2] - 2023-01-09

### Changed

- Updated packages.

## [8.4.1] - 2022-11-25

### Changed

- The NuGet package has a logo and more detail.
- Updated packages.

## [8.4.0] - 2022-11-11

### Added

- .NET 7 as a target framework.

### Changed

- Lower-casing uses the invariant culture.
- Updated packages.

## [8.3.2] - 2022-08-14

### Changed

- Updated packages.

## [8.3.1] - 2022-05-15

### Changed

- Passphrases with a number add an extra number for every fifth word.

## [8.3.0] - 2022-05-11

### Removed

- **Breaking:** .NET 7 as a target framework. Rnd targets .NET 6 only.

## [8.2.0] - 2022-05-03

### Changed

- **Breaking:** improved null handling: some functions throw `ArgumentNullException`.

## [8.1.6] - 2022-04-29

### Changed

- Updated packages.

## [8.1.5] - 2022-04-27

### Changed

- Updated packages.

## [8.1.4] - 2022-04-26

### Changed

- Updated packages.

## [8.1.3] - 2022-04-10

### Changed

- `CharacterClass.All` is public.

## [8.1.2] - 2022-04-06

### Changed

- Updated packages.

## [8.1.1] - 2022-03-31

### Changed

- Errors use custom exceptions, and MaybeF `IMsg` instead of `IReason`.

## [8.1.0] - 2022-03-27

### Added

- The EFF short word list.
- .NET 6 and 7 as target frameworks.
- Float generators.
- `Rnd.Date` and `Rnd.Time`.

### Changed

- Date functions return more specific values.
- Word lists are split by comma.

## [8.0.2] - 2022-03-13

### Changed

- **Breaking:** the namespace is `RndF` instead of `Rnd.Generators`, to avoid a clash with the `Rnd` class.

## [8.0.1] - 2022-03-12

### Changed

- The NuGet package links to the project.

## [8.0.0] - 2022-03-12

First release as `Rnd`. It began as [Jeebs.Random](https://github.com/bfren/jeebs/tree/v7.2.2/src/Jeebs.Random), part of [Jeebs](https://github.com/bfren/jeebs), and from v8 has its own repo. Its only dependency is [MaybeF](https://github.com/bfren/maybe).

[Unreleased]: https://github.com/bfren/rnd/compare/v11.0.0...HEAD
[11.0.0]: https://github.com/bfren/rnd/compare/v10.4.0...v11.0.0
[10.4.0]: https://github.com/bfren/rnd/compare/v10.3.0...v10.4.0
[10.3.0]: https://github.com/bfren/rnd/compare/v10.2.9...v10.3.0
[10.2.9]: https://github.com/bfren/rnd/compare/v10.2.8...v10.2.9
[10.2.8]: https://github.com/bfren/rnd/compare/v10.2.6...v10.2.8
[10.2.6]: https://github.com/bfren/rnd/compare/v10.2.5...v10.2.6
[10.2.5]: https://github.com/bfren/rnd/compare/v10.2.4...v10.2.5
[10.2.4]: https://github.com/bfren/rnd/compare/v10.2.3...v10.2.4
[10.2.3]: https://github.com/bfren/rnd/compare/v10.2.2...v10.2.3
[10.2.2]: https://github.com/bfren/rnd/compare/v10.2.1...v10.2.2
[10.2.1]: https://github.com/bfren/rnd/compare/v10.2.0...v10.2.1
[10.2.0]: https://github.com/bfren/rnd/compare/v10.1.3...v10.2.0
[10.1.3]: https://github.com/bfren/rnd/compare/v10.1.2...v10.1.3
[10.1.2]: https://github.com/bfren/rnd/compare/v10.1.1...v10.1.2
[10.1.1]: https://github.com/bfren/rnd/compare/v10.1.0...v10.1.1
[10.1.0]: https://github.com/bfren/rnd/compare/v10.0.3...v10.1.0
[10.0.3]: https://github.com/bfren/rnd/compare/v10.0.2...v10.0.3
[10.0.2]: https://github.com/bfren/rnd/compare/v10.0.1...v10.0.2
[10.0.1]: https://github.com/bfren/rnd/compare/v10.0.0...v10.0.1
[10.0.0]: https://github.com/bfren/rnd/compare/v9.2.2...v10.0.0
[9.2.2]: https://github.com/bfren/rnd/compare/v9.2.1...v9.2.2
[9.2.1]: https://github.com/bfren/rnd/compare/v9.2.0...v9.2.1
[9.2.0]: https://github.com/bfren/rnd/compare/v9.1.1...v9.2.0
[9.1.1]: https://github.com/bfren/rnd/compare/v9.1.0...v9.1.1
[9.1.0]: https://github.com/bfren/rnd/compare/v9.0.4...v9.1.0
[9.0.4]: https://github.com/bfren/rnd/compare/v9.0.3...v9.0.4
[9.0.3]: https://github.com/bfren/rnd/compare/v9.0.2...v9.0.3
[9.0.2]: https://github.com/bfren/rnd/compare/v9.0.1...v9.0.2
[9.0.1]: https://github.com/bfren/rnd/compare/v9.0.0...v9.0.1
[9.0.0]: https://github.com/bfren/rnd/compare/v8.5.1...v9.0.0
[8.5.2]: https://github.com/bfren/rnd/compare/v8.5.1...v8.5.2
[8.5.1]: https://github.com/bfren/rnd/compare/v8.5.0...v8.5.1
[8.5.0]: https://github.com/bfren/rnd/compare/v8.4.10...v8.5.0
[8.4.10]: https://github.com/bfren/rnd/compare/v8.4.9...v8.4.10
[8.4.9]: https://github.com/bfren/rnd/compare/v8.4.8...v8.4.9
[8.4.8]: https://github.com/bfren/rnd/compare/v8.4.7...v8.4.8
[8.4.7]: https://github.com/bfren/rnd/compare/v8.4.6...v8.4.7
[8.4.6]: https://github.com/bfren/rnd/compare/v8.4.5...v8.4.6
[8.4.5]: https://github.com/bfren/rnd/compare/v8.4.4...v8.4.5
[8.4.4]: https://github.com/bfren/rnd/compare/v8.4.3...v8.4.4
[8.4.3]: https://github.com/bfren/rnd/compare/v8.4.2...v8.4.3
[8.4.2]: https://github.com/bfren/rnd/compare/v8.4.1...v8.4.2
[8.4.1]: https://github.com/bfren/rnd/compare/v8.4.0...v8.4.1
[8.4.0]: https://github.com/bfren/rnd/compare/v8.3.2...v8.4.0
[8.3.2]: https://github.com/bfren/rnd/compare/v8.3.1...v8.3.2
[8.3.1]: https://github.com/bfren/rnd/compare/v8.3.0...v8.3.1
[8.3.0]: https://github.com/bfren/rnd/compare/v8.2.0...v8.3.0
[8.2.0]: https://github.com/bfren/rnd/compare/v8.1.6...v8.2.0
[8.1.6]: https://github.com/bfren/rnd/compare/v8.1.5...v8.1.6
[8.1.5]: https://github.com/bfren/rnd/compare/v8.1.4...v8.1.5
[8.1.4]: https://github.com/bfren/rnd/compare/v8.1.3...v8.1.4
[8.1.3]: https://github.com/bfren/rnd/compare/v8.1.2...v8.1.3
[8.1.2]: https://github.com/bfren/rnd/compare/v8.1.1...v8.1.2
[8.1.1]: https://github.com/bfren/rnd/compare/v8.1.0...v8.1.1
[8.1.0]: https://github.com/bfren/rnd/compare/v8.0.2...v8.1.0
[8.0.2]: https://github.com/bfren/rnd/compare/v8.0.1...v8.0.2
[8.0.1]: https://github.com/bfren/rnd/compare/v8.0.0...v8.0.1
[8.0.0]: https://github.com/bfren/rnd/releases/tag/v8.0.0
