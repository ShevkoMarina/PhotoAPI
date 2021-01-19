using PhotoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoAPI.Repositories
{
    public class PhotoRepository : IPhotoRespository
    {
        private readonly PhotoDBContext _context;

        public PhotoRepository(PhotoDBContext context)
        {
            this._context = context;
        }

        public (int Id, string Error) AddPhoto(PhotoRequest photo)
        {
            try
            {
                _context.Photos.Add(new Photo { DateCreated = photo.Date, ImageSource = photo.Image, UserId = photo.UserId});
                _context.SaveChanges();
                return (_context.Photos.ToList().Last().Id, null);
            }
            catch(Exception e)
            {
                return (-1, e.Message);
            }
        }

        public string DeleteAllPhotos()
        {
            try
            {
                _context.Photos.RemoveRange(_context.Photos.ToList());
                _context.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public (IEnumerable<Photo> Photos, string Error) GetAllPhotos()
        {
            try
            {
                return (_context.Photos.ToList(), null);
            }
            catch (Exception e)
            {
                return (null, e.Message);
            }
        }

        public (Photo, string) GetPhoto(int id)
        {
            try
            {
                return (_context.Photos.Find(id), null);
            }
            catch(Exception e)
            {
                return (null, e.Message);
            }
        }

        public (IEnumerable<Photo> Photos, string Error) GetUserPhotos(int userId)
        {
            try
            {
                var userPhotos = _context.Photos.ToList()
                    .Where(p => p.UserId == userId);

                return (userPhotos, null);
            }
            catch (Exception e)
            {
                return (null, e.Message);
            }
        }

        public string DeletePhoto(int id)
        {
            try
            {
                var photo = _context.Photos.Find(id);
                _context.Photos.Remove(photo);
                _context.SaveChanges();
                return null;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public (IEnumerable<Photo> Photos, string Error) GetPhotoByDate(DateTime date, int userId)
        {
            try
            {
                var photosByDate = _context.Photos.ToList()
                    .Where(p => p.UserId == userId)
                    .Where(p => p.DateCreated == date);

                return (photosByDate, null);
            }
            catch (Exception e)
            {
                return (null, e.Message);
            }
        }
    }
}
