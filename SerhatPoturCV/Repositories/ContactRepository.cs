using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.Repositories
{
    public class ContactRepository : GenericRepository<Contacts>
    {
        public ContactRepository(SerhatPoturCVEntities context) : base(context)
        {
        }
    }
}