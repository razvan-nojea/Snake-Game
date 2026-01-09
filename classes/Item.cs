using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_snake.classes
{
    public class Item
    {
        public int i { get; set; }
        public int j { get; set; }
        public bool special { get; set; }

        public Item(int i, int j, bool special)
        {
            this.i = i;
            this.j = j;
            this.special = special;
        }
    }
}
