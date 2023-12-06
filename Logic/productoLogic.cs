using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.dto;
using Models.mapperConfig;
using Models.request;
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
        private readonly imgProductoLogic _dbImg = new imgProductoLogic();
        private readonly colorProductoLogic _dbColor = new colorProductoLogic();
        private readonly tallaProductoLogic _dbTallaProd = new tallaProductoLogic();
        private readonly tallaColorLogic _dbTallaColor = new tallaColorLogic();
        private readonly _dbContextProducto _dbContexAlter = new();
        private readonly IMapper _map = mapper.Go();


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //public async Task<List<productoDto>> listAllAsyncOptimo(filterRequest filterReq)
        //{
        //    List<productoDto> res = await listFrontAsync();

        //    if (res != null)
        //    {
        //        await Task.WhenAll(res.Select(async producto =>
        //        {
        //            producto.imgProducto = _map.Map<List<imgProductoDto>>(await _dbImg.GetByProductIdAsync(producto.id));

        //            if (producto.tipoMedida != "talla")
        //            {
        //                producto.colorProducto = _map.Map<List<colorProductoDto>>(await _dbColor.GetByProductIdAsync(producto.id));
        //            }
        //            else
        //            {
        //                producto.colorProducto = new List<colorProductoDto>();

        //                var tallas = await _dbTallaProd.GetByProductIdAsync(producto.id);
        //                var colorsAllTasks = tallas.Select(async talla => await _dbTallaColor.GetByTallaIdAsync(talla.id));
        //                var colorsAll = (await Task.WhenAll(colorsAllTasks)).SelectMany(x => x).ToList();

        //                var distinctColors = colorsAll.GroupBy(x => x.colorCode).Select(g => g.First()).ToList();
        //                producto.colorProducto = _map.Map<List<colorProductoDto>>(distinctColors);
        //            }
        //        })).ConfigureAwait(false);
        //    }

        //    return res;
        //}

        public async Task<List<productoDto>> listAllAsync(filterRequest filterReq)
        {

            List<productoDto> res = await listFrontAsync();
            if (res != null)
            {
                foreach (productoDto producto in res)
                {
                    producto.imgProducto = _map.Map<List<imgProductoDto>>(await _dbImg.GetByProductIdAsync(producto.id));
                    if (producto.tipoMedida != "talla")
                    {
                        producto.colorProducto = _map.Map<List<colorProductoDto>>(await _dbColor.GetByProductIdAsync(producto.id));
                    }
                    else
                    {
                        List<string> colorsAdd = new();
                        int TotColors = 0;
                        producto.colorProducto = new();
                        List<tallaColorModel> colorsAll = new();
                        List<tallaProductoModel> tallas = await _dbTallaProd.GetByProductIdAsync(producto.id);
                        foreach (tallaProductoModel talla in tallas)
                        {
                            colorsAll.AddRange(await _dbTallaColor.GetByTallaIdAsync(talla.id));
                        }
                        foreach (tallaColorModel colorAll in colorsAll)
                        {
                            bool state = false;
                            if (TotColors == 0)
                            {
                                producto.colorProducto.Add(_map.Map<colorProductoDto>(colorAll));
                                colorsAdd.Add(colorAll.colorCode);
                                TotColors++;
                            };
                            for (int i = 0; i < TotColors; i++)
                            {
                                if (colorsAdd[i] == colorAll.colorCode)
                                {
                                    state = true;
                                }
                            }
                            if (!state)
                            {
                                producto.colorProducto.Add(_map.Map<colorProductoDto>(colorAll));
                                colorsAdd.Add(colorAll.colorCode);
                                TotColors++;
                            }
                        }
                    }
                }
            }
            return res;
        }

        public async Task<productoDto> getByIdDetailAsync(int id)
        {
            productoDto res = await getByIdFrontAsync(id);
            if (res != null)
            {
                if (res.tipoMedida != "talla")
                {
                    res.colorProducto = _map.Map<List<colorProductoDto>>(await _dbColor.GetByProductIdAsync(res.id));
                }
                else
                {
                    List<string> colorsAdd = new();
                    int TotColors = 0;
                    res.colorProducto = new();
                    List<tallaColorModel> colorsAll = new();
                    List<tallaProductoModel> tallas = await _dbTallaProd.GetByProductIdAsync(res.id);
                    foreach (tallaProductoModel talla in tallas)
                    {
                        colorsAll.AddRange(await _dbTallaColor.GetByTallaIdAsync(talla.id));
                    }
                    foreach (tallaColorModel colorAll in colorsAll)
                    {
                        bool state = false;
                        if (TotColors == 0)
                        {
                            res.colorProducto.Add(_map.Map<colorProductoDto>(colorAll));
                            colorsAdd.Add(colorAll.colorCode);
                            TotColors++;
                        };
                        for (int i = 0; i < TotColors; i++)
                        {
                            if (colorsAdd[i] == colorAll.colorCode)
                            {
                                state = true;
                            }
                        }
                        if (!state)
                        {
                            res.colorProducto.Add(_map.Map<colorProductoDto>(colorAll));
                            colorsAdd.Add(colorAll.colorCode);
                            TotColors++;
                        }
                    }
                }

            }
            return res;
        }
    }
}
