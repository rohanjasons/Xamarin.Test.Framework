using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Xamarin.Test.Framework.Extensions
{
    /// <summary>
    /// Extension class to be used by Xamarin for app testing.
    /// </summary>
    public static class AppExtensions
    {
        /// <summary>
        /// Wait for an element on the page containing the string value.
        /// </summary>
        /// <param name="app">The app that is in use.</param>
        /// <param name="substring">The value to search for in the current page.</param>
        /// <returns>The AppResult that was found.</returns>
        public static AppResult[] WaitForElementContainingText(this IApp app, string substring)
        {
            var rawQuery = $"* {{text CONTAINS '{substring}'}}";
            return app.WaitForElement(e => e.Raw(rawQuery));
        }

        /// <summary>
        /// Take a screen shot of the application.
        /// </summary>
        /// <param name="app">The app that is in use.</param>
        /// <param name="format">String format of the filename.</param>
        /// <param name="args">Args to add to the String formatter.</param>
        public static void Screenshot(this IApp app, string format, params object[] args)
        {
            app.Screenshot(string.Format(format, args));
        }

        /// <summary>
        /// Finds if the current Trait exists on the page.
        /// </summary>
        /// <param name="app">The app that is in use.</param>
        /// <param name="trait">The Trait to search for.</param>
        /// <returns>Result if the trait existed on the page.</returns>
        public static bool TraitExists(this IApp app, Trait trait)
        {
            try
            {
                var results = app.WaitForTrait(trait);
                return results.Any();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Wait for the Trait to exist on the page.
        /// </summary>
        /// <param name="app">The app that is in use.</param>
        /// <param name="trait">The Trait to wait for.</param>
        /// <param name="timeout">The Timespan to wait upto for the Trait to exist.</param>
        /// <returns>The AppResult that was found.</returns>
        public static IEnumerable<AppResult> WaitForTrait(this IApp app, Trait trait, TimeSpan? timeout = null)
        {
            if (timeout == null)
            {
                timeout = TimeSpan.FromSeconds(30);
            }

            var results = app.WaitForElement(trait.Query, "Timed out waiting for this page's trait.", timeout);
            return trait.CheckSubstring ?
                results.Where(e => e.Text.Contains(trait.MatchText)).ToArray()
                    : results;
        }
    }
}