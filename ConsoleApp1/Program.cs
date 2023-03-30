using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main()
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0,
                bigDelta, smallDelta;

            string equation = Console.ReadLine(),
                   chartType = "я хз";

            if (equation.Contains("x") && equation.Contains("y"))
            {
                string[] splitEquation = equation.Split('+'),
                     template = { "x^2", "xy", "y^2", "x", "y", "=0" };

                for (int i = 0; i < splitEquation.Length; i++)
                {
                    foreach (var item in template)
                    {
                        if (splitEquation[i].Contains(item))
                        {
                            switch (item)
                            {
                                case "x^2":
                                    if (splitEquation[i][0] == 'x')
                                        a = 1;
                                    else
                                        a = (int)Char.GetNumericValue(splitEquation[i][0]);
                                    break;

                                case "xy":
                                    if (splitEquation[i][0] == 'x')
                                        b = 1;
                                    else
                                        b = (int)Char.GetNumericValue(splitEquation[i][0]);
                                    break;

                                case "y^2":
                                    if (splitEquation[i][0] == 'y')
                                        c = 1;
                                    else
                                        c = (int)Char.GetNumericValue(splitEquation[i][0]);
                                    break;

                                case "x":
                                    if (splitEquation[i][0] == 'x')
                                        d = 1;
                                    else
                                        d = (int)Char.GetNumericValue(splitEquation[i][0]);
                                    break;

                                case "y":
                                    if (splitEquation[i][0] == 'y')
                                        e = 1;
                                    else
                                        e = (int)Char.GetNumericValue(splitEquation[i][0]);
                                    break;

                                case "=":
                                    if (char.IsLetter(splitEquation[i][0]))
                                        f = 0;
                                    else
                                        f = (int)Char.GetNumericValue(splitEquation[i][0]);
                                    break;

                                default:
                                    Console.WriteLine("Вы ввели bread");
                                    break;
                            }
                            break;
                        }
                    }
                }

                //Маленький определитель
                smallDelta = a * c - b * b;
                Console.WriteLine("Малый определитель - " + smallDelta);
                //Большой определитель
                bigDelta = a * c * f + b * e * d + b * e * d - d * c * d - b * b * f - e * e * a;
                Console.WriteLine("Большой определитель - " + bigDelta);

                if (smallDelta > 0 && bigDelta != 0)
                    chartType = "эллипс";
                if (smallDelta == 0 && bigDelta != 0)
                    chartType = "парабола";
                if (smallDelta < 0 && bigDelta != 0)
                    chartType = "гипербола";

                if (smallDelta > 0 && bigDelta == 0)
                    chartType = "пересекающиеся мнимые прямые";
                if (smallDelta == 0 && bigDelta == 0)
                    chartType = "две параллельные прямые";
                if (smallDelta < 0 && bigDelta == 0)
                    chartType = "пересекающиеся действительные прямые";

                Console.WriteLine("Функция " + equation + " имеет график вида " + chartType);
                Console.ReadKey();
            }
            else
                Console.WriteLine("Ожидалось уравнение второго порядка!");            
        }
    }
}