using System;

namespace NuclexGui.Harness
{
    public delegate void SpeedChangedEventHandler(object source, SpeedChangedEventArgs e);

    public class Car
    {
        event SpeedChangedEventHandler _speedChangedEventHandler;
        object lockThis = new object();
        int _speed = 0;

        public event SpeedChangedEventHandler SpeedChanged
        {
            add
            {
                lock (lockThis)
                {
                    _speedChangedEventHandler += value;
                }
            }
            remove
            {
                lock (lockThis)
                {
                    _speedChangedEventHandler -= value;
                }
            }
        }

        public virtual void OnSpeedChanged(int oldSpeed, int newSpeed)
        {
            SpeedChangedEventArgs e = new SpeedChangedEventArgs();
            e.OldSpeed = oldSpeed;
            e.NewSpeed = newSpeed;

            if (_speedChangedEventHandler != null)
            {
                _speedChangedEventHandler(this, e);
            }
        }

        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                int oldSpeed = _speed;
                _speed = value;
                OnSpeedChanged(oldSpeed, _speed);
            }
        }
    }
}
