using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SerhatPoturCV.Models.Entity;

namespace SerhatPoturCV.Repositories
{
    public class AboutRepository : GenericRepository<Abouts>
    {
        public AboutRepository(SerhatPoturCVEntities context) : base(context)
        {
        }
    }
}