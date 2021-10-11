using AppTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetStatsHandler : ContentPage
    {

        string[] statTypes = new string[] { "Food.png", "Water.png", "Bed.png", "Boredom.png", "Lonely.png", "Excited.png" };
        public static bool refreshing;

        public PetStatsHandler()
        {
            InitializeComponent();
            // <-- here function to load all stats, make the refresh static?

            RefreshContent();
            if (refreshing == false)
            {
                refreshing = true;
                Test();
            }
            this.ToolbarItems.Add(ShopToolBarIcon());
        }

        async void Test()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Debug.WriteLine("Test");
                RefreshContent();
            }
        }

        public void RefreshContent()
        {
            Content = new StackLayout
            {
                Children =
                {
                    Icons(),
                    Pet()
                }
            };
        }

        public ToolbarItem ShopToolBarIcon()
        {
            ToolbarItem item = new ToolbarItem
            {
                Text = "Example Item",
                IconImageSource = ImageSource.FromFile("Shop.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };
            item.Clicked += OpenShop;
            return item;
        }

        async void OpenShop(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        public Image Pet()
        {
            var image = (new Image
            {
                Source = "okman.jpg",
                Scale = 0.5,
                AnchorY = 0.3
            });
            return image;
        }

        public Grid Icons()
        {
            Grid grid = new Grid
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) },
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
                grid.Children.Add(new IconApp
                {
                    Source = statTypes[i],
                    Foreground = ShowStatsModel.food.StatColor,
                    WidthRequest = 200,
                    HeightRequest = 200
                }, i, 0);
            }

            return grid;
        }
    }
}