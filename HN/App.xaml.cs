using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using voidsoft.HackerNews;
using voidsoft.HackerNews.Context;

namespace HN
{
    public partial class App : Application
    {
        private bool phoneApplicationInitialized;

        /// <summary>
        /// 	Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Show graphics profiling information while debugging.
            if (Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                //  Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are being GPU accelerated with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;
            }

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();


            CheckForFirstTimeUse();
        }

        /// <summary>
        /// 	Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame
        {
            get;
            private set;
        }


        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            if (PhoneApplicationService.Current.State.ContainsKey("news"))
            {
                Cached.LoadedNews = (CachedNews) PhoneApplicationService.Current.State["news"];
            }

            if (PhoneApplicationService.Current.State.ContainsKey("newitems"))
            {
                Cached.LoadedNewItems = (CachedNews) PhoneApplicationService.Current.State["newitems"];
            }

            if (PhoneApplicationService.Current.State.ContainsKey("ask"))
            {
                Cached.LoadedAskHnItems = (CachedNews) PhoneApplicationService.Current.State["ask"];
            }

            if (PhoneApplicationService.Current.State.ContainsKey("context"))
            {
                ApplicationNavigationContext.Context = (NavigationContextData) PhoneApplicationService.Current.State["context"];
            }
        }


        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            PhoneApplicationService.Current.State["news"] = Cached.LoadedNews;

            PhoneApplicationService.Current.State["newitems"] = Cached.LoadedNewItems;

            PhoneApplicationService.Current.State["ask"] = Cached.LoadedAskHnItems;

            //save context
            PhoneApplicationService.Current.State["context"] = ApplicationNavigationContext.Context;
        }

        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute if a navigation fails

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        // Avoid double-initialization

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
            {
                RootVisual = RootFrame;
            }

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                Debugger.Break();
            }
        }

        private void CheckForFirstTimeUse()
        {
            try
            {
                SettingsManager.LoadSettings();
            }
            catch (Exception ex)
            {
            }

            if (ApplicationContext.UsersSettings.OpenLinksInExternalBrowser == false && string.IsNullOrEmpty(ApplicationContext.UsersSettings.TextTemplate))
            {
                ApplicationContext.UsersSettings.OpenLinksInExternalBrowser = false;
                ApplicationContext.UsersSettings.TextTemplate = "medium";

                SettingsManager.SaveSettings();
            }
        }

        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
            {
                return;
            }

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }
    }
}