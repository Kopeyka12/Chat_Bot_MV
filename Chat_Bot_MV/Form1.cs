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
    public partial class Form_login : Form
    {
        public Form_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_login.Text == "") /// Если логин не введён
            {
                MessageBox.Show("Вы не ввели имя");
            }
            else
            {
                Form_main Form_main = new Form_main(); /// Создание второй формы
                Form_main.Bot.SetUserName(textBox_login.Text); /// Установка имени пользователя
                Form_main.Bot.LoadHistory(textBox_login.Text); /// Загрузка истории
                Form_main.RestoreChat(); /// Вывод истории
                Form_main.Show(); /// Показываем второе окно
                Hide(); /// Скрываем первое
            }
        }
    }
}
