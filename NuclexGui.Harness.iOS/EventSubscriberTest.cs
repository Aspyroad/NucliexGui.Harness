using System;

namespace NuclexGui.Harness
{
    public class CarUsing
    {
        static void Main1(string[] args)
        {
            //private object poo = new object();
            Car car = new Car();
            car.Speed = 25;
            car.SpeedChanged += new SpeedChangedEventHandler(CarSpeedChanged);
            car.Speed = 50;
            car.SpeedChanged -= new SpeedChangedEventHandler(CarSpeedChanged);
            car.Speed = 75;
        }

        static void CarSpeedChanged(object source, SpeedChangedEventArgs e)
        {
            Console.WriteLine("Car speed changed from {0} to {1}",
            e.OldSpeed, e.NewSpeed);
        }


        /* OUTPUT

        Car speed changed from 25 to 50

        */

    }

    public class SpeedChangedEventArgs : EventArgs
    {
        int _oldSpeed;
        int _newSpeed;

        public int OldSpeed
        {
            get
            {
                return _oldSpeed;
            }
            set
            {
                _oldSpeed = value;
            }
        }

        public int NewSpeed
        {
            get
            {
                return _newSpeed;
            }
            set
            {
                _newSpeed = value;
            }
        }
    }
    
}
