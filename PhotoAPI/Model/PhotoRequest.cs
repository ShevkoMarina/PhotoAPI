using System;

namespace PhotoAPI.Model
{
    public class PhotoRequest
    {
        public DateTime Date { get; set; }

        public byte[] Image { get; set; }

        public int UserId { get; set; }

    }
}
