/// Чат-бот
/// @author Miroshin V.I.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Bot_MV
{
    public abstract class AbstractChatBot
    {
        public abstract string Answer(string question);/// Ответ на запрос
    }
}
