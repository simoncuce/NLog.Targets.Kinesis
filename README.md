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
PM> Install-Package NLog.Targets.Kinesis -Version 1.0.1
```
The package has two depenencies and will download automatically

```
AWSSDK.Kinesis (>= 3.3.0.0)
NLog.Config (>= 4.3.10)
```

## Configuration

For general instructions on how to configure NLog [visit the tutorials](https://github.com/NLog/NLog/wiki/Tutorial)

For configuration of the Kinesis Target, there are five parameters
* Type - "Kinesis"
* AwsKey - Your AWS Key
* AwsSecret - Your AWS Secret
* AwsRegion - The region in which Kinesis is setup
* Stream - The name of the Kinesis stream
* UseAppConfig - If using the appSetting to store the AwsKey, AwsSecret and AwsRegion


```
<targets>
   <target name="errorLog" type="Kinesis" UseAppConfig="false" AwsKey="____" AwsSecret="____" AwsRegion="_____" Stream="______" />
</targets>
```

The other options is to store the AwsKey, AwsSecret and AwsRegion in the AppConfig section in app.config or web.config. 

You will notice that config names are different. This is to ensure that there is no name conflict.

```

<configuration>
  <appSettings>
    <add key="NLogKinesisAwsKey" value="" />
    <add key="NLogKinesisAwsSecret" value="" />
    <add key="NLogKinesisAwsRegion" value="" />
   </appSettings>
</configuration>

<extensions>
      <add assembly="NLog.Targets.Kinesis" />
</extensions>

<targets>
   <target name="errorLog" type="Kinesis" UseAppConfig="true" Stream="______" />
</targets>
```


## Troubleshooting



## Future Work

* .NET Core Version


