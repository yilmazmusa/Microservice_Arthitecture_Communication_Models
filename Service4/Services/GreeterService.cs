using Grpc.Core;
using Service4;

namespace Service4.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override async Task SayHello(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            await Task.Run(() =>
             {
                 int count = 0;
                 while(++ count <= 10)
                 {
                     responseStream.WriteAsync( new HelloReply() { Message = $"G�nderilen Mesaj : {count}" });
                 }
             });
        }
    }
}