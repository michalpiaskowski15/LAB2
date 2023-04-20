using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LAB2
{
    public class Weather
    {
        public int id { set; get; }
        public string? name { set; get; }
        public Main? main { set; get; }
        
    }

    public class Main
    {
        public double temp { set; get; }
        public int humidity { set; get; }
        public double pressure { set; get; }
    }
}
