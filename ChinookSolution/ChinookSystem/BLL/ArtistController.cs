using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using ChinookSystem.DAL;
using ChinookSystem.Entity;
using System.ComponentModel;
using ChinookSystem.ViewModel;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> Artists_DDLList()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<SelectionList> results = from x in context.Artists
                                                     select new SelectionList 
                                                     {
                                                        ValueField = x.ArtistID,
                                                        DisplayField = x.Name
                                                     };
                return results.ToList();
            }
        }
    }
}
