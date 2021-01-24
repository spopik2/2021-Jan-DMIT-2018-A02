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
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetArtistAlbums()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name
                                                    };
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetAlbumsForArtist(int artistid)
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    where x.ArtistId == artistid
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name,
                                                        ArtistId = x.AlbumId
                                                    };
                return results.ToList();
            }
        }
        public List<AlbumItem> Albums_List()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<AlbumItem> results = from x in context.Albums
                                                 select new AlbumItem
                                                 {
                                                     ArtistId = x.ArtistId,
                                                     Title = x.Title,
                                                     ReleaseYear = x.ReleaseYear,
                                                     AlbumId = x.ArtistId,
                                                     ReleaseLabel = x.ReleaseLabel
                                                 };
                return results.ToList();
            }
        }
        public AlbumItem Albums_FindByArtistId(int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                //FirstOrDefault will return either 
                //a) the firts record matching the where condition
                //b) a null value 
                var results = (from x in context.Albums
                               where x.AlbumId == albumid
                               select new AlbumItem
                               {
                                   ArtistId = x.ArtistId,
                                   Title = x.Title,
                                   ReleaseYear = x.ReleaseYear,
                                   AlbumId = x.ArtistId,
                                   ReleaseLabel = x.ReleaseLabel
                               }).FirstOrDefault();
                return results;
            }
        }
        #region Add, Update, and Delete CRUD
        //Add
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int Album_Add(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                //due to the fact that we have separated the handling of our entities 
                // from the data transfer between web app and class library 
                //using the viewmodel classes, we MUST create an instance
                //of the entity and move the data from the view model class to the entity instance.
                Album additem = new Album
                {
                    //why do we need a pkey set?
                    //pkey is an identity pkey, no value is needed
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };

                //staging
                //setup in local memory
                //at this point you will not have sent anything to the database
                //      therefore, you will NOT have your new pkey as yet
                context.Albums.Add(additem);

                //commit to database
                //on this command you 
                //A) execute entity validationm annotation 
                // B) send your local memory staging to the database for execution 
                // after a successful execution your entity instance will have the 
                //      new pkey (identity) value
                context.SaveChanges();

                //at this point, your identity instance has the new pkey value
                return additem.AlbumId;
            }
        }
        //Update
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Album_Update(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                //due to the fact that we have separated the handling of our entities 
                // from the data transfer between web app and class library 
                //using the viewmodel classes, we MUST create an instance
                //of the entity and move the data from the view model class to the entity instance.
                Album updateitem = new Album
                {
                    //for an update, you need to supply a pkey value
                    AlbumId = item.AlbumId,
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };

                //staging
                //setup in local memory

                context.Entry(updateitem).State = System.Data.Entity.EntityState.Modified;

                //commit to database
                //on this command you 
                //A) execute entity validationm annotation 
                // B) send your local memory staging to the database for execution 
                // after a successful execution your entity instance will have the 
                //      new pkey (identity) value
                context.SaveChanges();

                //at this point, your identity instance has the new pkey value
            }
        }
        // Delete

        //when we do an ODS crud, on the delete, ODS sends in the entire instance record, not just the pkey value


        //overload the Album_Delete method so it receives a whole instance 
        //then call the actual delete method passing just the 
        //pkey value to the actual delete method 
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Album_Delete(AlbumItem item)
        {
            Album_Delete(item.AlbumId);
        }
        public void Album_Delete(int albumid)
        {
            using(var context = new ChinookSystemContext())
            {
                //retrieve the current entity instance based on the incoming parameter
                var exists = context.Albums.Find(albumid);
                //staged the remove
                context.Albums.Remove(exists);
                //commit the remove
                context.SaveChanges();
            }
        }
        #endregion
    }
}
