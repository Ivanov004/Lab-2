using System;

namespace CTP_laba2_zad3

{
    public class Angle
    {
        public int degrees;
        public int minutes;
        public int seconds;

        // Метод инициализации
        public void Init(int deg, int min, int sec)
        {
            degrees = deg;
            minutes = min;
            seconds = sec;
        }

        // Метод для ввода данных с клавиатуры
        public void Read()
        {
            Console.Write("Введите градусы: ");
            degrees = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите минуты: ");
            minutes = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите секунды: ");
            seconds = Convert.ToInt32(Console.ReadLine());
        }

        // Метод для отображения угла
        public void Display()
        {
            Console.WriteLine($"Угол: {degrees}° {minutes}' {seconds}\"");
        }

        // Метод для округления угла до ближайших градусов
        public void RoundToDegrees()
        {
            if (seconds >= 30)
                minutes++;
            if (minutes >= 60)
            {
                degrees++;
                minutes -= 60;
            }
            seconds = 0;
        }

        // Метод для сложения двух углов
        public static Angle Add(Angle a1, Angle a2)
        {
            Angle result = new Angle();

            // Считаем общее количество секунд
            int totalSeconds = (a1.degrees * 3600 + a1.minutes * 60 + a1.seconds) +
                               (a2.degrees * 3600 + a2.minutes * 60 + a2.seconds);

            // Преобразуем секунды в градусы, минуты и секунды
            result.degrees = totalSeconds / 3600;
            totalSeconds %= 3600;
            result.minutes = totalSeconds / 60;
            result.seconds = totalSeconds % 60;

            // Нормализуем секунды и минуты
            if (result.seconds >= 60)
            {
                result.minutes += result.seconds / 60;
                result.seconds %= 60;
            }

            if (result.minutes >= 60)
            {
                result.degrees += result.minutes / 60;
                result.minutes %= 60;
            }

            // Проверим, что минута нормализуется корректно, если это необходимо
            if (result.seconds >= 60)
            {
                result.minutes++;
                result.seconds -= 60;
            }
            if (result.minutes >= 60)
            {
                result.degrees++;
                result.minutes -= 60;
            }

            // Учитываем отрицательные градусы
            if (result.degrees < 0)
            {
                result.degrees = -Math.Abs(result.degrees);
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Работа с углами
            Angle angle1 = new Angle();
            Angle angle2 = new Angle();

            Console.WriteLine("Введите первый угол:");
            angle1.Read();

            Console.WriteLine("Введите второй угол:");
            angle2.Read();

            // Вывод данных и округление углов
            Console.WriteLine("Первый угол:");
            angle1.Display();
            angle1.RoundToDegrees();
            angle1.Display();

            Console.WriteLine("Второй угол:");
            angle2.Display();
            angle2.RoundToDegrees();
            angle2.Display();

            // Сложение двух углов
            Angle result = Angle.Add(angle1, angle2);
            Console.WriteLine("Результат сложения:");
            result.Display();
        }
    }
}

