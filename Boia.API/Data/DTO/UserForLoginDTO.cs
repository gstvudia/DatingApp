﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boia.API.Data.DTO
{
    public class UserForLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
