using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game2048
{
    class Map
    {
        int[,] map;
        public int size { get; set; }


        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }


        public int Get(int x, int y)
        {
            if (OnPap(x, y))
            {
                return map[x, y];
            }
            return -1;
        }
        public void Set(int x,int y, int number)
        {
            if (OnPap(x,y))
            {
                map[x, y] = number;
            }
        }
        public bool OnPap(int x, int y)
        {
            return x >= 0 && x < size &&
                   y >= 0 && y < size;
        }
    }
}
