using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.PeriodicBatching;

namespace Serilog.Sinks.Kafka
{
    public class KafkaSink : ILogEventSink, IDisposable
    {
        private readonly KafkaSinkConfiguration _config;
        private readonly IProducer<Null, LogEvent> _producer;

        public KafkaSink(KafkaSinkConfiguration config)
        {
            _config = config;
            _producer = new ProducerBuilder<Null, LogEvent>(config)
                .SetValueSerializer(new AsyncLogEventSerializer())
                .Build();
        }

        public void Emit(LogEvent logEvent)
        {
            Task.Run(async () =>
            {
                await _producer.ProduceAsync(_config.Topic, new Message<Null, LogEvent> { Value = logEvent });
            });
        }


        public void Dispose()
        {
            _producer.Flush(TimeSpan.FromSeconds(10));
            _producer.Dispose();
        }
    }
}