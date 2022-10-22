using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()//тесстирование ф-ции умножения
        {
            //Настройка
            float operant1 = 12;
            float operant2 = 32;
            string expected = "384";
            Form1 asd = new Form1();

            //Выполнение
            string actual = asd.Multipl(operant1, operant2);

            //Проверка
            Assert.AreEqual(expected, actual, true, "Умножение не удалось");
        }

        [TestMethod]
        public void TestMethod2()//тестирование ф-ции деления
        {
            //Настройка
            float operant1 = 12;
            float operant2 = 32;
            string expected = "44";
            Form1 asd = new Form1();

            //Выполнение
            string actual = asd.Plus(operant1, operant2);

            //Проверка
            Assert.AreEqual(expected, actual, true, "Сложение не удалось");
        }

        [TestMethod]
        public void TestMethod3()//тестирование ф-ции вычитания
        {
            //Настройка
            float operant1 = 12;
            float operant2 = 32;
            string expected = "-20";
            Form1 asd = new Form1();

            //Выполнение
            string actual = asd.Minus(operant1, operant2);

            //Проверка
            Assert.AreEqual(expected, actual, true, "Вычитание не удалось");
        }

        [TestMethod]
        public void TestMethod4()//тестирование ф-ции деления
        {
            //Настройка
            float operant1 = 12;
            float operant2 = 32;
            string expected = "0,375";
            Form1 asd = new Form1();

            //Выполнение
            string actual = asd.Division(operant1, operant2);

            //Проверка
            Assert.AreEqual(expected, actual, true, "Деление не удалось");
        }

        [TestMethod]
        public void TestMethod5()//тестирование ф-ции факториала
        {
            //Настройка
            float operant1 = 5;
            string expected = "120";
            Form1 asd = new Form1();

            //Выполнение
            string actual = asd.FactorialS(operant1);

            //Проверка
            Assert.AreEqual(expected, actual, false, "Факториал неверный");
        }

        [TestMethod]
        public void TestMethod6()//тестирование того, что деление на 0 невозможно (в этом калькуляторе)
        {
            //Настройка
            float operant1 = 12;
            float operant2 = 0;
            string expected = "Деление на 0 недопустимо";
            Form1 asd = new Form1();

            //Выполнение
            string actual = asd.Division(operant1, operant2);

            //Проверка
            Assert.AreEqual(expected, actual, true, "Деление не удалось");
        }

        [TestMethod]
        public void TestMethod7()//тестирование того, что вычисление отрицательного факториала невозможно
        {
            //Настройка
            float operant1 = -12;
            string expected = "Недопустимый ввод";
            Form1 asd = new Form1();

            //Выполнение
            string actual = asd.FactorialS(operant1);

            //Проверка
            Assert.AreEqual(expected, actual, false, "Факториал неверный");
        }
    }
}
