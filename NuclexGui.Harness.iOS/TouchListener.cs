using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using MonoGame.Extended.ViewportAdapters;

namespace MonoGame.Extended.Input.InputListeners
{
    public class TouchListener : InputListener
    {
        public TouchListener()
            : this(new TouchListenerSettings())
        {
            Init();
        }

        public TouchListener(ViewportAdapter viewportAdapter)
            : this(new TouchListenerSettings())
        {
            ViewportAdapter = viewportAdapter;
            Init();
        }

        public TouchListener(TouchListenerSettings settings)
        {
            ViewportAdapter = settings.ViewportAdapter;
            Init();
        }

        public ViewportAdapter ViewportAdapter { get; set; }

        public event EventHandler<TouchEventArgs> TouchStarted;
        public event EventHandler<TouchEventArgs> TouchEnded;
        public event EventHandler<TouchEventArgs> TouchMoved;
        public event EventHandler<TouchEventArgs> TouchCancelled;

        internal void Init()
        {
            TouchPanel.EnabledGestures =
                //GestureType.Hold |
                GestureType.Tap | GestureType.DoubleTap;
                //GestureType.FreeDrag |
                //GestureType.Flick |
                //GestureType.Pinch;
        }

        public override void Update(GameTime gameTime)
        {
            var touchCollection = TouchPanel.GetState();

            if (TouchPanel.IsGestureAvailable)
            {
                var gesture = TouchPanel.ReadGesture();
                if (gesture.GestureType == GestureType.Tap)
                {
                    int x = 0;
                }
                if (gesture.GestureType == GestureType.DoubleTap)
                {
                    int y = 0;
                }



            }

            foreach (var touchLocation in touchCollection)
            {
                switch (touchLocation.State)
                {
                    case TouchLocationState.Pressed:
                        TouchStarted?.Invoke(this, new TouchEventArgs(ViewportAdapter, gameTime.TotalGameTime, touchLocation));
                        break;
                    case TouchLocationState.Moved:
                        TouchMoved?.Invoke(this, new TouchEventArgs(ViewportAdapter, gameTime.TotalGameTime, touchLocation));
                        break;
                    case TouchLocationState.Released:
                        TouchEnded?.Invoke(this, new TouchEventArgs(ViewportAdapter, gameTime.TotalGameTime, touchLocation));
                        break;
                    case TouchLocationState.Invalid:
                        TouchCancelled?.Invoke(this, new TouchEventArgs(ViewportAdapter, gameTime.TotalGameTime, touchLocation));
                        break;
                }
            }
        }
    }
}