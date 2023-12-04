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
        private readonly IMapper _map = mapper.Go();


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

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
                ////filters
                //List<productoDto> productoFilter = new();

                //if (filterReq == null)
                //{
                //    return res;
                //}

                //if (filterReq.categorias != null && filterReq.categorias[0] != null && filterReq.categorias.Count > 0)
                //{
                //    foreach (var categoria in filterReq.categorias)
                //    {
                //        var producto = from prod in res
                //                       where prod.id_categoria == categoria.id
                //                       select prod;
                //        if (producto.Count() > 0)
                //        {
                //            productoFilter.AddRange(producto);
                //        }
                //    }
                //    res = productoFilter;
                //}
                //if (filterReq.isOrderByAZ == true)
                //{
                //    var produts = from prod in res
                //                  orderby prod.producto ascending
                //                  select prod;
                //    res = produts.ToList();
                //}
                //else if (filterReq.isOrderByZA == true)
                //{
                //    var produts = from prod in res
                //                  orderby prod.producto descending
                //                  select prod;
                //    res = produts.ToList();
                //}
                //else if (filterReq.isOrderByMenorMayor == true)
                //{
                //    var produts = from prod in res
                //                  orderby prod.precioVenta ascending
                //                  select prod;
                //    res = produts.ToList();
                //}
                //else if (filterReq.isOrderByMayorMenor == true)
                //{
                //    var produts = from prod in res
                //                  orderby prod.precioVenta descending
                //                  select prod;
                //    res = produts.ToList();
                //}
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
