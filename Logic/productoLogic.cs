﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.dto;
using Models.mapperConfig;
using Repository;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class productoLogic : productoRepository<productoModel>
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
