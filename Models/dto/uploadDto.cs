﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dto
{
    public class uploadDto
    {
        public IFormFile file { get; set; }
    }
}
