using System;
using KafkaNet.Model;
using KafkaNet;
using System.Collections.Generic;
using KafkaNet.Protocol;

namespace ProducerNamespace
{
    public class Program
    {

        static void Main(string[] args)
        {
            ProduceMessages pM = new ProduceMessages();
            pM.Producer();
        }
    }

    public class ProduceMessages
    {
        Message brandName = new Message("Mercedes");
        Message model = new Message("GLS");
        Message numberOfDoors = new Message("5");
        Message isSport = new Message("yes");

        public Message BrandName { get { return new Message("Mercedes"); } }
        public Message Model { get { return new Message("GLS"); } }
        public Message NumberOfDoors { get { return new Message("5"); } }
        public Message IsSport { get { return new Message("yes"); } }

        public void Producer()
        {
            string topic = "cars";

            List<Message> messages = new List<Message>() { brandName,model,numberOfDoors,isSport };

            Uri uri = new Uri("http://localhost:9092");
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var producer = new Producer(router);
            producer.SendMessageAsync(topic, messages).Wait();

        }
    }
}
