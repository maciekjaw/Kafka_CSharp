using KafkaNet;
using KafkaNet.Model;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProducerNamespace;

namespace ConsumerNamespa
{

    class Program
    {
        static void Main(string[] args)
        {
            ConsumeMessages cM = new ConsumeMessages();
            cM.Consume();
        }
    }

    public class ConsumeMessages
    {
        public void Consume()
        {
            ProduceMessages pM = new ProduceMessages();

            string topic = "cars";

            Uri uri = new Uri("http://localhost:9092");
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var newrouter = new BrokerRouter(options);
            ConsumerOptions cO = new ConsumerOptions(topic, router);
            var consumer = new Consumer(cO);

            foreach (var message in consumer.Consume())
            {
                List<string> setOfMessages = new List<string>();
                setOfMessages.Add(Encoding.UTF8.GetString(message.Value));
                Console.WriteLine(Encoding.UTF8.GetString(message.Value));
                Assert.AreEqual(setOfMessages[0], pM.BrandName);
                Assert.AreEqual(setOfMessages[1], pM.Model);
                Assert.AreEqual(setOfMessages[2], pM.NumberOfDoors);
                Assert.AreEqual(setOfMessages[3], pM.IsSport);
            }

        }

    }
}
