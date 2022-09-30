using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class tallaProductoLogic : tallaProductoRepository<tallaProductoModel>, IDisposable
    {
        private readonly tallaColorLogic _colorLogic = new tallaColorLogic();
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
