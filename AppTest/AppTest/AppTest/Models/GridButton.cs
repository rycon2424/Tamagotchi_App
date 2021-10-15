using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTest.Models
{
    public class GridButton
    {
        public Button button;
        public int x;
        public int y;

        public GridButton(Button _b, int _x, int _y)
        {
            button = _b;
            x = _x;
            y = _y;
        }
    }
}
