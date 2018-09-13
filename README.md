# Spreads.Utf8Json

The fastest Json serialization for .NET Core.

Based on [Utf8Json](https://github.com/neuecc/Utf8Json). All docs and API are the same.

Optimized to 107% faster deserialization and 60% faster serialization on x64 .NET Standard / .NET Core 2.1 than the original Utf8Json (measured in operations per second). The numbers are using the original benchmark that does not include double conversion. This fork improved to some extent double conversion speed as well (+37%/+61% vs base wi th an additional double field). See [`docs/results`](https://github.com/Spreads/Utf8Json/tree/direct_buffer/docs/results) folder for the numbers. The benchmark is run from the upstream clone with `Spreads.Core` NuGet dependency.

![image](https://raw.githubusercontent.com/Spreads/Utf8Json/direct_buffer/docs/results/comparison.png)

This fork could deserialize from native memory without copying, which effectively makes it even faster for applications that need this functionality (and that was the reason for this fork).

Compared to the "default" Json.NET library, this implementation is 9.5x times faster for serialization and 15.5x times faster for deserialization. Also writing [custom formatters](https://github.com/Spreads/Spreads/blob/37c588b9284ecd1737839507fd092e764496aba6/src/Spreads.Core/DataTypes/Price.cs#L491) is much simpler (personal taste) and they are super fast as well.

Modifications in the `direct_buffer` branch are licensed as MPL 2.0. This fork is distributed in binary form as a part of [Spreads.Core](https://github.com/Spreads/Spreads) [NuGet package](https://www.nuget.org/packages/Spreads.Core) and depends on [`DirectBuffer`](https://github.com/Spreads/Spreads/blob/master/src/Spreads.Core/Buffers/DirectBuffer.cs) and some other data structures from there. Source is included in Spreads.Core as git submodule and probably does not compile as a standalone project (haven't tried so far).

Public API is almost the same as in the original project and resides in `Spreads.Serialization.Utf8Json` namespace. (`JsonReader` used `DirectBuffer` instead of `byte[]` - this is the only change in public API).

Branch `spreads` has almost all changes responsible for serialization speedup and was sent to upstream [as a PR](https://github.com/neuecc/Utf8Json/pull/88) earlier. (`EnsureCapacity` was not inlined, this probably gives 90% of the difference).

This fork could be slower than the original on x86, likely doesn't work on Unity and only .NET Standard will be supported going forward.

Based on original Utf8Json by Yoshifumi Kawai licensed as MIT. Many thanks to the author for such beautifully simple and powerful code!
