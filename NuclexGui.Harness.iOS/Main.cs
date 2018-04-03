using UIKit;
using Microsoft.Xna.Framework;
using System;
using Foundation;

namespace NuclexGui_Harness.iOS
{
    #region Entry Point
    //[Register("AppDelegate")]
    //class Program : UIApplicationDelegate
    //{
    //    Game game;
    //    public override void FinishedLaunching(UIApplication application)
    //    {
    //        // Fun begins..
    //        game = new Game1();
    //        game.Run();
    //    }

    //    /// <summary>
    //    /// The main entry point for the application.
    //    /// </summary>
    //    static void Main(string[] args)
    //    {
    //        UIApplication.Main(args, null, "AppDelegate");
    //    }
    //}

    public class Application
    {

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            //Setup our services for core library
            //SharedServiceRegistrar.Startup();

            UIApplication.Main(args, null, "AppDelegate");
        }

    }




    #endregion

}


