using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using aws_lambda_crt_db;

namespace aws_lambda_crt_db.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestInputName()
        {
            DistrictModel expected = new DistrictModel { 
                    DistrictId = 1,
                    Code = 222,
                    TitleEng = "test",
                    TitleTha = "ทดสอบ",
                    ProvinceId = 333
                };

            // Invoke the lambda function and confirm the string was upper cased.
            var context = new TestLambdaContext();
            DistrictModel result = Function.FunctionHandler("hello world", context);

            Assert.Equal(expected.DistrictId, result.DistrictId);
            Assert.Equal(expected.Code, result.Code);
            Assert.Equal(expected.TitleEng, result.TitleEng);
            Assert.Equal(expected.TitleTha, result.TitleTha);
            Assert.Equal(expected.ProvinceId, result.ProvinceId);
        }
    }
}
