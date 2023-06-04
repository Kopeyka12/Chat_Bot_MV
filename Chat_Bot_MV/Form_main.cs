/// Чат-бот
/// @author Miroshin V.I.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Bot_MV
{
    public partial class Form_main : Form
    {
        public MyChatBot Bot = new MyChatBot(); /// Создание объекта класса MyChatBot
    
        public Form_main()
        {
            InitializeComponent();
            textBox_report.ReadOnly = true;
            textBox_report.Select();/// Фокус на поле ввода запроса
        }

        public void RestoreChat()/// Восстановление истории
        {
            for (int i = 0; i < Bot.History.Count; i++)
            {
                textBox_report.Text += Bot.History[i] + Environment.NewLine;
            }
        }


       /* private void Form_main_KeyDown(object sender, KeyEventArgs e) /// Регистрация нажатия Enter
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                button_enter_Click_1(button_enter, null);
            }
        }*/

        /// Если вторая форма закрыта
        private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_enter_Click_1(object sender, EventArgs e)
        {
            if (textBox_request.Text != "")
            {
                /// Убираем лишние пробелы: "Умножь 3 на ____2"
                String[] userQuestion = textBox_request.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                string message = userQuestion[0]; /// Сообщение для отправки боту

                /// Добавление времени для вывода в чат
                userQuestion[0] = userQuestion[0].Insert(0, "[" + DateTime.Now.ToString("HH:mm") + "] " + Bot.GetUserName() + ": ");

                /// Сохранение в историю
                Bot.AddToHistory(userQuestion);

                /// Вывод в textBox
                textBox_report.AppendText(userQuestion[0] + "\r\n");
                /// Очистка поля ввода
                textBox_request.Text = "";
                /// Получение ответа Бота
                string[] botAnswer = new string[] { Bot.Answer(message) };
                /// Добавление к нему времени
                botAnswer[0] = botAnswer[0].Insert(0, "[" + DateTime.Now.ToString("HH:mm") + "] Бот: ");
                /// Вывод в textBox
                textBox_report.AppendText(botAnswer[0] + Environment.NewLine);
                /// Сохранение в историю
                Bot.AddToHistory(botAnswer);
            }
        }
        
        


        /// Очистка истории
        private void button_clear_Click_1(object sender, EventArgs e)
        {
            /// Вывод MessageBox для подтверждения удаления истории
            DialogResult dialogResult = MessageBox.Show("Уверены," + "что хотите очистить диалог?", "Подтверждение", MessageBoxButtons.YesNo);

            /// Если удаление подтверждено
            if (dialogResult == DialogResult.Yes)
            {
                ///File.WriteAllText(Bot.Path, string.Empty);

                /// Удаление истории
                Bot.History.Clear();

                /// Добавление шапки в историю
                String[] date = new String[] {"Переписка от " +
                        DateTime.Now.ToString("dd.MM.yy"+ "\n")};
                Bot.AddToHistory(date);

                /// Добавление шапки в textBox
                textBox_report.Text = date[0] + "\r\n\r\n";
            }
        }
        /// Для автоматического скроллинга
        private void textBox_report_TextChanged_1(object sender, EventArgs e)
        {
            textBox_report.SelectionStart = textBox_report.Text.Length;
            textBox_report.ScrollToCaret();
            textBox_report.Refresh();
        }

        private void Form_main_KeyDown_1(object sender, KeyEventArgs e)/// Регистрация нажатия Enter
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                button_enter_Click_1(button_enter, null);
            }
        }
    }
}
