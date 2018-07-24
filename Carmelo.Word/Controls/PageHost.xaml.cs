using System.Windows;
using System.Windows.Controls;

namespace Carmelo.Word
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        /// <summary>
        /// The current page to show in the page host.
        /// </summary>
        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        /// <summary>
        /// Registers <see cref="CurrentPage"/> as a DependencyProperty. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        public PageHost()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The dependency object property changed event arguments.</param>
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            // Store current page content as the old page.
            var oldPageContent = newPageFrame.Content;

            // Remove current page from the new page frame.
            newPageFrame.Content = null;

            // Set current page content to the old page frame.
            oldPageFrame.Content = oldPageContent;

            // Animate old page out when moving frames.
            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;
            }

            // Set the new page content.
            newPageFrame.Content = e.NewValue;
        }
    }
}
