param([string]$buildConfig) 

if (-Not $buildConfig)
{
    Write-Host "Build Configuration parameter not set. Quitting.." 
    exit
}

ls ..\src\proto\*.proto | %{.\protoc.exe --proto_path=..\src\proto\ --csharp_out=..\src\csharp\auspex-protobuf-rabbitmq-entities\Auspex.Protobuf.RabbitMQ.Entities\Messages\ ("..\src\proto\" + $_.Name)}
cd ..\src\csharp\auspex-protobuf-rabbitmq-entities\Auspex.Protobuf.RabbitMQ.Entities\
dotnet restore
dotnet build --configuration $buildConfig
dotnet pack --configuration $buildConfig