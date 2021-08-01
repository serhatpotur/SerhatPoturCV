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

        public Abouts GetByAbout()
        {
            return _dbSet.FirstOrDefault();
        }
        public List<Abouts> AboutList()
        {
            return _dbSet.Where(x => x.AboutID == 1).ToList();
        }
    }
}