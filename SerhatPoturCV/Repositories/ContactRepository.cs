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
        public List<Contacts> UnReadInbox()
        {
            return _dbSet.Where(x => x.isRead == false && x.isDeleted == false && x.isActive == true).ToList();
        }
        public List<Contacts> ReadInbox()
        {
            return _dbSet.Where(x => x.isRead == true && x.isDeleted == false && x.isActive == true).ToList();
        }
        public List<Contacts> DeletedMessages()
        {
            return _dbSet.Where(x => x.isDeleted == true).ToList();
        }
    }
}