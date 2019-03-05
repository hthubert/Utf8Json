# Spreads.Utf8Json

The fastest Json serialization for .NET Core.

A faster fork of [Utf8Json](https://github.com/neuecc/Utf8Json) that
 could deserialize from native memory directly. 
All docs and API are the same.

Optimized to 2.3x faster deserialization and 2.0x faster serialization 
on x64 .NET Standard / .NET Core 2.1 than the original Utf8Json 
(measured in operations per second). The numbers are using the original
benchmark that does not include double conversion. This fork improved to 
some extent double conversion speed as well (+37%/+61% vs base with an 
additional double field). 
See [`docs/results`](https://github.com/Spreads/Utf8Json/tree/direct_buffer/docs/results) 
folder for the numbers.

![image](https://raw.githubusercontent.com/Spreads/Utf8Json/direct_buffer/docs/results/comparison.png)

This fork could deserialize from native memory without copying, 
which effectively makes it even faster for applications that need
 this functionality (and that was the reason for this fork).

Compared to the "default" Json.NET library, this implementation is 10+x times faster for serialization 
and 15+x times faster for deserialization. Also writing 
[custom formatters](https://github.com/Spreads/Spreads/blob/c22af654cd3d3c7c404f07d793cfe595ef657528/src/Spreads.Core/DataTypes/Timestamp.cs#L187)
 is much simpler (personal taste) and they are super fast as well.

Public API is almost the same as in the original project and resides in `Spreads.Serialization.Utf8Json` 
namespace. (`JsonReader` used `DirectBuffer` instead of `byte[]` - this is the only change in public API).

Branch `spreads` has almost all changes responsible for serialization speedup and was sent to 
upstream [as a PR](https://github.com/neuecc/Utf8Json/pull/88) earlier. (`EnsureCapacity` was not 
inlined, this probably gives 90% of the difference).

Modifications in the `direct_buffer` branch are licensed as MPL 2.0 since they are a part of Spreads.Core. 

Based on original Utf8Json by Yoshifumi Kawai licensed as MIT. Many thanks to the author for such beautifully simple and powerful code!

## Building

Any work with the source code is supposed to be happening from [Spreads](https://github.com/Spreads/Spreads) repository
which contains this repository as a [submodule](https://github.com/Spreads/Spreads/tree/master/lib).
This library has relative-path imports of files from [Spreads.Core](https://github.com/Spreads/Spreads/tree/master/src/Spreads.Core)
so that it could be build as a standalone dll and unit tests could run.

## Install

Spreads.Utf8Json is a part of Spreads.Core binary distribution and is a fallback serialization mechanism in Spreads. 

The recommended way to use this library is to install [Spreads.Core](https://www.nuget.org/packages/Spreads.Core) package.

A package [Spreads.Utf8Json](https://www.nuget.org/packages/Spreads.Utf8Json) may be available with ad-hoc maintainance and 
updates.
