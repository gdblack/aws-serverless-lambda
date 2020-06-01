using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using AWSLambda1.Domain;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambda1
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            // In order to standardize your parameters system wide you should store any environment variables
            // in the SSM parameter store so you don't have to manage parameters for each lambda function.

            var client = new AwsParameterStoreClient(Amazon.RegionEndpoint.USEast1);

            var value = await client.GetValueAsync("Test-Parameter");

            return value?.ToUpper();
        }
    }
}
