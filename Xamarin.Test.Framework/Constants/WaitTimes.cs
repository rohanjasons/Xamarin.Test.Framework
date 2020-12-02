using System;
using Xamarin.UITest.Utils;

namespace Xamarin.Test.Framework.Constants
{
    internal class WaitTimes : IWaitTimes
    {
        public TimeSpan GestureWaitTimeout => TimeSpan.FromSeconds(Timeouts.DefaultTimeoutInSeconds);

        public TimeSpan GestureCompletionTimeout => TimeSpan.FromSeconds(Timeouts.DefaultTimeoutInSeconds);

        public TimeSpan WaitForTimeout => TimeSpan.FromSeconds(Timeouts.DefaultTimeoutInSeconds);
    }
}
