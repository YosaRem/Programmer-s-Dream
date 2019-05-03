﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
    public class Bonus
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Bonus(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public virtual void Draw(Graphics graphics)
        {
            
        }
    }
}