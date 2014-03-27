using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCClient
{
    class Program
    {
        public static void Main()
        {
            var rpcClient = new RPCClient();

            Console.WriteLine(" [x] Requesting fib(30)");
            var response = rpcClient.Call("30");
            Console.WriteLine(" [.] Got '{0}'", response);

            rpcClient.Close();
        }
    }
}
