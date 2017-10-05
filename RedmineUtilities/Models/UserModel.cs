using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmineUtilities.Models.user_models
{
    class User
    {
        public string id { get; set; }
        public string login { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string mail { get; set; }
        public string created_on { get; set; }
        public string last_login_on { get; set; }
        public string api_key { get; set; }
    }

    class UserResponse
    {
        public User user { get; set; }
    }
}
