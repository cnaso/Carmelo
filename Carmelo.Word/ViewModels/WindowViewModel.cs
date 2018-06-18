using Carmelo.Word.Core.Commands;
using Carmelo.Word.Core.DataModels;
using Carmelo.Word.Core.ViewModels.Base;
using Carmelo.Word.Windows;
using System.Windows;
using System.Windows.Input;

namespace Carmelo.Word.ViewModels
{
    /// <summary>
    /// View Model to handle the custom <see cref="MainWindow"/>.
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Public Properties

        public int BorderSize { get { return Borderless ? 0 : 6; } }

        public int TitleHeight { get; set; } = 30;

        public double WindowMinimumWidth { get; set; } = 800;

        public double WindowMinimumHeight { get; set; } = 500;

        public bool Borderless { get { return (window.WindowState == WindowState.Maximized || dockPosition != WindowDockPosition.Undocked); } }

        public Thickness ResizedBorderThickness { get { return new Thickness(BorderSize + OuterMarginSize); } }

        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        public int OuterMarginSize
        {
            get
            {
                return Borderless ? 0 : outerMarginSize;
            }

            set
            {
                outerMarginSize = value;
            }
        }

        public Thickness OuterMarginThickness { get { return new Thickness(OuterMarginSize); } }

        public int WindowRadius
        {
            get
            {
                return Borderless ? 0 : windowRadius;
            }

            set
            {
                windowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + BorderSize); } }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Chat;

        #endregion

        #region Commands

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }

        #endregion

        #region Private Properties

        private Window window;

        private int outerMarginSize = 10;

        private int windowRadius = 10;

        private WindowDockPosition dockPosition = WindowDockPosition.Undocked;

        #endregion

        public WindowViewModel(Window window)
        {
            this.window = window;

            window.StateChanged += (sender, e) =>
            {
                WindowResized();
            };

            MinimizeCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, getMousePosition()));

            var resizer = new WindowResizer(window);

            resizer.WindowDockChanged += (dock) =>
            {
                dockPosition = dock;
                WindowResized();
            };
        }

        /// <summary>
        /// Gets the mouse cursor position point.
        /// </summary>
        /// <returns></returns>
        private Point getMousePosition()
        {
            var position = Mouse.GetPosition(window);

            if (Borderless)
            {
                return new Point(position.X, position.Y);
            }

            return new Point(position.X + window.Left, position.Y + window.Top);
        }

        /// <summary>
        /// Fires property changed events for the window borders and margins.
        /// </summary>
        private void WindowResized()
        {
            OnPropertyChanged(nameof(ResizedBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }
    }
}
