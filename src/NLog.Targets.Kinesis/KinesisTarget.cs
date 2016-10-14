#region

using NLog.Config;

#endregion

namespace NLog.Targets.Kinesis
{
    [Target("MyFirst")]
    public sealed class KinesisTarget : TargetWithLayout
    {
        private readonly KinesisUpload _upload;

        public KinesisTarget()
        {
            _upload = new KinesisUpload(AwsKey, AwsSecret, AwsRegion);
        }

        [RequiredParameter]
        public string AwsKey { get; set; }

        [RequiredParameter]
        public string AwsSecret { get; set; }

        [RequiredParameter]
        public string AwsRegion { get; set; }

        [RequiredParameter]
        public string Stream { get; set; }

        protected override void Write(LogEventInfo logEvent)
        {
            _upload.Write(Layout.Render(logEvent), Stream);
        }
    }
}