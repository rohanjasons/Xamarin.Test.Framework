using Xamarin.UITest;
using Query = System.Func<global::Xamarin.UITest.Queries.AppQuery, global::Xamarin.UITest.Queries.AppQuery>;
using WebQuery = System.Func<global::Xamarin.UITest.Queries.AppQuery, global::Xamarin.UITest.Queries.AppWebQuery>;

namespace Xamarin.Test.Framework.Xamarin
{
    /// <summary>
    /// The Xamarin Base Page, Holding the App and Trait for the test run.
    /// </summary>
    public abstract class BaseScreen
    {
        /// <summary>
        /// Gets or sets the Trait that is to be used in the Page.
        /// </summary>
        public Trait Trait { get; protected set; }

        /// <summary>
        /// Gets or sets the App that is in use during the test run.
        /// </summary>
        private IApp App { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseScreen"/> class.
        /// The class initialiser to set the app object for the test run.
        /// </summary>
        /// <param name="app">The App that is being used during the test run.</param>
        protected BaseScreen(IApp app)
        {
            App = app;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseScreen"/> class.
        /// The class initialiser to set the app object for the test run.
        /// </summary>
        /// <param name="app">The App that is being used during the test run.</param>
        /// <param name="query">The query that is used to validate whether the correct page has been loaded.</param>
        protected BaseScreen(IApp app, Query query)
        {
            App = app;
        }

        protected BaseScreen(IApp app, WebQuery query)
        {
            App = app;
        }
    }
}