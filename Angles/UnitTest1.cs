using CTP_laba2_zad3;
using NUnit.Framework;

namespace Angles
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1() // Проверка на верную инициализацию
        {
            //Подготовка
            Angle angle = new Angle();

            //Действие
            angle.Init(44, 55, 17);

            //Проверка
            Assert.AreEqual(44, angle.degrees);
            Assert.AreEqual(55, angle.minutes);
            Assert.AreEqual(17, angle.seconds);
        }

        [Test]
        public void Test2() // Проверка верного окгругления до минут
        {
            //Подготовка
            Angle angle = new Angle();
            angle.Init(44, 55, 55);
            //Действие
            angle.RoundToDegrees();
            //Проверка
            Assert.AreEqual(44, angle.degrees);
            Assert.AreEqual(56, angle.minutes);
            Assert.AreEqual(0, angle.seconds);
        }

        [Test]
        public void Test3() // Проверка верного сложения углов
        {
            //Подготовка
            Angle a1 = new Angle();
            Angle a2 = new Angle();
            a1.Init(44, 55, 17);
            a2.Init(44, 55, 17);
            //Действие
            Angle result = Angle.Add(a1, a2);
            //Проверка
            Assert.AreEqual(89, result.degrees);
            Assert.AreEqual(50, result.minutes);
            Assert.AreEqual(34, result.seconds);
        }
        [Test]
        public void Test4() // Проверка сложения отрицательных углов
        {
            // Подготовка
            Angle a1 = new Angle();
            Angle a2 = new Angle();
            a1.Init(-55, 5, 20);
            a2.Init(-80, 20, 48);

            // Действие
            Angle result = Angle.Add(a1, a2);

            // Проверка
            Assert.AreEqual(-134, result.degrees);
            Assert.AreEqual(-33, result.minutes);
            Assert.AreEqual(-52, result.seconds);
        }


        [Test]
        public void Test5() // Проверка верного вывода угла
        {
            // Подготовка
            Angle angle = new Angle();
            angle.Init(55, 5, 20);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Действие
                angle.Display();

                // Проверка
                string expectedOutput = $"Угол: 55° 5' 20\"{Environment.NewLine}";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }


        [Test]
        public void Test6() // Проверка сложения углов с нулевым градусом
        {
            // Подготовка
            Angle a1 = new Angle();
            Angle a2 = new Angle();
            a1.Init(0, 30, 45);
            a2.Init(0, 45, 30);

            // Действие
            Angle result = Angle.Add(a1, a2);

            // Проверка
            Assert.AreEqual(1, result.degrees);
            Assert.AreEqual(16, result.minutes);
            Assert.AreEqual(15, result.seconds);
        }
        [Test]
        public void Test7() // Проверка сложения углов, где минуты при сложении превышают 60
        {
            // Подготовка
            Angle a1 = new Angle();
            Angle a2 = new Angle();
            a1.Init(20, 55, 30);
            a2.Init(0, 10, 45);

            // Действие
            Angle result = Angle.Add(a1, a2);

            // Проверка
            Assert.AreEqual(21, result.degrees);
            Assert.AreEqual(6, result.minutes);
            Assert.AreEqual(15, result.seconds);
        }
        [Test]
        public void Test8() // Проверка правильность округления угла, если количество секунд больше или равно 30
        {
            // Подготовка
            Angle angle = new Angle();
            angle.Init(45, 59, 45);

            // Действие
            angle.RoundToDegrees();

            // Проверка
            Assert.AreEqual(46, angle.degrees);
            Assert.AreEqual(0, angle.minutes);
            Assert.AreEqual(0, angle.seconds);
        }
        [Test]
        public void Test9() // Проверка сложения углов с отрицательными градусами и минутами
        {
            // Подготовка
            Angle a1 = new Angle();
            Angle a2 = new Angle();
            a1.Init(-15, -45, 30);
            a2.Init(-5, -30, 50);

            // Действие
            Angle result = Angle.Add(a1, a2);

            // Проверка
            Assert.AreEqual(-21, result.degrees);
            Assert.AreEqual(-13, result.minutes); 
            Assert.AreEqual(-40, result.seconds);
        }

        [Test]
        public void Test10() // Проверка сложения при больших значениях угла
        {
            // Подготовка
            Angle a1 = new Angle();
            Angle a2 = new Angle();
            a1.Init(100, 55, 55);
            a2.Init(50, 25, 30);

            // Действие
            Angle result = Angle.Add(a1, a2);

            // Проверка
            Assert.AreEqual(151, result.degrees);
            Assert.AreEqual(21, result.minutes);
            Assert.AreEqual(25, result.seconds);
        }
    }
}


