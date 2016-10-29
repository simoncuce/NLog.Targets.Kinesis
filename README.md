# NLog.Targets.Kinesis
This project is an NLog Target that connects to AWS Kinesis.

This is in Alpha. Testing to be completed 

[![GoogleAnalyticsTracker Nightly Build Status](https://www.myget.org/BuildSource/Badge/googleanalyticstracker?identifier=22c7cb16-bd83-4e97-8c33-2f5f366f0796)](https://www.myget.org/gallery/googleanalyticstracker)

## Purpose

AWS Kinesis is a high volume enabled data streaming service.
To quote from the [AWS site](https://aws.amazon.com/kinesis/streams/)

> Amazon Kinesis Streams enables you to build custom applications that process or analyze streaming data for specialized needs. Amazon Kinesis Streams can continuously capture and store terabytes of data per hour from hundreds of thousands of sources such as website clickstreams, financial transactions, social media feeds, IT logs, and location-tracking events. 

NLog is one of the most popular and powerful .NET logging tools available. [NLog](http://nlog-project.org/)

The purpose of this project is to provide an out of box Nuget packake containing a ready made Target for uploading Log information to Kinesis.

## How to Install

To use this package, you will firstly need to installed the Nuget package.

```
PM> Install-Package NLog.Targets.Kinesis -Version 1.0.0
```
The package has two depenencies and will download automatically

```
AWSSDK.Core (>= 3.3.0.0)
AWSSDK.Kinesis (>= 3.3.0.0)
NLog.Config (>= 4.3.10)
```

## Configuration

For general instructions on how to configure NLog [visit the tutorials](https://github.com/NLog/NLog/wiki/Tutorial)

For configuration of the Kinesis Target, there are four required parameters
* Type - "Kinesis"
* AwsKey - Your AWS Key
* AwsSecret - Your AWS Secret
* AwsRegion - The region in which Kinesis is setup
* Stream - The name of the Kinesis stream


```
<targets>
   <target name="errorLog" xsi:type="Kinesis" AwsKey="____" AwsSecret="____" AwsRegion="_____" Stream="______" />
</targets>
```

## Troubleshooting

TBD

## Future Work

* .NET Core Version
* Implement different AWS authernication approaches


