using Confluent.Kafka;
using System;

namespace KafkaDemo.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var conf = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092",
            };

            Action<DeliveryReport<Null, string>> handler = r =>
            {
                var conLog = r.Error.IsError ? $"Delivery error: {r.Error.Reason}" : $"Delivered message to {r.TopicPartitionOffset}";
                Console.WriteLine(conLog);
            };

            using (var p = new ProducerBuilder<Null, string>(conf).Build())
            {
                for(var i = 0; i < 100; i++)
                {
                    var msg = new Message<Null, string>()
                    {
                        Value = $"haha,{i}",
                    };
                    p.Produce("my-topic", msg, handler);
                }

                p.Flush(TimeSpan.FromSeconds(10));
            }

        }
    }
}
