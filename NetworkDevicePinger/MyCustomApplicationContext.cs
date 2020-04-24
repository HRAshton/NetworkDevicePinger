using NetworkDevicePinger.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace NetworkDevicePinger
{
    static partial class Program
    {
        public class MyCustomApplicationContext : ApplicationContext
        {
            private readonly NotifyIcon trayIcon;
            private readonly Pinger pinger;
            private readonly Timer timer;
            private readonly string targetIp;

            private DateTime LastPinged;
            private uint FailedAttempts;

            public MyCustomApplicationContext()
            {
                targetIp = File.ReadAllText("ip.conf");

                pinger = new Pinger();

                trayIcon = new NotifyIcon()
                {
                    Icon = Resources.Trayicon,
                    ContextMenu = new ContextMenu(new MenuItem[] {
                        new MenuItem("Прекратить проверку", Exit)
                    }),
                    Visible = true,
                    Text = "Проверщик телефона на подключенность к WiFi"
                };

                trayIcon.Click += (s, o) =>
                {
                    trayIcon.ShowBalloonTip(10000, "Последний раз телефон был доступен", LastPinged.ToString(), ToolTipIcon.Info);
                };

                timer = new Timer
                {
                    Enabled = true,
                    Interval = 2500
                };
                timer.Tick += (s, o) =>
                {
                    if (pinger.PingHost(targetIp))
                    {
                        FailedAttempts = 0;
                        LastPinged = DateTime.Now;
                    } 
                    else
                    {
                        FailedAttempts++;
                    }

                    if (FailedAttempts > 5)
                    {
                        FailedAttempts = 0;
                        trayIcon.ShowBalloonTip(10000, "Проверщик телефона", "Не могу найти телефон.\r\nОн отключен?", ToolTipIcon.Warning);
                    }
                };
            }

            void Exit(object sender, EventArgs e)
            {
                trayIcon.Visible = false;

                Application.Exit();
            }
        }
    }
}
