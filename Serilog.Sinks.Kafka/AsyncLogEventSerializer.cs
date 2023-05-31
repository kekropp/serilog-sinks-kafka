using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using Serilog.Events;

namespace Serilog.Sinks.Kafka
{
    public class AsyncLogEventSerializer : IAsyncSerializer<LogEvent>
    {
        public async Task<byte[]> SerializeAsync(LogEvent data, SerializationContext context)
        {
            return await Task.Run(() => System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
        }
    }
}