using System;
using System.Collections.Generic;
using System.Text;

namespace AWSLambda1.Domain
{
    //{
    //"request": {
    //    "userAttributes": {
    //        "string": "string",
    //            . . .
    //    },
    //    "groupConfiguration": {
    //        "groupsToOverride": ["string", . . .],
    //        "iamRolesToOverride": ["string", . . .],
    //        "preferredRole": "string",
    //        "clientMetadata": {
    //            "string": "string",
    //                . . .
    //        }
    //    },
    //    "response": {
    //        "claimsOverrideDetails": {
    //            "claimsToAddOrOverride": {
    //                "string": "string",
    //                    . . .
    //            },
    //            "claimsToSuppress": ["string", . . .],

    //            "groupOverrideDetails": {
    //                "groupsToOverride": ["string", . . .],
    //                "iamRolesToOverride": ["string", . . .],
    //                "preferredRole": "string"
    //            }
    //        }
    //    }
    //}
    public class PretokenEvent
    {
        public LambdaRequest Request { get; set; }
        public LambdaResponse Response { get; set; }
    }

    public class LambdaResponse
    {

    }

    public class LambdaRequest
    {

    }
    
}
