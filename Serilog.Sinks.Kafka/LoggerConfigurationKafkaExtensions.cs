using Serilog.Configuration;

namespace Serilog.Sinks.Kafka
{
    /// <summary>
    ///     Adds the WriteTo.Kafka() extension method to <see cref="LoggerConfiguration" />.
    /// </summary>
    public static class LoggerConfigurationKafkaExtensions
    {
        public static LoggerConfiguration Kafka(
            this LoggerSinkConfiguration loggerConfiguration,
            KafkaSinkConfiguration sinkConfiguration)
        {
            return loggerConfiguration.Sink(new KafkaSink(sinkConfiguration));
        }
    }
}