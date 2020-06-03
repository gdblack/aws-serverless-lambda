using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace AWSLambda1.Domain
{
    public class AwsParameterStoreClient
    {
        private readonly RegionEndpoint _region;

        public AwsParameterStoreClient(
            RegionEndpoint region)
        {
            _region = region;
        }

        public async Task<string> GetValueAsync(string parameter)
        {
            var chain = new CredentialProfileStoreChain();
            AWSCredentials awsCredentials;
            AmazonSimpleSystemsManagementClient ssmClient;

            ssmClient = chain.TryGetAWSCredentials("default", out awsCredentials)
                ? new AmazonSimpleSystemsManagementClient(awsCredentials, _region)
                : new AmazonSimpleSystemsManagementClient(_region);

            var response = await ssmClient.GetParameterAsync(new GetParameterRequest
            {
                Name = parameter,
                WithDecryption = true
            });

            return response.Parameter.Value;
        }
    }
}
