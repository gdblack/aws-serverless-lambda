using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AWSLambda1.Domain
{
    //{
    //"version": "1",
    //"triggerSource": "TokenGeneration_Authentication",
    //"region": "us-east-1",
    //"userPoolId": "us-east-1_RJ6HNm2B0",
    //"userName": "grant.black+lambda@kinhr.com",
    //"callerContext": {
    //    "awsSdkVersion": "aws-sdk-dotnet-coreclr-3.3.109.18",
    //    "clientId": "72v4f3i0eqgcbrol4ul3e1qnlf"
    //},
    //"request": {
    //    "userAttributes": {
    //        "sub": "92b7c521-605e-4f92-9bc0-09c5dc73e0d6",
    //        "email_verified": "false",
    //        "cognito:user_status": "CONFIRMED",
    //        "custom:role": "account_owner",
    //        "email": "grant.black+lambda@kinhr.com"
    //    },
    //    "groupConfiguration": {
    //        "groupsToOverride": [],
    //        "iamRolesToOverride": [],
    //        "preferredRole": null
    //    }
    //},
    //"response": {
    //    "claimsOverrideDetails": null
    //}
    //}

    public class PreTokenGenerationRequest : AbstractTriggerRequest
    {

    }

    public class PreTokenGenerationResponse : AbstractTriggerResponse
    {

    }

    public class PreTokenGeneration : AbstractTriggerBase<PreTokenGenerationRequest, PreTokenGenerationResponse>
    {

    }

    public abstract class AbstractTriggerRequest
    {
        [JsonProperty("userAttributes")]
        public Dictionary<string, string> UserAttributes { get; set; }
        [JsonProperty("groupConfiguration")]
        public GroupConfiguration GroupConfiguration { get; set; }
    }

    public abstract class AbstractTriggerResponse
    {
        [JsonProperty("groupConfiguration")]
        public Dictionary<string, string> ClaimsToAddOrOverride { get; set; }
    }

    public class TriggerCallerContext
    {
        [JsonProperty("awsSdkVersion")]
        public string AwsSdkVersion { get; set; }
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
    }

    public class GroupConfiguration
    {
        [JsonProperty("groupsToOverride")]
        public IEnumerable<string> GroupsToOverride { get; set; }
        [JsonProperty("iamRolesToOverride")]
        public IEnumerable<string> IamRolesToOverride { get; set; }
        [JsonProperty("preferredRole")]
        public string PreferredRole { get; set; }
    }

    public abstract class AbstractTriggerBase<TRequest, TResponse>
        where TRequest : AbstractTriggerRequest
        where TResponse : AbstractTriggerResponse
    {
        [JsonProperty("version")]
        public int Version { get; set; }
        [JsonProperty("triggerSource")]
        public string TriggerSource { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("userPoolId")]
        public string UserPoolId { get; set; }
        [JsonProperty("callerContext")]
        public TriggerCallerContext CallerContext { get; set; }
        [JsonProperty("request")]
        public TRequest Request { get; set; }
        [JsonProperty("response")]
        public TResponse Response { get; set; }
        [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
    }


}
