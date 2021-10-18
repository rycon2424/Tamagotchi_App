using AppTest.ViewModels;
using AppTest.Models;
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
                Source = PetBehaviour(),
                Scale = 3,
                AnchorX = 0.15f,
                AnchorY = 0.45f
            });
            return image;
        }

        string PetBehaviour()
        {
            bool sleepy = false;
            bool sleeping = Pet.PetInstance.sleeping;
            if (Pet.PetInstance.sleep.StatValue < 0.2f)
                sleepy = true;

            if (Pet.PetInstance.food.StatValue < 0.1f || Pet.PetInstance.drink.StatValue < 0.1f)
            {
                if (sleeping)
                    return "pet_dragon_hungry_sleeping.png";
                if (sleepy)
                    return "pet_dragon_hungry_sleepy.png";
                return "pet_dragon_hungry.png";
            }
            else if (Pet.PetInstance.lonely.StatValue < 0.1f)
            {
                if (sleeping)
                    return "pet_dragon_bored_sleeping.png";
                if (sleepy)
                    return "pet_dragon_lonely_sleepy.png";
                return "pet_dragon_lonely.png";
            }
            else if (Pet.PetInstance.boredom.StatValue < 0.1f)
            {
                if (sleeping)
                    return "pet_dragon_bored_sleeping.png";
                if (sleepy) 
                    return "pet_dragon_bored_sleepy.png";
                return "pet_dragon_bored.png";
            }
            else
            {
                if (sleeping)
                    return "pet_dragon_happy_sleeping.png";
                if (sleepy)
                    return "pet_dragon_happy_sleepy.png";
                return "pet_dragon_happy.png";
            }
        }
        public Grid Icons(List<GridButton> extraButtons)
        {
            if (Pet.PetInstance.sleeping)
            {
                BackgroundColor = Color.MidnightBlue;
            }
            else
            {
                BackgroundColor = Color.SkyBlue;
            }

            Grid grid = new Grid
            {
                HeightRequest = 400,
                WidthRequest = 400,
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(80, GridUnitType.Absolute) },
                new RowDefinition(),
                new RowDefinition { Height = new GridLength(100) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition()
            }
            };

            if (extraButtons != null)
            {
                foreach (var extraButton in extraButtons)
                {
                    grid.Children.Add(extraButton.button, extraButton.x, extraButton.y);
                }
            }

            grid.Children.Add(CreateStat(0, Pet.PetInstance.food), 0, 0);
            grid.Children.Add(CreateStat(1, Pet.PetInstance.drink), 1, 0);
            grid.Children.Add(CreateStat(2, Pet.PetInstance.sleep), 2, 0);
            grid.Children.Add(CreateStat(3, Pet.PetInstance.boredom), 3, 0);
            grid.Children.Add(CreateStat(4, Pet.PetInstance.lonely), 4, 0);
            grid.Children.Add(CreateStat(5, Pet.PetInstance.excited), 5, 0);

            grid.Children.Add(PetImage(), 2, 1);

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

        public Button CreateButton(string buttonText, int fontSize)
        {
            Button button = new Button
            {
                Text = buttonText,
                FontSize = fontSize,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            return button;
        }
    }
}