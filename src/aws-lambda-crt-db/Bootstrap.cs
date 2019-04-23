using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace aws_lambda_crt_db
{
    public class Bootstrap
    {
        public static ServiceProvider CreateInstance()
        {
            return new ServiceCollection()
            .AddDbContext<DistrictContext>(options => options.UseMySQL(LambdaConfiguration.Instance["DB_CONNECTION"]))
            .AddSingleton<Services, Services>()
            .BuildServiceProvider();
        }
    }
}