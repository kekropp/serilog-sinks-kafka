using Confluent.Kafka;

namespace Serilog.Sinks.Kafka
{
    public class KafkaSinkConfiguration : ProducerConfig
    {
        public string Topic { get; set; }
    }
}