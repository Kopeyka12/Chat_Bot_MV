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
            string st = "������: " + DateTime.Now.ToString("HH:mm");
            string sd = "�������: " + DateTime.Now.ToString("dd.MM.yy");

            Assert.AreEqual(st, cb.Answer("�����"));
            Assert.AreEqual(st, cb.Answer("���"));
            Assert.AreEqual(st, cb.Answer("time"));

            Assert.AreEqual(sd, cb.Answer("�����"));
            Assert.AreEqual(sd, cb.Answer("����"));
            Assert.AreEqual(sd, cb.Answer("����"));


            Assert.AreEqual(21.0, float.Parse(cb.Answer("����� 12 � 9")), 0.0001);
            Assert.AreEqual(85.0, float.Parse(cb.Answer("����� 0 � 85")), 0.0001);

            Assert.AreEqual(-3.0, float.Parse(cb.Answer("����� 12 �� 9")), 0.0001);
            Assert.AreEqual(3.0, float.Parse(cb.Answer("����� 3 �� 6")), 0.0001);

            Assert.AreEqual(108.0, float.Parse(cb.Answer("������ 12 �� 9")), 0.0001);
            Assert.AreEqual(0.0, float.Parse(cb.Answer("������ 0 �� 8")), 0.0001);

            Assert.AreEqual(1.3333, float.Parse(cb.Answer("������� 12 �� 9")), 0.0001);
            Assert.AreEqual(4.0, float.Parse(cb.Answer("������� 100 �� 25")), 0.0001);

            Assert.AreEqual("� ��� �� ������� :(", cb.Answer("��������� 3 �� ������� ����������"));
        }
    }
}