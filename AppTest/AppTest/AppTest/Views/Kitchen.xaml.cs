using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTest.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kitchen : PetStatsHandler
    {
        public Kitchen()
        {
            InitializeComponent();
            BindingContext = new KitchenViewModel();
            RefreshContent();
        }

        public override void RefreshContent()
        {
            Content = new StackLayout
            {
                Children =
                {
                    Icons(),
                    ButtonTest(),
                    TestLol()
                }
            };
        }

        public Label TestLol()
        {
            Label label = new Label
            {
                Text = "TesterTEst",
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Center,
            };
            return label;
        }

        public Button ButtonTest()
        {
            Button button = new Button
            {
                ImageSource = "okman.jpg",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Scale = 0.3f,
                AnchorY = 0f
            };
            button.Clicked += OnButtonPressed;
            return button;
        }
        void OnButtonPressed(object sender, EventArgs args)
        {
            Pet.Instance.food.StatValue += 0.1f;
        }
    }
}