using PhotoAPI.Model;
using PhotoAPI.Repositories;
using System;
using System.Collections.Generic;

namespace PhotoAPI.Services
{
    public class PhotoService : IPhotoService
    {
        private IPhotoRespository _photoRepository;

        public PhotoService(IPhotoRespository photoRespository)
        {
             _photoRepository = photoRespository;
        }

        public (int Id, string Error) AddPhoto(PhotoRequest request)
        {
            return _photoRepository.AddPhoto(request);
        }

        public string DeleteAllPhotos()
        {
            return _photoRepository.DeleteAllPhotos();
        }

        public string DeletePhoto(int id)
        {
            return _photoRepository.DeletePhoto(id);
        }

        public (IEnumerable<Photo> Photos, string Error) GetAllPhotos()
        {
            return _photoRepository.GetAllPhotos();
        }

        public (Photo photo, string Error) GetPhoto(int id)
        {
            return _photoRepository.GetPhoto(id);
        }

        public (IEnumerable<Photo> Photos, string Error) GetPhotoByDate(DateTime date, int userId)
        {
            return _photoRepository.GetPhotoByDate(date, userId);
        }

        public (IEnumerable<Photo> Photos, string Error) GetUserPhotos(int userId)
        {
            return _photoRepository.GetUserPhotos(userId);
        }

    }
}
