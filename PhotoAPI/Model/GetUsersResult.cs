using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAPI.Model
{
    public class GetUsersResult
    {
        public IEnumerable<User> Users { get; set; }

        string Error { get; set; }

    }
}
