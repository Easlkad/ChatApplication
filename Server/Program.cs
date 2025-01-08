using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting server...");
        TcpListener server = new TcpListener(IPAddress.Any, 1234);
        Console.WriteLine("Starting server...");
        server.Start();
        Console.WriteLine("Server started on port 1234");



        while (true)
        {
            try
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Message received: " + message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
