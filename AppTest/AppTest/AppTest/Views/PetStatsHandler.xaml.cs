using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetStatsHandler : ContentPage
    {
        public PetStatsHandler()
        {
            InitializeComponent();
            Content = new StackLayout
            {
                Children =
                {
                    //new Label { Text = "Welcome to Xamarin.Forms!" },
                    Icons(),
                    Pet()
                }
            };
        }
        public Image Pet()
        {
            var image = (new Image
            {
                Source = "okman.jpg",
                Scale = 0.5
            });
            return image;
        }

        public Grid Icons()
        {
            Grid grid = new Grid
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                new RowDefinition(),
                new RowDefinition { Height = new GridLength(100) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition()
            }
            };

            for (int i = 0; i < 6; i++)
            {
                //grid.Children.Add(new Label
                //{
                //    HorizontalOptions = LayoutOptions.Center,
                //    VerticalOptions = LayoutOptions.Center
                //}, i, 0);
                grid.Children.Add(new IconApp
                {
                    Source = "okman.png",
                    Foreground = Color.Red,
                    WidthRequest = 200,
                    HeightRequest = 200
                }, i, 0);
            }

            return grid;
        }
    }
}