using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstConsumerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumeController : ControllerBase
    {
        [HttpGet("GetMessage")]
        public IActionResult GetMessage()
        {

            var consumergroup = "TestGroup1";
            var topicName = "deneme";
            var kafkaUrl = "localhost:9092";
            var config = new ConsumerConfig {GroupId="1", BootstrapServers = kafkaUrl };

            using (var consumer = new ConsumerBuilder<string, string>(config)
               .Build())
            {
                consumer.Subscribe(topicName);

                ConsumeResult<string, string> consumeResult = consumer.Consume();                
                return Ok(consumeResult);

            }

           
        }
    }
}
