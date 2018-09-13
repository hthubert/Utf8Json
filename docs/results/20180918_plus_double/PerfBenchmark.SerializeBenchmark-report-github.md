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
|                        Method |        Mean |      Error |    StdDev | Scaled | ScaledSD |  Gen 0 |  Gen 1 | Allocated |
|------------------------------ |------------:|-----------:|----------:|-------:|---------:|-------:|-------:|----------:|
|            Utf8JsonSerializer |   494.67 ns | 144.493 ns | 8.1641 ns |   1.00 |     0.00 | 0.0315 |      - |     200 B |
|         SpreadsJsonSerializer |   307.80 ns |  10.937 ns | 0.6179 ns |   0.62 |     0.01 | 0.0315 |      - |     200 B |
|             MessagePackCSharp |    91.48 ns |   9.534 ns | 0.5387 ns |   0.18 |     0.00 | 0.0113 |      - |      72 B |
| MessagePackCSharpContractless |   142.37 ns |  10.604 ns | 0.5992 ns |   0.29 |     0.00 | 0.0226 |      - |     144 B |
|                   Protobufnet |   501.18 ns | 157.737 ns | 8.9124 ns |   1.01 |     0.02 | 0.0887 |      - |     560 B |
|                           Jil |   712.08 ns | 162.141 ns | 9.1613 ns |   1.44 |     0.02 | 0.2546 |      - |    1608 B |
|                 JilTextWriter |   935.12 ns |  78.353 ns | 4.4271 ns |   1.89 |     0.03 | 0.9289 | 0.0076 |    5848 B |
|                       NetJson |   735.88 ns |  39.126 ns | 2.2107 ns |   1.49 |     0.02 | 0.1554 |      - |     984 B |
|                       JsonNet | 2,045.59 ns |  19.479 ns | 1.1006 ns |   4.14 |     0.06 | 0.3395 |      - |    2152 B |
