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
|            Utf8JsonSerializer |   250.03 ns |  19.578 ns | 1.1062 ns |   1.00 |     0.00 | 0.0277 |      - |     176 B |
|         SpreadsJsonSerializer |   156.40 ns |  10.736 ns | 0.6066 ns |   0.63 |     0.00 | 0.0279 |      - |     176 B |
|             MessagePackCSharp |    80.65 ns |  14.930 ns | 0.8436 ns |   0.32 |     0.00 | 0.0101 |      - |      64 B |
| MessagePackCSharpContractless |   143.62 ns |   7.962 ns | 0.4499 ns |   0.57 |     0.00 | 0.0226 |      - |     144 B |
|                   Protobufnet |   478.21 ns |  32.458 ns | 1.8339 ns |   1.91 |     0.01 | 0.0887 |      - |     560 B |
|                           Jil |   504.32 ns |  10.025 ns | 0.5664 ns |   2.02 |     0.01 | 0.2317 |      - |    1464 B |
|                 JilTextWriter |   691.25 ns |  72.427 ns | 4.0923 ns |   2.76 |     0.02 | 0.9184 | 0.0010 |    5784 B |
|                       NetJson |   527.21 ns |  26.516 ns | 1.4982 ns |   2.11 |     0.01 | 0.1326 |      - |     840 B |
|                       JsonNet | 1,491.23 ns | 138.066 ns | 7.8010 ns |   5.96 |     0.03 | 0.3147 |      - |    1984 B |
