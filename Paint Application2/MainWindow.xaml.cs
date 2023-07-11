// A C# WPF application that allows a user to draw in many different colors.
// They can also erase details, select and move anything, clear the canvas, and save as a Jpg file.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint_Application2
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
        // Get and display XY Coordinate position of mouse
        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(this);

            XCoord.Content = position.X;
            YCoord.Content = position.Y;
        }
        // Color Selections that change InkCanvas into Ink Editing Mode
        private void White_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.White;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void Black_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.Black;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void PaleVioletRed_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.PaleVioletRed;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void DarkRed_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.DarkRed;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Orange_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.Orange;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void DarkOrange_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.DarkOrange;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void LightYellow_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.LightYellow;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.Yellow;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void LightGreen_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.LightGreen;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void DarkGreen_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.DarkGreen;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void LightBlue_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.LightBlue;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.Blue;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Lavender_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.Lavender;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void Purple_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.Purple;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Pink_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.Pink;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void DeepPink_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.DeepPink;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void SandyBrown_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.SandyBrown;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void Brown_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.Brown;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void LightGray_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.LightGray;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void DarkGray_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.DefaultDrawingAttributes.Color = Colors.DarkGray;
            myCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        // Clear Button that deletes all displayed strokes
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            this.myCanvas.Strokes.Clear();
        }

        // Erase Button that changes Ink Canvas into EraseByPoint Editing Mode
        private void EraseBtn_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }
        
        // Selection Button that changes Ink Canvas into Select Editing Mode
        private void SelectionBtn_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.EditingMode = InkCanvasEditingMode.Select;
        }

        // Save Button that renders Ink Canvas to bitmap and defaults the image as a .jpg
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "myimage"; // Default myimage file name
            dlg.DefaultExt = ".jpg"; // Default .jpg file extension
            dlg.Filter = "Image (.jpg)|*.jpg"; // Filter files by .jpg

            // Show dialog box for saving image
            Nullable<bool> result = dlg.ShowDialog();

            // Process Ink Canvas into bitpmap save file
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //get the dimensions of the ink control
                int margin = (int)this.myCanvas.Margin.Left;
                int width = (int)this.myCanvas.ActualWidth - margin;
                int height = (int)this.myCanvas.ActualHeight - margin;
                //render ink to bitmap
                RenderTargetBitmap rtb =
                new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
                rtb.Render(myCanvas);

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(fs);
                }
            }
        }

        // Close Button that closes the Application
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
