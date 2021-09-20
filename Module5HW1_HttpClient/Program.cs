using Module5HW1;
using System;
using System.Threading.Tasks;

namespace Module5HW1_HttpClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            UserClient st = new UserClient();
            await st.Run();
        }
    }
}
