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

        public PetStatsHandler()
        {
            InitializeComponent();

            RefreshContent();

            ShowStatsModel.OnStateUpdate += RefreshContent;

            this.ToolbarItems.Add(ShopToolBarIcon());
        }

        public virtual void RefreshContent()
        {

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

        public Image PetImage()
        {
            var image = (new Image
            {
                Source = "okman.jpg",
                Scale = 0.5,
                VerticalOptions = LayoutOptions.Start,
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

            grid.Children.Add(CreateStat(0, Pet.Instance.food), 0, 0);
            grid.Children.Add(CreateStat(1, Pet.Instance.drink), 1, 0);
            grid.Children.Add(CreateStat(2, Pet.Instance.sleep), 2, 0);
            grid.Children.Add(CreateStat(3, Pet.Instance.boredom), 3, 0);
            grid.Children.Add(CreateStat(4, Pet.Instance.lonely), 4, 0);
            grid.Children.Add(CreateStat(5, Pet.Instance.excited), 5, 0);

            return grid;
        }

        IconApp CreateStat(int statName, Stat stat)
        {
            IconApp temp = new IconApp
            {
                Source = statTypes[statName],
                Foreground = stat.StatColor,
                WidthRequest = 200,
                HeightRequest = 200
            };
            return temp;
        }
    }
}