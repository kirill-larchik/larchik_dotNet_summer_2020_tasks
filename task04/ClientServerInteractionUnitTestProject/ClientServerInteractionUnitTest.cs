using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientServerInteractionClassLibrary;
using ClientServerInteractionClassLibrary.EncoidngTypes;

namespace ClientServerInteractionUnitTestProject
{
    [TestClass]
    public class ClientServerInteractionUnitTest
    {
        [TestMethod]
        [DataRow("127.0.0.1", 8001, "hello world!", "хелло ворлд!")]
        [DataRow("127.0.0.1", 8002, "how", "хов")]
        [DataRow("127.0.0.1", 8003, "123раз", "123raz")]
        [DataRow("127.0.0.1", 8004, "Привет", "privet")]
        [DataRow("127.0.0.1", 8005, "How are you?", "хов аре уою?")]
        public void ReciveMessage_Client_TransleteMessage(string ipString, int port, string message, string expected)
        {
            Server server = new Server(ipString, port);
            Client client = new Client("first", ipString, port);

            ClientEncodingType clientEncoding = new ClientEncodingType();
            client.EncodingMessageEvent += clientEncoding.EncodingMessage;
        
            server.Run();

            client.SendMessage(message);
            server.ReciveMessages(message);
            string actual = client.ReciveMessage();

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //[DataRow("127.0.0.1", 8016, "Hello", "Hello")]
        //[DataRow("127.0.0.1", 8017, "How", "How")]
        //[DataRow("127.0.0.1", 8018, "123qwerty", "123qwerty")]
        //[DataRow("127.0.0.1", 8019, "123qwerty!", "123qwerty!")]
        //[DataRow("127.0.0.1", 8020, "12312312!", "12312312!")]
        //public void SendMessage_FromClientToServer(string ipString, int port, string firstMessage, string expected)
        //{
        //    Server server = new Server(ipString, port);
        //    Client firstClient = new Client("first", ipString, port);

        //    server.Run();

        //    firstClient.SendMessage(firstMessage);
        //    string actual = server.ReciveMessages();

        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        [ExpectedException(typeof(Exception), "Impossible to run the server.")]
        [DataRow("127.0.0.1", 8011)]
        [DataRow("127.0.0.1", 8012)]
        [DataRow("127.0.0.1", 8013)]
        [DataRow("127.0.0.1", 8014)]
        [DataRow("127.0.0.1", 8015)]
        public void Run_GetException(string ipString, int port)
        {
            Server server = new Server(ipString, port);

            server.Run();
            server.Run();
        }
    }
}
