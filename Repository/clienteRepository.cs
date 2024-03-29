﻿using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Data;
using Repository.genericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class clienteRepository : genericRepository<clienteModel>, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<clienteModel> listDetaild()
        {
            List<clienteModel> response=_db.cliente
                .Include(x=>x.persona).ToList();
            return response;
        }

        public bool existsCliente(string usser)
        {
            clienteModel response = _db.cliente.Where(x => x.usser == usser.Trim()).FirstOrDefault();
            if(response == null || response.usser == "")
            {
                return false;
            }
            return true;
        }
    }
}
