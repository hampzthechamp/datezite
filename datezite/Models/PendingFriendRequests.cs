﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datezite.Models
{
    public class PendingFriendRequests
    {
        public String FriendId { get; set; }

        public String UserId { get; set; }

        public List<ApplicationUser> FriendRequests { get; set; }
}
}