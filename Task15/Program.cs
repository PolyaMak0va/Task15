using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15
{
    /* Разработать интерфейс ISeries генерации ряда чисел. Интерфейс содержит следующие элементы:
     * метод void setStart(int x) - устанавливает начальное значение
     * метод int getNext() - возвращает следующее число ряда
     * метод void reset() - выполняет сброс к начальному значению
     * Разработать классы ArithProgression и GeomProgression, которые реализуют интерфейс ISeries. 
     * В классах реализовать методы интерфейса в соответствии с логикой арифметической и геометрической прогрессии соответственно.
     */
    class Program
    {
        static void Main(string[] args)
        {
            ArithProgression obj1 = new ArithProgression();
            Console.WriteLine("Арифметическая прогрессия: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Следующее число равно {0}", obj1.GetNext());
            }
            Console.WriteLine("\nПерезапустить");
            obj1.Reset();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Следующее число равно {0}", obj1.GetNext());
            }
            Console.WriteLine("\nНачать с числа 50");
            obj1.Reset();
            obj1.SetStart(50);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Следующее число равно {0}", obj1.GetNext());
            }
            
            GeomProgression obj2 = new GeomProgression();
            Console.WriteLine("\nГеометрическая прогрессия: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Следующее число равно {0}", obj2.GetNext());
            }
            Console.WriteLine("\nПерезапустить");
            obj2.Reset();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Следующее число равно {0}", obj2.GetNext());
            }
            Console.WriteLine("\nНачать с числа 50");
            obj2.Reset();
            obj2.SetStart(50);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Следующее число равно {0}", obj2.GetNext());
            }
            Console.ReadKey();
        }
    }
    interface ISeries
    {
        void SetStart(int x); // устанавливает начальное значение
        int GetNext();        // возвращает следующее число ряда
        void Reset();         // перезапустить; выполняет сброс к начальному значению
    }
    class ArithProgression : ISeries
    {
        int start;
        int val;
        int element;
        int difference;
        public ArithProgression()
        {
            start = 0;
            val = 0;
            element = 2;
            difference = 3;
        }
        public void SetStart(int x)
        {
            start = x;
            val = start;
        }
        public int GetNext()
        {
            if (element > 0)
            {
                val = start + difference * (element - 1);
                ++element;
                return val;
            }
            else
            {
                Console.WriteLine("Введено некорректное значение индекса");
                return val;
            }
        }
        public void Reset()
        {
            val = start;
            element = 2;
        }
    }
    class GeomProgression : ISeries
    {
        int start;
        int val;
        int element;
        double difference;
        public GeomProgression()
        {
            start = 8;
            val = 0;
            element = 1;
            difference = 0.5;
        }
        public void SetStart(int x)
        {
            try
            {
                if (x != 0)
                {
                    start = x;
                    val = start;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public int GetNext()
        {
            try
            {
                if (difference != 0)
                {
                    val = (int)(start * Math.Pow(difference, (element - 1)));
                    ++element;
                    return val;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return val;
        }
        public void Reset()
        {
            val = start;
            element = 1;
        }
    }
}
