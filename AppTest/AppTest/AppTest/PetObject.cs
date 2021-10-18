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

        public void UpdateStats(Pet p)
        {
            name = p.name;
            hunger = p.hunger.StatValue * 100;
            thirst = p.thirst.StatValue * 100;
            tired = p.tired.StatValue * 100;
            boredom = p.boredom.StatValue * 100;
            stimulated = p.stimulated.StatValue * 100;
            loneliness = p.loneliness.StatValue * 100;
        }
    }
}
