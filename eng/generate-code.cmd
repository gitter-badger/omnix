setlocal

setx DOTNET_CLI_TELEMETRY_OPTOUT 1

if %PROCESSOR_ARCHITECTURE% == x86 (
    set TOOL_PATH=%cd%\tools\win-x86\Omnix.Serialization.RocketPack.CodeGenerator\Omnix.Serialization.RocketPack.CodeGenerator.exe
)

if %PROCESSOR_ARCHITECTURE% == AMD64 (
    set TOOL_PATH=%cd%\tools\win-x64\Omnix.Serialization.RocketPack.CodeGenerator\Omnix.Serialization.RocketPack.CodeGenerator.exe
)

"%TOOL_PATH%" %cd%\formats\FormatterBenchmarks.Internal.rpf %cd%\perf\FormatterBenchmarks\Internal\_RocketPack\Messages.generated.cs

"%TOOL_PATH%" %cd%\formats\Omnix.Cryptography.rpf %cd%\src\Omnix.Cryptography\_RocketPack\Messages.generated.cs

"%TOOL_PATH%" %cd%\formats\Omnix.Network.rpf %cd%\src\Omnix.Network\_RocketPack\Messages.generated.cs

"%TOOL_PATH%" %cd%\formats\Omnix.Network.Connection.Secure.rpf %cd%\src\Omnix.Network.Connection\Secure\_RocketPack\Messages.generated.cs
"%TOOL_PATH%" %cd%\formats\Omnix.Network.Connection.Secure.Internal.rpf %cd%\src\Omnix.Network.Connection\Secure\Internal\_RocketPack\Messages.generated.cs
"%TOOL_PATH%" %cd%\formats\Omnix.Network.Connection.Secure.V1.Internal.rpf %cd%\src\Omnix.Network.Connection\Secure\V1\Internal\_RocketPack\Messages.generated.cs

"%TOOL_PATH%" %cd%\formats\Omnix.Network.Connection.Multiplexer.Internal.rpf %cd%\src\Omnix.Network.Connection\Multiplexer\Internal\_RocketPack\Messages.generated.cs
"%TOOL_PATH%" %cd%\formats\Omnix.Network.Connection.Multiplexer.V1.Internal.rpf %cd%\src\Omnix.Network.Connection\Multiplexer\V1\Internal\_RocketPack\Messages.generated.cs

"%TOOL_PATH%" %cd%\formats\Omnix.Remoting.rpf %cd%\src\Omnix.Remoting\_RocketPack\Messages.generated.cs

"%TOOL_PATH%" %cd%\formats\Omnix.Serialization.RocketPack.CodeGenerator.Tests.Internal.rpf %cd%\tests\Omnix.Serialization.RocketPack.CodeGenerator.Tests\Internal\_RocketPack\Messages.generated.cs
