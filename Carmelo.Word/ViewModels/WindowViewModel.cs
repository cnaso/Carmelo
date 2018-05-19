using Carmelo.Base.ViewModels;
using Carmelo.Word.DataModels;
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

        public int TitleHeight { get; set; } = 36;

        public double WindowMinimumWidth { get; set; } = 400;

        public double WindowMinimumHeight { get; set; } = 400;

        public bool Borderless { get { return (window.WindowState == WindowState.Maximized); } }

        public Thickness ResizedBorderThickness { get { return new Thickness(BorderSize + OuterMarginSize); } }

        public Thickness InnerContentPadding { get { return new Thickness(BorderSize); } }

        public int OuterMarginSize
        {
            get
            {
                return Borderless ? 5 : outerMarginSize;
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

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

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

        #endregion

        public WindowViewModel(Window window)
        {
            this.window = window;

            window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizedBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, getMousePosition()));
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
    }
}
