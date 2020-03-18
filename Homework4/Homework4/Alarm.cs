//2、使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。
//在闹钟走时时或者响铃时，在控制台显示提示信息。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Alarm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Now it is:" + DateTime.Now.ToLongTimeString().ToString());
            Console.WriteLine("Set the alarm:(xx:xx:xx)");
            string str = Console.ReadLine();
            ClockEvents ce = new ClockEvents();
            ce.ac.Clock(str);
        }
    }

    public delegate void ClockHandler();

    public class AlarmClock
    {
        public event ClockHandler Tick;
        public event ClockHandler Alarm;

        public void Clock(string setTime)
        {
            while (true)
            {
                string time = DateTime.Now.ToLongTimeString().ToString();
                Tick();
                System.Threading.Thread.Sleep(1000);
                if (time == setTime)
                    Alarm();
            }
        }
    }

    public class ClockEvents
    {
        public AlarmClock ac = new AlarmClock();

        public ClockEvents()
        {
            ac.Alarm += Clock_Alarm;
            ac.Tick += Clock_Tick;
        }

        void Clock_Tick()
        {
            Console.WriteLine("Tick" + DateTime.Now.ToLongTimeString().ToString());
        }

        void Clock_Alarm()
        {
            Console.WriteLine("Alarm");
        }
    }
}
