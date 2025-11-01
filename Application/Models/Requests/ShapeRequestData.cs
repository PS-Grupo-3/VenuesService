﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class ShapeRequestData
    {
        [Required]
        public string Type { get; set; } = "rectangle"; 

        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Rotation { get; set; }
        public int Padding { get; set; }
        public int Opacity { get; set; }
        public string Colour { get; set; } = "#FFFFFF";
    }
}
