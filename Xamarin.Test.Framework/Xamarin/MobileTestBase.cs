using System;
using Xamarin.Test.Framework.Constants;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace Xamarin.Test.Framework.Xamarin
{
    /// <summary>
    /// The WebTestBase, all tests classes will inherit this class.
    /// </summary>
    public abstract class MobileTestBase
    {
        protected static IApp Application { get; private set; }

        /// <summary>
        /// Installs the application onto the device and starts the application.
        /// </summary>
        /// <param name="platform">Android / iOS platform that is being tested.</param>
        /// <param name="appPath">The location and filename of the application to run.</param>
        /// <param name="deviceIdentifier">The ID of the device we wish to perform the test against.</param>
        /// <returns>An instance of the app object to be used during testing.</returns>
        /// /// <exception cref="ArgumentOutOfRangeException">If invalid platform is sepcified</exception>
        protected static IApp StartAppLocal(Platform platform, string appPath, string deviceIdentifier)
        {
            switch (platform)
            {
                case Platform.Android:
                    Application = ConfigureApp.Android
                        .ApkFile(appPath)
                        .WaitTimes(new WaitTimes())
                        .DeviceSerial(deviceIdentifier)
                        .StartApp(AppDataMode.Clear);
                    break;

                case Platform.iOS:
                    Application = ConfigureApp
                        .iOS
                        .AppBundle(appPath)
                        .DeviceIdentifier(deviceIdentifier)
                        .StartApp();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }

            return Application;
        }

        /// <summary>
        /// Installs the application onto the device and starts the application.
        /// </summary>
        /// <param name="platform">>Android / iOS platform that is being tested.</param>
        /// <param name="packageName">The application to start on the device.</param>
        /// <returns>An instance of the app object to be used during testing.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If invalid platform is sepcified</exception>
        protected static IApp StartAppCloud(Platform platform, string packageName)
        {
            switch (platform)
            {
                case Platform.Android:
                    Application = ConfigureApp.Android
                            .InstalledApp(packageName)
                            .StartApp();
                    break;

                case Platform.iOS:
                    Application = ConfigureApp
                            .iOS
                            .AppBundle(packageName)
                            .StartApp();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }

            return Application;
        }
    }
}
