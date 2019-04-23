using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace aws_lambda_crt_db
{
    public class Function
    {
        private ServiceProvider _service;

        public Function() : this (Bootstrap.CreateInstance()) {}

        public Function(ServiceProvider service)
        {
            _service = service;
        }
        private static async Task Main(string[] args)
		{
            Func<ILambdaContext, List<DistrictModel>> func = FunctionHandler;
			using(var handlerWrapper = HandlerWrapper.GetHandlerWrapper(func, new JsonSerializer()))
			{
				using(var lambdaBootstrap = new LambdaBootstrap(handlerWrapper))
				{
					await lambdaBootstrap.RunAsync();
				}
			}
		}
        
        public static List<DistrictModel> FunctionHandler(ILambdaContext context)
        {
            Function fn = new Function();
            Services service = fn._service.GetService<Services>();
            List<DistrictModel> districts = service.List_district();

            return districts;
        }
    }
}
