using Chat_Bot_MV;

namespace TestClass
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyChatBot cb = new MyChatBot();

            cb.SetUserName("rew");
            Assert.AreEqual("rew", cb.GetUserName());

            cb.SetUserName("pol");
            Assert.AreEqual("pol", cb.GetUserName());

            cb.SetUserName("gty");
            Assert.AreEqual("gty", cb.GetUserName());
        }

        [TestMethod]
        public void TestMethod_answer()
        {
            MyChatBot cb = new MyChatBot();
            string st = "Сейчас: " + DateTime.Now.ToString("HH:mm");
            string sd = "Сегодня: " + DateTime.Now.ToString("dd.MM.yy");

            Assert.AreEqual(st, cb.Answer("время"));
            Assert.AreEqual(st, cb.Answer("час"));
            Assert.AreEqual(st, cb.Answer("time"));

            Assert.AreEqual(sd, cb.Answer("число"));
            Assert.AreEqual(sd, cb.Answer("дата"));
            Assert.AreEqual(sd, cb.Answer("дату"));


            Assert.AreEqual(21.0, float.Parse(cb.Answer("сложи 12 и 9")), 0.0001);
            Assert.AreEqual(85.0, float.Parse(cb.Answer("сложи 0 и 85")), 0.0001);

            Assert.AreEqual(-3.0, float.Parse(cb.Answer("вычти 12 из 9")), 0.0001);
            Assert.AreEqual(3.0, float.Parse(cb.Answer("вычти 3 из 6")), 0.0001);

            Assert.AreEqual(108.0, float.Parse(cb.Answer("умножь 12 на 9")), 0.0001);
            Assert.AreEqual(0.0, float.Parse(cb.Answer("умножь 0 на 8")), 0.0001);

            Assert.AreEqual(1.3333, float.Parse(cb.Answer("раздели 12 на 9")), 0.0001);
            Assert.AreEqual(4.0, float.Parse(cb.Answer("раздели 100 на 25")), 0.0001);

            Assert.AreEqual("Я вас не понимаю :(", cb.Answer("Поставьте 3 за экзамен пожайлуста"));
        }
    }
}