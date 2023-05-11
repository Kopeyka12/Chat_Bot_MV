/// Чат-бот
/// @author Miroshin V.I.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chat_Bot_MV
{
    public class MyChatBot : AbstractChatBot
    {
        private string UserName; /// Имя пользователя

        string path; /// Путь к файлу с историей сообщений

        List<string> history = new List<string>(); /// Хранение истории

        /// Регулярные выражения
        public static Regex regexHello = new Regex(@"(^(пр(и|e)в)е*т|х(а|e)*й|hi|hello*)");
        public static Regex regexThankYou = new Regex(@"(?:спасибо|благодарю)");
        public static Regex regexDate = new Regex(@"(число$|дата|дату)");
        public static Regex regexTime = new Regex(@"время$|час$|time|dhtvz");
        public static Regex regexSum = new Regex(@"(?:сложи(\s)?(\d+)(\s)?и(\s)?(\d+))");
        public static Regex regexSub = new Regex(@"(?:вычти(\s)?(\d+)(\s)?из(\s)?(\d+))");
        public static Regex regexMul = new Regex(@"(?:умножь(\s)?(\d+)(\s)?на(\s)?(\d+))");
        public static Regex regexDiv = new Regex(@"(?:раздели(\s)?(\d+)(\s)?на(\s)?(\d+))");
        public static Regex regexIP = new Regex(@"айпи");

        public void SetUserName(string name) /// Сеттер имени пользователя
        {
            UserName = name;
        }

        public string GetUserName() /// Геттер имени пользователя
        {
            return UserName;
        }

        public void Bot() /// Конструктор без параметров
        {

        }

        //public void Bot(string filename) 
        //{
        //    LoadHistory(filename);
        //}

        public string Path /// Получение адреса истории
        {
            get
            {
                return path;
            }
        }
        public List<string> History /// Получение истории
        {
            get
            {
                return history;
            }
        }

        public void LoadHistory(string user) /// Загрузка истории
        {
            UserName = user;
            path = UserName + ".txt"; // Запись пути

            try
            {
                // Попытка загрузки существующей базы
                history.AddRange(File.ReadAllLines(path, Encoding.GetEncoding(1251)));  //считывет с файла данные и сразу же закрывает

                // Если файл был изменен не сегодня, то записываеося новая дата

                if (File.GetLastWriteTime(path).ToString("dd.MM.yy") !=
                    DateTime.Now.ToString("dd.MM.yy"))
                {
                    String[] date = new String[] {"\n" + "Переписка от " +
                        DateTime.Now.ToString("dd.MM.yy"+ "\n")};
                    AddToHistory(date);
                }
            }
            catch
            {
                // если файл не существует, создаем его
                File.WriteAllLines(path, history.ToArray(), Encoding.GetEncoding(1251));    //создает файл и записывет из значение history
                // отмечаем дату начала переписки
                String[] date = new String[] {"Переписка от " +
                        DateTime.Now.ToString("dd.MM.yy") + "\n"};
                AddToHistory(date);

            }
        }

        public void AddToHistory(string[] answer) /// Добавление в историю
        {
            history.AddRange(answer);
            //открывается файл, загружается история и сразу закрывает файл
            File.WriteAllLines(path, history.ToArray(), Encoding.GetEncoding(1251));  //лучше так не делать изменить на универсальную кодировку
        }


        public string Hello() /// Приветствие
        {
            Random rand = new Random();
            string[] mas = { "Привет", "Здравствуй", "Рад приветствовать" };
            int k = rand.Next(mas.Length);
            return mas[k] + ", " + UserName + "!";
        }

        public string ThankYou() /// Благодарность
        {
            return "Был рад Вам помочь!";
        }

        public string WhatDate() /// Какая дата
        {
            return "Сегодня: " + DateTime.Now.ToString("dd.MM.yy");
        }

        public string WhatTime() /// Какое время
        {
            return "Сейчас: " + DateTime.Now.ToString("HH:mm");
        }

        public string GetIP() /// Получение IP
        {   //host — это один определенный компьютер или сервер, подключенный к конкретной сети
            //IP-адрес — это уникальный адрес одной конкретной компьютерной сети.
            //Сначала обращаемся к директиве System.Net, то есть подключаемся к сетевым протоколам
            //Пишем ".Dns" этот классом мы говорим, что хотим обратиться к определенному протоколу — протоколу IP.
            //Затем пишем GetHostName. Переводится как «Получить имя хоста», что нам и нужно
            String host = System.Net.Dns.GetHostName();/// Получение ip-адреса
            //Дело в том, что чтобы нам получить IP-адрес, нужно указать сначала его хост, что мы и делаем, указывая имя нашего хоста в скобках переменной host 
            System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
            return ip.ToString();
        }
        public string Sum(string question) /// Расчёт суммы
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('ж') + 2);
            string[] words = question.Split(new char[] { 'и' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num1 + num2).ToString();
            }
            catch
            {
                return "Я вас не понимаю. Повторите, пожалуйста, ввод :(";
            }

        }

        public string Sub(string question) /// Расчёт разности
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('т') + 2);
            string[] words = question.Split(new char[] { 'и', 'з' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num2 - num1).ToString();
            }
            catch
            {
                return "Я вас не понимаю. Повторите, пожалуйста, ввод :(";
            }
        }

        public string Mul(string question) /// Расчёт произведения
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('ь') + 1);
            string[] words = question.Split(new char[] { 'н', 'а' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num1 * num2).ToString();
            }
            catch
            {
                return "Я вас не понимаю. Повторите, пожалуйста, ввод :(";
            }

        }

        public string Div(string question) /// Расчёт частного
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('и') + 1);
            string[] words = question.Split(new char[] { 'н', 'а' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                float num1 = Convert.ToInt32(words[0]);
                float num2 = Convert.ToInt32(words[1]);
                return (num1 / num2).ToString();
            }
            catch
            {
                return "Я вас не понимаю. Повторите, пожалуйста, ввод :(";
            }

        }

        /// <summary>
        /// Ответ на запрос
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public override string Answer(string question)
        {
            question = question.ToLower(); /// Перевод в нижний регистр

            if (regexHello.IsMatch(question)) /// Поиск по регулярным выражениям
            {
                return this.Hello();
            }
            if (regexThankYou.IsMatch(question))
            {
                return this.ThankYou();
            }
            if (regexDate.IsMatch(question))
            {
                return this.WhatDate();
            }
            if (regexTime.IsMatch(question))
            {
                return this.WhatTime();
            }
            if (regexSum.IsMatch(question))
            {
                return this.Sum(question);
            }
            if (regexSub.IsMatch(question))
            {
                return this.Sub(question);
            }
            if (regexMul.IsMatch(question))
            {
                return this.Mul(question);
            }
            if (regexDiv.IsMatch(question))
            {
                return this.Div(question);
            }
            if (regexIP.IsMatch(question))
            {
                return this.GetIP();
            }

            else /// Если ни одно не подошло
            {
                return "Я вас не понимаю :(";
            }
        }

    }
}

