﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Domain.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}