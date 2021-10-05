using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AppTest.ViewModels
{
    class Stat : BaseViewModel
    {
        string statName;
        float statValue;
        Color color;

        public Stat(string _name, float _statValue)
        {
            statName = _name;
            StatValue = _statValue;
        }

        public float UpdateColor
        {
            set
            {
                double fullfilledCalculation = 1 * value;
                double needCalculation = 1 - fullfilledCalculation;
                Color tempColor = new Color(needCalculation, fullfilledCalculation, 0);
                color = tempColor;
                //Console.WriteLine("Updated color of " + statName + " to " + color);
            }
        }

        public string StatName { get { return statName; } }

        public float StatValue
        {
            set
            {
                //statValue = value;
                SetProperty(ref statValue, value);
                UpdateColor = value;
            }
            get
            {
                return statValue;
            }
        }

        public Color StatColor => color;

    }
}
