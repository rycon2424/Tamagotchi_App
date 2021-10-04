using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AppTest
{
    class Stat : INotifyPropertyChanged
    {
        string statName;
        float statValue;
        Color color;

        public event PropertyChangedEventHandler PropertyChanged;

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
                Console.WriteLine("Updated color of " + statName + " to " + color);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UpdateColor"));
            }
        }

        public string StatName { get { return statName; } }

        public float StatValue
        {
            set
            {
                statValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StatValue"));
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
