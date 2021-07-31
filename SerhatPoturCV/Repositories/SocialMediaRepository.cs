using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.Repositories
{
    public class SocialMediaRepository : GenericRepository<SocialMedias>
    {
        public SocialMediaRepository(SerhatPoturCVEntities context) : base(context)
        {
        }
    }
}