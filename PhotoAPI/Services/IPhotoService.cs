using PhotoAPI.Model;
using System;
using System.Collections.Generic;

namespace PhotoAPI.Services
{
    public interface IPhotoService
    {
        (int Id, string Error) AddPhoto(PhotoRequest photo);

        string DeleteAllPhotos();

        string DeletePhoto(int id);

        (Photo photo, string Error) GetPhoto(int id);

        (IEnumerable<Photo> Photos, string Error) GetAllPhotos();

        (IEnumerable<Photo> Photos, string Error) GetUserPhotos(int userId);

        (IEnumerable<Photo> Photos, string Error) GetPhotoByDate(DateTime date, int userId);
    }
}
