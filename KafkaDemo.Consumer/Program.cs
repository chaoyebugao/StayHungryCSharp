using Confluent.Kafka;
using System;
using System.Threading;

namespace KafkaDemo.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var conf = new ConsumerConfig()
            {
                 AutoOffsetReset = AutoOffsetReset.Earliest,
                 BootstrapServers = "localhost:9092",
                 GroupId = "test-consumer-group",
            };

            using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                c.Subscribe("my-topic");

                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (s, e) =>
                {
                    //阻止进程被终止
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(cts.Token);
                            Console.WriteLine($"Consumed message '{cr.Value}' at '{cr.TopicPartitionOffset}'.");
                        }
                        catch(ConsumeException ex)
                        {
                            Console.WriteLine($"Error occured: {ex.Error.Reason}");
                        }
                    }
                }
                catch(OperationCanceledException ex)
                {
                    //保证消费者消费者干净地离开群组且最后一个offsets被提交
                    c.Close();
                }
            }
        }
    }
}
