using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AppTest
{
    public class Stat
    {
        public enum TypeStat {hunger, thirst, bored, lonely, excited, sleep }

        TypeStat statType;
        string statName;
        float statValue;
        Color color;

        public Stat(string _name, float _statValue, TypeStat _statType)
        {
            statName = _name;
            StatValue = _statValue;
            statType = _statType;
        }

        public void UpdateColor()
        {
            double fullfilledCalculation = 1 * StatValue;
            double needCalculation = 1 - fullfilledCalculation;
            Color tempColor = new Color(needCalculation, fullfilledCalculation, 0);
            color = tempColor;
        }

        public string StatName { get { return statName; } }

        public float StatValue
        {
            set
            {
                statValue = value;
            }
            get
            {
                return statValue;
            }
        }

        public Color StatColor
        {
            set
            {
                color = value;
            }
            get
            {
                return color;
            }
        }

        public TypeStat StatType => statType;

    }
}
