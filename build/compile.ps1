ls ..\src\proto\*.proto | %{.\protoc.exe --proto_path=..\src\proto\ --csharp_out=..\src\csharp\auspex-protobuf-rabbitmq-entities\Auspex.Protobuf.RabbitMQ.Entities\Messages\ ("..\src\proto\" + $_.Name)}
cd ..\src\csharp\auspex-protobuf-rabbitmq-entities\Auspex.Protobuf.RabbitMQ.Entities\
dotnet restore
dotnet build
dotnet pack