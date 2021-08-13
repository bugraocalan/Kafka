using Confluent.Kafka;
using System;

namespace Consumer1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var consumergroup = "TestGroup1";
            var topicName = "deneme";
            var kafkaUrl = "localhost:9092";
            var config = new ConsumerConfig { GroupId = consumergroup, BootstrapServers = kafkaUrl };

            while (true)
            {
                using (var consumer = new ConsumerBuilder<string, string>(config)
                  .Build())
                {
                    consumer.Subscribe(topicName);

                    ConsumeResult<string, string> consumeResult = consumer.Consume();
                    Console.WriteLine(consumeResult.Message);
                    consumer.Commit();
                } 
            }
        }
    }
}

