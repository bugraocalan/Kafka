using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProducerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceController : ControllerBase
    {
        [HttpGet("SendMessage")]
        public IActionResult SendMessage(string message)
        {
            var topicName = "deneme";
            var kafkaUrl = "localhost:9092";
            var config = new ProducerConfig() { BootstrapServers = kafkaUrl };
            var producerBuilder = new ProducerBuilder<string, string>(config);
            var producer = producerBuilder.Build();
            var result = producer.ProduceAsync(topicName, new Message<string, string>() { Value = message }).GetAwaiter().GetResult();


            return Ok(result.TopicPartitionOffset);

        }
    }

}
