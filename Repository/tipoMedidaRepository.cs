﻿using Repository.genericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class tipoMedidaRepository<TEntity>:genericRepository<TEntity> where TEntity: class
    {
    }
}
