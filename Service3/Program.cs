using Grpc.Net.Client;
using Service4;

var channel = GrpcChannel.ForAddress("https://localhost:7245");

var greetClient = new Greeter.GreeterClient(channel);

var response  = greetClient.SayHello( new HelloRequest { Name = Console.ReadLine() });

await Task.Run(async () =>
{
    while (await response.ResponseStream.MoveNext(new CancellationToken())) ;
    Console.WriteLine($"Gelen Mesaj : {response.ResponseStream.Current.Message}");
});