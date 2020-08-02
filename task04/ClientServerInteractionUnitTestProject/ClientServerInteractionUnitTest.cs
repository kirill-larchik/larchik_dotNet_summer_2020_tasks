using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientServerInteractionClassLibrary;
using System.Threading;

namespace ClientServerInteractionUnitTestProject
{
    [TestClass]
    public class ClientServerInteractionUnitTest
    {
        [TestMethod]
        [DataRow("127.0.0.1", 8001, "Hello", "World!", "Your message is succesuful sended.", "Your message is succesuful sended.")]
        [DataRow("127.0.0.1", 8002, "How", "Are you?", "Your message is succesuful sended.", "Your message is succesuful sended.")]
        [DataRow("127.0.0.1", 8003, "123qwerty", "World!", "It`s OK!", "It`s OK!")]
        [DataRow("127.0.0.1", 8004, "Hello", "123qwerty!", "Your message is succesuful sended.", "Your message is succesuful sended.")]
        [DataRow("127.0.0.1", 8005, "123qwerty", "123qwerty!", "Returns message!", "Returns message!")]
        public void SendAndReciveMessage_ClientToServer_TwoClients(string ipString, int port, string firstMessage, string secondMessage, string answer, string expected)
        {
            Server server = new Server(ipString, port);
            Client firstClient = new Client("first", ipString, port);
            Client secondClient = new Client("second", ipString, port);
        
            server.Run();

            firstClient.SendMessage(firstMessage);
            server.ReciveMessages(answer);
            string firstActual = firstClient.ReciveMessage();

            secondClient.SendMessage(secondMessage);
            server.ReciveMessages(answer);
            string secondActual = secondClient.ReciveMessage();

            Assert.IsTrue(expected == firstActual && expected == secondActual);
        }

        [TestMethod]
        [DataRow("127.0.0.1", 8006, "Hello", "World!", "Your message is succesuful sended.")]
        [DataRow("127.0.0.1", 8007, "How", "Are you?", "Your message is succesuful sended.")]
        [DataRow("127.0.0.1", 8008, "123qwerty", "World!", "Your message is succesuful sended.")]
        [DataRow("127.0.0.1", 8009, "Hello", "123qwerty!", "Your message is succesuful sended.")]
        [DataRow("127.0.0.1", 8010, "123qwerty", "123qwerty!", "Your message is succesuful sended.")]
        public void ReciveMessage_FromServer_OneClient_ManyMessages(string ipString, int port, string firstMessage, string secondMessage, string expected)
        {
            Server server = new Server(ipString, port);
            Client firstClient = new Client("first", ipString, port);

            server.Run();

            firstClient.SendMessage(firstMessage);
            server.ReciveMessages();
            string firstActual = firstClient.ReciveMessage();

            firstClient.SendMessage(secondMessage);
            server.ReciveMessages();
            string secondActual = firstClient.ReciveMessage();

            Assert.IsTrue(expected == firstActual && expected == secondActual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Impossible to run the server.")]
        [DataRow("127.0.0.1", 8011)]
        [DataRow("127.0.0.1", 8012)]
        [DataRow("127.0.0.1", 8013)]
        [DataRow("127.0.0.1", 8014)]
        [DataRow("127.0.0.1", 8015)]
        public void Run_TwoRuns_GetException(string ipString, int port)
        {
            Server server = new Server(ipString, port);

            server.Run();
            server.Run();
        }

        [TestMethod]
        [DataRow("127.0.0.1", 8016, "Hello", "Hello")]
        [DataRow("127.0.0.1", 8017, "How", "How")]
        [DataRow("127.0.0.1", 8018, "123qwerty", "123qwerty")]
        [DataRow("127.0.0.1", 8019, "123qwerty!", "123qwerty!")]
        [DataRow("127.0.0.1", 8020, "12312312!", "12312312!")]
        public void SendMessage_FromServerToClient(string ipString, int port, string firstMessage, string expected)
        {
            Server server = new Server(ipString, port);
            Client firstClient = new Client("first", ipString, port);

            server.Run();

            firstClient.SendMessage(firstMessage);
            string actual = server.ReciveMessages();

            Assert.AreEqual(expected, actual);
        }
    }
}
