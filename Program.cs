using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_06
{
    class Program
    {
        /// <summary>
        /// Метод для получения количества групп чисел
        /// </summary>
        /// <param name="amountOfNumbers">количество чисел в группе</param>
        static void GetNumbersOfGroups(int amountOfNumbers)
        {
            int M;
            M = (int)Math.Log(amountOfNumbers, 2) + 1;
            Console.WriteLine($"\nКоличество групп чисел: {M}");
        }
        /// <summary>
        /// Метод для разбивки чисел на группы не делящихся друг для друга чисел, и записи этих групп в файл
        /// </summary>
        /// <param name="amountOfNumbers">количество чисел в группе</param>
        static void GetGroups(int amountOfNumbers)
        {
            #region старое
            //string tempString = ""; //врЕменная строка, нужна для дальнейшей записи
            //int tempNumber = 2;     //временное число, необходимое для дальнейших расчётов, т.к. каждая группа начинается со степени двойки

            ////File.AppendAllText(@"d:\OneDrive\GitHub\Skillbox-Homework-Module6\groups.txt", "1");
            //Console.WriteLine("1"); //вывод единицы

            //while (tempNumber * 2 < amountOfNumbers)                //пока степень двойки меньше исходного числа
            //{
            //    for (int i = tempNumber; i < tempNumber * 2; i++)   //добавляем числа в строку, начиная с одной степени двойки до следующей
            //    {
            //        tempString += $"{i} ";
            //    }
            //    //File.AppendAllText(@"d:\OneDrive\GitHub\Skillbox-Homework-Module6\groups.txt", $"\n{tempString}");
            //    Console.WriteLine(tempString);                      //вывод строки с группой чисел                            
            //    tempString = "";                                    //и обнуление строки
            //    tempNumber *= 2;                                    //вычисляем следующую степень двойки
            //}

            ////tempNumber /= 2;   //в предыдущем цикле записывались в строки только числа до последней степени двойки. Чтобы вывести числа 
            //                   //от последней степени двойки до последнего числа в ряду, возвращаем tempNumber к предыдущему значению

            //for (int i = tempNumber; i <= amountOfNumbers; i++)     //выводим оставшиеся в ряду числа
            //{
            //    tempString += $"{i} ";
            //}

            ////File.AppendAllText(@"d:\OneDrive\GitHub\Skillbox-Homework-Module6\groups.txt", $"\n{tempString}");
            //Console.WriteLine(tempString);
            //string textGroups;   //задаём переменную для дальнейшей записи строки
            //File.AppendAllText(@"d:\OneDrive\GitHub\Skillbox-Homework-Module6\groups.txt", textGroups); //создание файла/добавление строки в него


            //int count = 0;
            //Console.Write("1");
            //for (int i = 2; i <= amountOfNumbers; i++)
            //{
            //    if (i % 2 == 0 && Math.Log(i, 2) % 1 == 0)
            //    {
            //        if (Math.Log(i, 2) % 1 == 0)
            //        {
            //            Console.WriteLine("\n");
            //            Console.Write(i + " ");
            //            //File.AppendAllText(@"d:\OneDrive\GitHub\Skillbox-Homework-Module6\groups.txt", i + " ");
            //        }
            //        else
            //        {
            //            Console.Write(i + " ");
            //            //File.AppendAllText(@"d:\OneDrive\GitHub\Skillbox-Homework-Module6\groups.txt", i + " ");
            //        }
            //        //count += 1;
            //    }

            //    else
            //    {
            //        //Console.Write(i + " ");
            //        //File.AppendAllText(@"d:\OneDrive\GitHub\Skillbox-Homework-Module6\groups.txt", i + " ");
            //        //count += 1;
            //    }
            //}
            #endregion

            File.Delete("groups.csv");   //удаление файла с предыдущими данными

            do
            {
                int group = amountOfNumbers / 2 + 1;   //условие для нахождения самого большого делителя заданного числа

                using (StreamWriter groups = new StreamWriter("groups.csv", true, Encoding.Unicode))   //запись в файл
                {
                    for (int i = amountOfNumbers; i >= group; i--)   //запись группы
                    {
                        groups.Write(i + " ");
                    }
                    groups.WriteLine();   //разделитель для перехода к следующей группе
                }

                amountOfNumbers = group - 1;   //условие для нахождения первого числа следующей группы

            } while (amountOfNumbers != 0);
        }
             
        static void Main()
        {

            /// Домашнее задание
            ///
            /// Группа начинающих программистов решила поучаствовать в хакатоне с целью демонстрации
            /// своих навыков. 
            /// 
            /// Немного подумав они вспомнили, что не так давно на занятиях по математике
            /// они проходили тему "свойства делимости целых чисел". На этом занятии преподаватель показывал
            /// пример с использованием фактов делимости. 
            /// Пример заключался в следующем: 
            /// Написав на доске все числа от 1 до N, N = 50, преподаватель разделил числа на несколько групп
            /// так, что если одно число делится на другое, то эти числа попадают в разные руппы. 
            /// В результате этого разбиения получилось M групп, для N = 50, M = 6
            /// 
            /// N = 50
            /// Группы получились такими: 
            /// 
            /// Группа 1: 1
            /// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
            /// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
            /// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
            /// Группа 5: 16 24 36 40
            /// Группа 6: 32 48
            /// 
            /// M = 6
            /// 
            /// ===========
            /// 
            /// N = 10
            /// Группы получились такими: 
            /// 
            /// Группа 1: 1
            /// Группа 2: 2 7 9
            /// Группа 3: 3 4 10
            /// Группа 4: 5 6 8
            /// 
            /// M = 4
            /// 
            /// Участники хакатона решили эту задачу, добавив в неё следующие возможности:
            /// 1. Программа считыват из файла (путь к которому можно указать) некоторое N, 
            ///    для которого нужно подсчитать количество групп
            ///    Программа работает с числами N не превосходящими 1 000 000 000
            ///   
            /// 2. В ней есть два режима работы:
            ///   2.1. Первый - в консоли показывается только количество групп, т е значение M
            ///   2.2. Второй - программа получает заполненные группы и записывает их в файл используя один из
            ///                 вариантов работы с файлами
            ///            
            /// 3. После выполения пунктов 2.1 или 2.2 в консоли отображается время, за которое был выдан результат 
            ///    в секундах и миллисекундах
            /// 
            /// 4. После выполнения пунта 2.2 программа предлагает заархивировать данные и если пользователь соглашается -
            /// делает это.
            /// 
            /// Попробуйте составить конкуренцию начинающим программистам и решить предложенную задачу
            /// (добавление новых возможностей не возбраняется)
            ///
            /// * При выполнении текущего задания, необходимо документировать код 
            ///   Как пометками, так и xml документацией
            ///   В обязательном порядке создать несколько собственных методов

            Console.Clear();

            string amountOfNumbersIn;
            int amountOfNumbers;
            //проверка на существование файла
            do
            {
                string curFile = "amount of numbers.txt";
                if (File.Exists(curFile))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Файл не обнаружен. Создайте файл 'amount of numbers.txt' в папке приложения.\nДля продолжения нажмите любую кнопку");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (true);

            // проверка на тип данных, размер числа, диапазон от 1 до 1 000 000 000
            do   
            {
                string fromFile = File.ReadAllText("amount of numbers.txt");
                int numFromFile;
                bool isNum = int.TryParse(fromFile, out numFromFile);       //проверка на тип данных

                if (isNum & numFromFile <= 1000000000 & numFromFile >= 1)   //проверка на размер числа, диапазон от 1 до 1 000 000 000
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Файл содержит данные неподходящего типа или отсутствует число. \nВведите целое число от 1 до 1 000 000 000, сохраните файл \nи нажмите любую кнопку для повторного считывания");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (true);

            

            amountOfNumbersIn = File.ReadAllText("amount of numbers.txt");      //считывание количества чисел из файла
            amountOfNumbers = Convert.ToInt32(amountOfNumbersIn);               //преобразование в int  

            Console.WriteLine($"В файле обнаружен ряд чисел от 1 до {amountOfNumbers}.\n\nВыберите действие:");
            Console.WriteLine($"\nОтобразить в консоли только количество групп - нажмите 1\nЗаписать группы в файл - нажмите 2\nВыполнить оба действия - нажмите 3");

            string choise = Console.ReadLine(); //выбор действия

            do
            {
                if (choise == "1")
                {
                    DateTime date = DateTime.Now;                  //засекаем время начала выполнения процедуры
                    GetNumbersOfGroups(amountOfNumbers);
                    TimeSpan span = DateTime.Now.Subtract(date);   // вычитаем из текущего времени время начала процедуры

                    Console.WriteLine($"\nПосчитано за {span.TotalMilliseconds} мс ({span.TotalSeconds} сек или {span.TotalMinutes} мин)");
                    
                    Console.WriteLine($"\n\nЕсли хотите выполнить другое действие, нажмите 'д'. Чтобы выйти, нажмите любую клавишу");

                    string repeat = Console.ReadLine();
                    if (repeat == "д")
                    {
                        Main();
                    }
                    else
                    {
                        break;
                    }
                    break;
                }   //вывод количества групп
                else
                if (choise == "2")   
                {
                    DateTime date = DateTime.Now;                  //засекаем время начала выполнения процедуры
                    GetGroups(amountOfNumbers);
                    TimeSpan span = DateTime.Now.Subtract(date);   // вычитаем из текущего времени время начала процедуры

                    Console.WriteLine($"\nЗапись в файл 'groups.csv' произведена.\nПосчитано за {span.TotalMilliseconds} мс ({span.TotalSeconds} сек или {span.TotalMinutes} мин)");
                    Console.WriteLine($"\nЕсли хотите заархивировать файл, нажмите 'д'. Если нет, нажмите любую клавишу");

                    string archiveChoise = Console.ReadLine();

                    if (archiveChoise == "д")   //архивирование
                    {
                        string source = "groups.csv";
                        string compressed = "groups.zip";
                        using (FileStream fs = new FileStream(source, FileMode.Open))
                        {
                            using (FileStream fsw = File.Create(compressed))                             //поток для записи
                            {
                                using (GZipStream fsc = new GZipStream(fsw, CompressionMode.Compress))   //поток для архивации
                                {
                                    fs.CopyTo(fsc);                                                      //копирование из первого потока в поток для архивации   
                                    Console.WriteLine("\nФайл {0} заархивирован.\n\nИсходный объём: {1} байт.\nОбъём архива: {2} байт.",
                                                        source,
                                                        fs.Length,
                                                        fsw.Length);
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n\nЕсли хотите выполнить другое действие, нажмите 'д'. Чтобы выйти, нажмите любую клавишу");

                        string repeat = Console.ReadLine();
                        if (repeat == "д")
                        {
                            Main();
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine($"\n\nЕсли хотите выполнить другое действие, нажмите 'д'. Чтобы выйти, нажмите любую клавишу");

                    string repeat1 = Console.ReadLine();
                    if (repeat1 == "д")
                    {
                        Main();
                    }
                    else
                    {
                        break;
                    }
                    break;
                }   
                else
                if (choise == "3")
                {
                    DateTime date = DateTime.Now;                  //засекаем время начала выполнения процедуры
                    GetNumbersOfGroups(amountOfNumbers);
                    TimeSpan span = DateTime.Now.Subtract(date);   // вычитаем из текущего времени время начала процедуры
                        
                    Console.WriteLine($"\nПосчитано за {span.TotalMilliseconds} мс ({span.TotalSeconds} сек или {span.TotalMinutes} мин)");

                    DateTime date1 = DateTime.Now;                  //засекаем время начала выполнения процедуры
                    GetGroups(amountOfNumbers);
                    TimeSpan span1 = DateTime.Now.Subtract(date1);   // вычитаем из текущего времени время начала процедуры

                    Console.WriteLine($"\nЗапись в файл 'groups.csv' произведена.\nПосчитано за {span.TotalMilliseconds} мс ({span.TotalSeconds} сек или {span.TotalMinutes} мин)");
                    Console.WriteLine($"\nЕсли хотите заархивировать файл, нажмите 'д'. Если нет, нажмите любую клавишу");

                    string archiveChoise = Console.ReadLine();

                    if (archiveChoise == "д")    
                    {
                        string source = "groups.csv";
                        string compressed = "groups.zip";
                        using (FileStream fs = new FileStream(source, FileMode.Open))
                        {
                            using (FileStream fsw = File.Create(compressed))                           //поток для записи
                            {
                                using (GZipStream fsc = new GZipStream(fsw, CompressionMode.Compress))   //поток для архивации
                                {
                                    fs.CopyTo(fsc);                                                      //копирование из первого потока в поток для архивации   
                                    Console.WriteLine("\nФайл {0} заархивирован.\n\nИсходный объём: {1} байт.\nОбъём архива: {2} байт.",
                                                        source,
                                                        fs.Length,
                                                        fsw.Length);
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n\nЕсли хотите выполнить другое действие, нажмите 'д'. Чтобы выйти, нажмите любую клавишу");

                        string repeat = Console.ReadLine();
                        if (repeat == "д")
                        {
                            Main();
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine($"\n\nЕсли хотите выполнить другое действие, нажмите 'д'. Чтобы выйти, нажмите любую клавишу");

                    string repeat1 = Console.ReadLine();
                    if (repeat1 == "д")
                    {
                        Main();
                    }
                    else
                    {
                        break;
                    }
                    break;
                }   //вывод количества и запись групп. архивация
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Неправильный ввод.\nВыберите действие");
                    Console.WriteLine($"Отобразить в консоли только количество групп - нажмите 1\nЗаписать группы в файл - нажмите 2\nВыполнить оба действия - нажмите 3");
                    choise = Console.ReadLine();
                }
            } while (true);
        }
    }
}
