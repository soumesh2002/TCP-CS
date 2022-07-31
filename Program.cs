using System.Net.Sockets;
/* TCP Client Communication -> C# */
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("enter the name of server: ");
        string? server = Console.ReadLine(); // discarded symbol
        TcpClient client = new TcpClient(server, 80); // 80 -> web port of HTTP
        StreamReader sr = new StreamReader(client.GetStream());
        StreamWriter sw = new StreamWriter(client.GetStream());

        try
        {
            sw.WriteLine("GET / HTTP/1.0\n\n");
            sw.Flush();

            string data = sr.ReadLine();
            while (data != null)
            {
                Console.WriteLine(data);
                data = sr.ReadLine();
            }
            client.Close();
        }
        catch (Exception)
        {

        }
    }
}