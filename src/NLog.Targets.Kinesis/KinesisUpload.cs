#region

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

#endregion

namespace NLog.Targets.Kinesis
{
    public class KinesisUpload
    {
        private readonly AmazonKinesisClient _client;
        private readonly string _partitionKey;

        public KinesisUpload(string awsKey, string awsSecret, string region, string partitionKey = "")
        {
            _partitionKey = string.IsNullOrEmpty(partitionKey) ? Guid.NewGuid().ToString() : partitionKey;
            _client = new AmazonKinesisClient(awsKey, awsSecret, RegionEndpoint.GetBySystemName(region));
        }

        public PutRecordResponse Write(string logMessage, string streamName)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(logMessage)))
            {
                var requestRecord = new PutRecordRequest
                {
                    StreamName = streamName,
                    Data = ms,
                    PartitionKey = _partitionKey
                };

                return _client.PutRecord(requestRecord);
            }
        }

        public async Task<PutRecordResponse> WriteAsync(string logMessage, string streamName)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(logMessage)))
            {
                var requestRecord = new PutRecordRequest
                {
                    StreamName = streamName,
                    Data = ms,
                    PartitionKey = _partitionKey
                };

                return await _client.PutRecordAsync(requestRecord);
            }
        }
    }
}