# Serilog.Sinks.Kafka

Writes LogEvents to a Kafka Cluster.

```csharp
Log.Logger = new LoggerConfiguration()
	.WriteTo.Kafka(new KafkaSinkConfiguration() {
    BootstrapServers = "localhost:9092",
    Topic = "serilog-kafka-sink"
  })
	.CreateLogger();
```
### JSON `appsettings.json` configuration

A Serilog settings provider that reads from _Microsoft.Extensions.Configuration_, .NET Core's `appsettings.json` file.

Configuration is read from the `Serilog` section.

```json
{
  "Serilog": {
    "Using": [ "Serilog.Sinks.Kafka" ],
    "MinimumLevel": {
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "Kafka",
        "Args": { "sinkConfiguration": {
          "bootstrapServers": "localhost:9092",
          "topic": "serilog-kafka-sink"
        } }
      }
    ],
    "Properties": {
      "Application": "Kafka"
    }
  }
}
```

Inspired in large parts by: https://github.com/lurumad/serilog-sinks-kafka

