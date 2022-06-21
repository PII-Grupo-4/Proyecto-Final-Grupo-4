using NUnit.Framework;
using Battleship;

namespace Library.Tests
{
    // el usuario puede ver sus dos tableros mientras posiciona los barcos y mientras juega
    // cuando desee
    public class SeeBoardsHandleTest
    {
        SeeBoardsHandle handler;
        Message message;
        User user1;
        User user2;

        [SetUp]
        public void Setup()
        {
            handler = new SeeBoardsHandle(null);
            message = new Message();

            user1 = new User("a");
            user2 = new User("b");

            message.id = user1.GetID();

            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);
        }

        [Test]
        public void TestSearchGameHandler()
        {
            message.Text = handler.Keywords[0];
            string response;
            user1.ChangeStatus("position ships");
            user2.ChangeGameMode("normal");
            user2.ChangeStatus($"in {user2.GetGameMode()} game");

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user1.GetPlayer().GetBoardsToPrint()}"));

            message.id = user1.GetID();

            result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user2.GetPlayer().GetBoardsToPrint()}"));
            
        }

    }
}