﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTest.ViewModels;
using AppTest.Models;

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
            if (Pet.PetInstance.sleeping == false)
            {
                List<GridButton> temp = new List<GridButton>();

                Button feedButton = CreateButton("Feed", 14);
                Button drinkButton = CreateButton("Drink", 14);

                feedButton.Clicked += GainFood;
                drinkButton.Clicked += GainWater;

                temp.Add(new GridButton(feedButton, 1, 2));
                temp.Add(new GridButton(drinkButton, 4, 2));

                Content = Icons(temp);
            }
            else
            {
                Content = Icons(null);
            }
        }
        public void GainFood(object sender, EventArgs args)
        {
            Pet.PetInstance.food.StatValue += 0.1f;
            RefreshContent();
        }

        public void GainWater(object sender, EventArgs args)
        {
            Pet.PetInstance.drink.StatValue += 0.1f;
            RefreshContent();
        }

    }
}