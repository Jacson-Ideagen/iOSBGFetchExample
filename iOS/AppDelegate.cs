using System;
using Foundation;
using UIKit;

namespace iOSBGFetchExample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Console.WriteLine("FinishedLaunching Called...");
            App.Initialize();

            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(300);



            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            Console.WriteLine("OnResignActivation Called...");
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            Console.WriteLine("DidEnterBackground Called...");
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            Console.WriteLine("WillEnterForeground Called...");
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            Console.WriteLine("OnActivated Called...");
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            Console.WriteLine("WillTerminate Called...");
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        public override async void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
        {
            Console.WriteLine("PerformFetch called...");

            //Return no new data by default
            var result = UIBackgroundFetchResult.NoData;

            try
            {
                var someResult = true;
                if (someResult)
                {
                    result = UIBackgroundFetchResult.NewData;
                }
            }
            catch
            {
                //Indicate a failed fetch if there was an exception
                result = UIBackgroundFetchResult.Failed;
            }
            finally
            {
                //We really should call the completion handler with our result
                completionHandler(result);
            }
        }
    }
}
