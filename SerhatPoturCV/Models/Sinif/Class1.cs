using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.Models.Sinif
{
    public class Class1
    {
        public IEnumerable<Hakkımda> About { get; set; }
        public IEnumerable<Kariyer> Career { get; set; }
        public IEnumerable<Projeler> Projects { get; set; }
        public IEnumerable<Yetenekler> Skills { get; set; }

    }
}