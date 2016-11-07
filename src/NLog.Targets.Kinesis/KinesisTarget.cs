#region

using System;
using NLog.Config;

#endregion

namespace NLog.Targets.Kinesis
{
    [Target("Kinesis")]
    public sealed class KinesisTarget : TargetWithLayout
    {
        private  KinesisUpload _upload;

        public string AwsKey { get; set; }

        public string AwsSecret { get; set; }

        public string AwsRegion { get; set; }

        [RequiredParameter]
        public string Stream { get; set; }

        [RequiredParameter]
        public bool UseAppConfig  { get; set; }

        protected override void Write(LogEventInfo logEvent)
        {
            if (_upload == null)
            {
                LoadKinesisUploader();
            }

            Log.Logger().Debug("[KinesisTarget.Write] About to Write");

            _upload.Write(Layout.Render(logEvent), Stream);
        }

        private void LoadKinesisUploader()
        {
            if (UseAppConfig)
            {
                Log.Logger().Debug("[KinesisTarget.LoadKinesisUploader] Using AppSetting");

                AwsKey = System.Configuration.ConfigurationManager.AppSettings["NLogKinesisAwsKey"];
                AwsSecret = System.Configuration.ConfigurationManager.AppSettings["NLogKinesisAwsSecret"];
                AwsRegion = System.Configuration.ConfigurationManager.AppSettings["NLogKinesisAwsRegion"];

            }

            if (string.IsNullOrEmpty(AwsKey))
            {
                throw new Exception("Required Parameters AwsKey is not set");
            }

            if (string.IsNullOrEmpty(AwsSecret))
            {
                throw new Exception("Required Parameters AwsSecret is not set");
            }

            if (string.IsNullOrEmpty(AwsRegion))
            {
                throw new Exception("Required Parameters AwsRegion is not set");
            }

            if (string.IsNullOrEmpty(Stream))
            {
                throw new Exception("Required Parameters Stream is not set");
            }

            Log.Logger().Debug("[KinesisTarget.LoadKinesisUploader] Load KinesisUpload");

            _upload = new KinesisUpload(AwsKey, AwsSecret, AwsRegion);
        }
    }
}