//using GraphQL.Types;
using Models;
using Repository.Data;

namespace Presentation.GraphQL.Types
{
    //public class productoType : ObjectGraphType<productoModel>
    //{
    //    private readonly _dbContext _db = new();
    //    public productoType()
    //    {
    //        Name = "Producto";
    //        Field(x => x.id);
    //        Field(x => x.producto).Description("nombre del producto");
    //        Field(x => x.descripcion).Description("descripcion del producto");
    //        Field(x => x.id_proveedor).Description("identificador unico del proveedor");
    //        Field(x => x.proveedor).Description("nombre del proveedor");
    //        Field(x => x.id_categoria).Description("identificador unico de la categoria");
    //        Field(x => x.categoria).Description("nombre de la categoria");
    //        Field(x => x.id_tipoMedida).Description("identificador unico del tipo de medida");
    //        Field(x => x.tipoMedida).Description("nombre del tipo de medida ej: cm, lt, mt, talla etc.");
    //        Field(x => x.medida).Description("medida unica");
    //        Field(x => x.alto).Description("alto del producto");
    //        Field(x => x.ancho).Description("ancho del producto");
    //        Field(x => x.profundidad).Description("profundidad del producto");
    //        Field(x => x.precioCompra).Description("precio de adquisisión del producto");
    //        Field(x => x.precioVenta).Description("precio de venta del producto antes de descuentos");
    //        Field(x => x.stock).Description("cantidad total disponible del producto");
    //        Field(x => x.estado).Description("estado del producto descontinuado/activo");
    //        Field<categoriaType>("Categoria",
    //            arguments: new QueryArguments(
    //                new QueryArgument<IntGraphType> { Name = "id_categoria" }),
    //            resolve: contex =>
    //                    _db.categoria.Find(contex.Source.id_categoria),
    //                    description: "nombre de la categoria");
    //    }
    //}
}
