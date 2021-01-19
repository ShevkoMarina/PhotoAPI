using System;

namespace PhotoAPI.Model
{
    public class GetPhotoByDateRequest
    {
        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}
