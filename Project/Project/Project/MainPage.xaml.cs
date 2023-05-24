using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project
{
    public partial class MainPage : ContentPage
    {
            SKBitmap bitmap;
            SKPath keyholePath = SKPath.ParseSvgPathData(
                "M 300 130 L 250 350 L 450 350 L 400 130 A 70 70 0 1 0 300 130 Z"); // Изменить на нормальную фигуру
        public MainPage()
        {
            InitializeComponent();

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;

            Label hader = new Label
            {
                Text = "Изменение на 23.02.23",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Start
            };

            ImageButton imageButtonFrame = new ImageButton
            {
                Source = "Stub.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Grid gridFrame = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                }
            };
            gridFrame.Children.Add(hader, 0, 0);
            gridFrame.Children.Add(imageButtonFrame, 0, 0);
            gridFrame.Children.Add(canvasView, 0, 1);

            Frame frameRasp = new Frame
            {
                Content = gridFrame,
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                CornerRadius = 8
            };

            Frame[] Frames = new Frame[] { frameRasp };
            ListRasp.ItemsSource = Frames;

            string resourceID = "TestRaspisanie.jpg";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                bitmap = SKBitmap.Decode(stream);
            }

        }
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Set transform to center and enlarge clip path to window height
            SKRect bounds;
            keyholePath.GetTightBounds(out bounds);

            canvas.Translate(info.Width / 2, info.Height / 2);
            canvas.Scale(0.98f * info.Height / bounds.Height);
            canvas.Translate(-bounds.MidX, -bounds.MidY);

            // Set the clip path
            canvas.ClipPath(keyholePath);

            // Reset transforms
            canvas.ResetMatrix();

            // Display monkey to fill height of window but maintain aspect ratio
            canvas.DrawBitmap(bitmap,
                new SKRect((info.Width - info.Height) / 2, 0,
                           (info.Width + info.Height) / 2, info.Height));
        }
    }
}
