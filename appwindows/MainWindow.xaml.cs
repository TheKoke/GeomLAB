using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace GeomLAB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BPlanymetry_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.Planymetry();
            TitleText.Text = "Planymetry";
        }

        private void BStereometry_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.Stereometry();
            TitleText.Text = "Stereometry";
        }

        private void BCoordinate_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.CoordinateSystem();
            TitleText.Text = "Coordinate System working";
        }

        private void BTriangle_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.Triangles();
            TitleText.Text = "Triangles games";
        }

        private void BVectors_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.Vectors();
            TitleText.Text = "Vector =====> ?";
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                MainFrame.Content = null;
                TitleText.Text = "GeomLab";
            }
        }
    }
}
