using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest
{
    public class PetObject
    {
        public int id;
        public string name = "Jason";
        public string username = "Bosko";
        public float hunger = 1;
        public float thirst = 1;
        public float tired = 1;
        public float boredom = 1;
        public float stimulated = 1;
        public float loneliness = 1;

        public DateTime enterTime;

        public void UpdateStats(Pet p)
        {
            name = p.name;
            hunger = p.hunger.StatValue;
            thirst = p.thirst.StatValue;
            tired = p.tired.StatValue;
            boredom = p.boredom.StatValue;
            stimulated = p.stimulated.StatValue;
            loneliness = p.loneliness.StatValue;
        }
    }
}
