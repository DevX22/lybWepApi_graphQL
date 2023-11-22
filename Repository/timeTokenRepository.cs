using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class timeTokenRepository
    {
        private _dbContext _db = new();
        internal int min()
        {
            int Ttoken=0;
            timeTokenModel res = _db.timeToken.FirstOrDefault();
            Ttoken = Convert.ToInt32(res.minutos);
            return Ttoken;
        }

    }
}
