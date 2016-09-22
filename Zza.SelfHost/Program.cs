
using System;
using System.ServiceModel;

namespace Zza.SelfHost
{
    using Services;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = new ServiceHost(typeof(ZzaService));
                host.Open();

                Console.WriteLine("Hit any key to exit");
                host.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }

        }
    }
}
