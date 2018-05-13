using Carmelo.Base.ViewModels;
using System.Windows;
using System.Windows.Input;
using System;

namespace Carmelo.Word.ViewModels
{
    /// <summary>
    /// View Model to handle the custom Window.
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {

        #region Public Properties

        public int BorderSize { get; set; } = 6;

        public int TitleHeight { get; set; } = 36;

        public Thickness ResizeBorderThickness { get { return new Thickness(BorderSize + OuterMarginSize); } }

        public int OuterMarginSize
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : outerMarginSize;
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
                return window.WindowState == WindowState.Maximized ? 0 : windowRadius;
            }

            set
            {
                windowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + BorderSize); } }

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
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand(() => window.WindowState = WindowState.Maximized);
            MaximizeCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, getMousePosition()));
        }

        private Point getMousePosition()
        {
            var position = Mouse.GetPosition(window);

            return new Point(position.X + window.Left, position.Y + window.Top);
        }
    }
}
