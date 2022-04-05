using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  WebApplication1.ViewModels
{
    public class UserVM
    {
        public int ID { get; set;  }
        public string Username { get; set;  }
        public string Password { get; set;  }
        public string Email { get; set;  }
        public DateTime CreatedDate { get; set;  }
        public DateTime? LastLoginDate { get; set;  }
    }
}