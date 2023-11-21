﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public bool Suspended { get; set; }

        public int LoginFailCount { get; set; }

    }
}
