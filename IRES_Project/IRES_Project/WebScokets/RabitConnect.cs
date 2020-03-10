using IRES_Project.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.WebScokets
{
    public class RabitConnect
    {
        public void ReceiveNotifyRabbitMQ()
        {
            try
            {
                ConnectionFactory factory = new ConnectionFactory();
                factory.UserName = "xarzdlrm";
                factory.Password = "Be9K-7C4C1sO9hiJTJwZSHITqm7NX6LS";
                factory.VirtualHost = "xarzdlrm";
                factory.HostName = "baboon.rmq.cloudamqp.com";
                IConnection conn = factory.CreateConnection();

                var channel = conn.CreateModel();

                var consumer = new EventingBasicConsumer(channel);
                var queueName = IRES_Global.GlobalInfo.CustomerCurrent.username;
                var CustomerChanel = channel.QueueDeclare(queueName).QueueName;
                channel.QueueBind(CustomerChanel, "directExchange", "CUSTOMER");


                Console.WriteLine("connecting to listen");
                consumer.Received += (model, ea) =>
                {
                    var tag = ea.ConsumerTag;
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    if (message != null)
                    {
                        MessagingCenter.Send<RabitConnect, string>(this, "CashSuccess", "thanh toan thanh cong");
                    }
                };
                channel.BasicConsume(queue: CustomerChanel,
                                     autoAck: true,
                                     consumer: consumer);

            }
            catch
            {
                Console.WriteLine("Loi roai");
            }
        }
        
        public void SendNotify()
        {

        }
    }
}
