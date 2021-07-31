using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.Repositories
{
    public class CareerRepository : GenericRepository<Careers>
    {
        public CareerRepository(SerhatPoturCVEntities context) : base(context)
        {
        }
    }
}