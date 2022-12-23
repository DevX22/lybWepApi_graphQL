using HotChocolate.Execution.Configuration;
using Presentation.GraphQL.Schematics.Queries;

namespace Presentation.GraphQL.Tools
{
    public static class addTypeExtensionCustom
    {
        public static IRequestExecutorBuilder AddTypeExtensionCustom(this IRequestExecutorBuilder options)
        {
            //agregar los demas Querys
            options
                .AddTypeExtension<avatarQuery>()
                .AddTypeExtension<productoQuery>()
                //...


            #region return
            ;
            return options;
            #endregion
        }
    }
}
