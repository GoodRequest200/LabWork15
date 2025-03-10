using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace LabWork15
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


        private void OpenFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(filePath);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad; 
                    bitmap.EndInit();


                    MainImage.Source = bitmap;

                    Title = System.IO.Path.GetFileName(filePath);

                    FileInfo fileInfo = new FileInfo(filePath);

                    StatusBarText.Text = $"File size: {fileInfo.Length} bytes, Width: {bitmap.PixelWidth}, Height: {bitmap.PixelHeight}";

                    ZoomSlider.Value = 100;
                    ImageScaleTransform.ScaleX = 1;
                    ImageScaleTransform.ScaleY = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}", "Error");
                }
            }
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ImageScaleTransform != null)  
            {
                double zoomFactor = ZoomSlider.Value / 100.0;
                ImageScaleTransform.ScaleX = zoomFactor;
                ImageScaleTransform.ScaleY = zoomFactor;
            }
        }
    }
}