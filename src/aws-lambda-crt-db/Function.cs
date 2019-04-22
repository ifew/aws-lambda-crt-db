using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace aws_lambda_crt_db
{
    public class Function
    {
        private ServiceProvider _service;

        public Function()
            : this (Bootstrap.CreateInstance()) {}

        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Function(ServiceProvider service)
        {
            _service = service;
        }

        private static async Task Main(string[] args)
        {
            Func<string, ILambdaContext, DistrictModel> func = FunctionHandler;
            using(var handlerWrapper = HandlerWrapper.GetHandlerWrapper(func, new JsonSerializer()))
            using(var bootstrap = new LambdaBootstrap(handlerWrapper))
            {
                await bootstrap.RunAsync();
            }
        }

        public static DistrictModel FunctionHandler(string name, ILambdaContext context)
        {
            //Services service = _service.GetService<Services>();
            //List<DistrictModel> districts = service.List_district();

            // APIGatewayProxyResponse respond = new APIGatewayProxyResponse {
            //     StatusCode = (int)HttpStatusCode.OK,
            //     Headers = new Dictionary<string, string>
            //     { 
            //         { "Content-Type", "application/json" }, 
            //         { "Access-Control-Allow-Origin", "*" } 
            //     },
            //     Body = "{}" //JsonConvert.SerializeObject(districts)
            // };
            
            return new DistrictModel { 
                    DistrictId = 1,
                    Code = 222,
                    TitleEng = "test",
                    TitleTha = "ทดสอบ",
                    ProvinceId = 333
                };
        }
    }
}
