using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.Repositories
{
    public class SkillRepository : GenericRepository<Skills>
    {
        public SkillRepository(SerhatPoturCVEntities context) : base(context)
        {
        }
    }
}