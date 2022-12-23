//using GraphQL;
//using GraphQL.DI;
//using GraphQL.MicrosoftDI;
//using GraphQL.Types;
using Presentation.GraphQL.Schematics;
using System.Diagnostics;

namespace Presentation.GraphQL.Tools
{
    public static class addScopedGraphQlConfig
    {
        //public static IServiceCollection AddScopedGraphQlConfig(this IServiceCollection services)
        //{
        //    services.AddScoped<ISchema, productoSchema>(
        //        services =>
        //        new productoSchema(new SelfActivatingServiceProvider(services))
        //        );
        //    services.AddGraphQL(x => x.AddSystemTextJson());
        //        //.ConfigureExecution(async (options, next) =>
        //        //    {
        //        //        var timer = Stopwatch.StartNew();
        //        //        var result = await next(options);
        //        //        result.Extensions ??= new Dictionary<string, object?>();
        //        //        result.Extensions["elapsedMs"] = timer.ElapsedMilliseconds;
        //        //        return result;
        //        //    }));
        //    return services;
        //}
    }
}
