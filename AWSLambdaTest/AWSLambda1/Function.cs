using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Amazon.Lambda.CognitoEvents;
using Dapper;
using Amazon.Lambda.Core;
using AWSLambda1.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
        public CognitoEvent FunctionHandler(CognitoEvent input, ILambdaContext context)
        {
            
            // In order to standardize your parameters system wide you should store any environment variables
            // in the SSM parameter store so you don't have to manage parameters for each lambda function.

            //var client = new AwsParameterStoreClient(Amazon.RegionEndpoint.USEast1);

            //var kinDb = await client.GetValueAsync("/ConnectionString/Dev/KinhrDB");
            //var cognitoDb = await client.GetValueAsync("/ConnectionString/Dev/CognitoUsersDB");

            //var response = new List<Claim>();
            //try
            //{
            //    using (var connString = new SqlConnection(cognitoDb))
            //    {
            //        connString.Open();
            //        var query = @"select c.* from RoleClaims rc
            //                  inner join Roles r on r.Id = rc.RoleId
            //                  inner join Claims c on c.Id = rc.ClaimId
            //                  where r.Code = @Code;";
            //        response = connString.Query<Claim>(query, new { Code = input }).ToList();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            
            LambdaLogger.Log(input.EventType);

            return input;
        }
    }

    public class Claim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public static class JsonSerializer
    {
        static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            ContractResolver = new CamelCasePropertyNamesExceptIDContractResolver(),
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
        };

        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o, Settings);
        }

        public static string ToJSON(this object o)
        {
            return Serialize(o);
        }

        public static T FromJSON<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, Settings);
        }
    }

    public class CamelCasePropertyNamesExceptIDContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var res = base.CreateProperty(member, memberSerialization);
            if (res.PropertyName.ToLower() == "id")
                res.PropertyName = "id"; //ensure obj.ID is converted to obj.id vs obj.iD

            return res;
        }

    }
}
