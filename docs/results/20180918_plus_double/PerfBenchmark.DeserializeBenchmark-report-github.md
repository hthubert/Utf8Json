``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.112 (1803/April2018Update/Redstone4)
Intel Core i7-8700 CPU 3.20GHz (Max: 3.19GHz) (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.1.402
  [Host]   : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  ShortRun : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT

Job=ShortRun  Jit=RyuJit  Runtime=Core  
Toolchain=.NET Core 2.1  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                        Method |        Mean |      Error |     StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
|------------------------------ |------------:|-----------:|-----------:|-------:|---------:|-------:|----------:|
|            Utf8JsonSerializer |   703.11 ns |  55.437 ns |  3.1323 ns |   1.00 |     0.00 | 0.0086 |      56 B |
|         SpreadsJsonSerializer |   512.76 ns |  22.674 ns |  1.2811 ns |   0.73 |     0.00 | 0.0086 |      56 B |
|             MessagePackCSharp |    86.18 ns |   3.849 ns |  0.2175 ns |   0.12 |     0.00 | 0.0088 |      56 B |
| MessagePackCSharpContractless |   164.06 ns |  14.179 ns |  0.8012 ns |   0.23 |     0.00 | 0.0088 |      56 B |
|                   Protobufnet |   333.51 ns |  44.946 ns |  2.5395 ns |   0.47 |     0.00 | 0.0200 |     128 B |
|                           Jil |   985.38 ns |  53.303 ns |  3.0117 ns |   1.40 |     0.01 | 0.0935 |     592 B |
|                 JilTextReader | 1,312.40 ns | 123.692 ns |  6.9888 ns |   1.87 |     0.01 | 0.5646 |    3560 B |
|                       JsonNet | 3,579.48 ns | 308.573 ns | 17.4349 ns |   5.09 |     0.03 | 0.5455 |    3440 B |
|                       NetJson | 1,504.58 ns | 110.098 ns |  6.2208 ns |   2.14 |     0.01 | 0.1888 |    1200 B |
