﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendViewer.Model
{
    public class Friend
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Homepage { get; set; }
        public byte[] Image { get; set; }
        public string FullName => $"{FirstName} {LastName}"; 
    }
}
