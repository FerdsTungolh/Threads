using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class Runners
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public int NamePosition { get; set; }
        public int Speed { get; set; }
        public int Timers { get; set; }
        public Random rand = new Random();
        public Runners(string name, int position,int nameposition, int speed) 
        {
            Name = name;
            Position = position;
            NamePosition = nameposition;
            Speed = speed;
            Timers = 0;
        }

        public void Update (int interval, int MapLenght) 
        {
            Timers += interval;
            
            int ranspeed = rand.Next(0, 10);
            if (Timers / 1.5  > Speed+ranspeed)
            {
                Timers = 0;
                Position ++;
                NamePosition++;
                nitro();
            }
        }
        public void nitro()
        {
            int rannitro = rand.Next(0, 2);
            if (rannitro == 1)
            {
                Position ++;
                NamePosition ++;
            }

        }
    }
}
