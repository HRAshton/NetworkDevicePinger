using System.Net.NetworkInformation;

namespace NetworkDevicePinger
{
    static partial class Program
    {
        public class Pinger
        {
            readonly Ping pinger = new Ping();

            public bool PingHost(string nameOrAddress)
            {
                try
                {
                    PingReply reply = pinger.Send(nameOrAddress);

                    return reply.Status == IPStatus.Success;
                }
                catch (PingException)
                {
                    throw new System.Exception("Ошибка сети.");
                }
            }
        }
    }
}
