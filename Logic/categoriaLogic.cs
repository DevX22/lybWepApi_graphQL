﻿using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class categoriaLogic : categoriaRepository<categoriaModel>, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
