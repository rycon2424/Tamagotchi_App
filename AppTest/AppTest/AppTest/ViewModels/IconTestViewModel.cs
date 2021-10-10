using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

using Xamarin.Forms;

namespace AppTest.ViewModels
{
    public class IconTestViewModel : ShowStatsModel
    {

        public IconTestViewModel()
        {
            Title = "Icon";
            //food = new Stat("Food", 1f, Stat.TypeStat.hunger);
            //drink = new Stat("Drink", 1f, Stat.TypeStat.thirst);
            TestUpdate();
        }
        
        async void TestUpdate()
        {
            while (true)
            {
                if (food != null)
                {
                    UpdateStat(food, -0.01f);
                }
                Lol += "x";
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

    }
}