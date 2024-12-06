using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR1_Model
{
    public partial class Form2 : Form
    {
        private KeyboardModel keyboardModel;
        public Form2()
        {
            InitializeComponent();
            //labelMistake.ForeColor = Color.Red;
            keyboardModel = new KeyboardModel(this);
        }

        //обработчик нажатия на кнопки
        private void button_Click(object sender, EventArgs e)
        {
            //получение универсального тега кнопки
            //String b = (sender as Button).Tag.ToString();
            String b = ((Button)sender).Text;
            switch (b)
            {
                //если кнопка энтер
                case "Применить":
                    //задаем родителя окна первую форму
                    Form1 form1 = this.Owner as Form1;
                    if (form1 != null)
                    {
                        //проверяем входное выражение на ошибки
                        if (keyboardModel.finalCheck())
                        {
                            //если все хорошо, то отправляем выражение на первую форму
                            form1.inputText.Text = textBoxInput.Text;
                            //и закрываем окно
                            this.Close();
                        }
                    }
                    break;

                //кнопка очистить
                case "Очистить":
                    textBoxInput.Text = "";
                    break;

                case "Удалить символ":
                    //удалить, только если есть что удалять
                    if (textBoxInput.Text.Length > 0)
                    {
                        //int position = 1;
                        //если последнее введенное выражение функция
                        if (textBoxInput.Text.Length > 3)
                        {
                            if (textBoxInput.Text.LastIndexOf("sin") == textBoxInput.Text.Length - 4 ||
                                textBoxInput.Text.LastIndexOf("cos") == textBoxInput.Text.Length - 4 ||
                                textBoxInput.Text.LastIndexOf("ctg") == textBoxInput.Text.Length - 4)
                            {
                                textBoxInput.Text = textBoxInput.Text.Remove(textBoxInput.Text.Length - 4);
                                return;
                            }
                        }
                        if ((textBoxInput.Text.LastIndexOf("tg") == textBoxInput.Text.Length - 3) && (textBoxInput.Text.Length == -1))
                        {
                            textBoxInput.Text = textBoxInput.Text.Remove(textBoxInput.Text.Length - 3);
                            return;
                        }

                        //если просто символ
                        textBoxInput.Text = textBoxInput.Text.Remove(textBoxInput.Text.Length - 2);
                    }
                    break;

                //для всех остальных кнопок
                default:
                    //Проверка введенного символа
                    if (keyboardModel.checkForError(b))
                    {
                        //если ошибок нет, то просто добавить символ
                        textBoxInput.Text += b + " ";
                    }
                    break;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
        }
    }


    public class KeyboardModel
    {
        private Form2 form;
        public KeyboardModel(Form2 f)
        {
            form = f;
        }
        //финальная проверка выражения
        public bool finalCheck()
        {
            //поверхностная проверка скобочной структуры
            int numOfBracket = 0;
            //подсчет открывающих и закрывающих скобок
            for (int i = 0; i < form.textBoxInput.Text.Length; i++)
            {
                if (form.textBoxInput.Text.Substring(i, 1).Equals("(")) numOfBracket++;
                if (form.textBoxInput.Text.Substring(i, 1).Equals(")")) numOfBracket--;
            }
            //если их число не равно, то ошибка
            if (numOfBracket != 0)
            {
                form.labelMistake.Text = "Ошибка скобочной структуры!";
                return false;
            }
            //если последний символ - знак операции
            if ("+-*/^(".IndexOf(form.textBoxInput.Text.Substring(form.textBoxInput.Text.Length - 2, 1)) != -1)
            {
                form.labelMistake.Text = "Некорректное выражение!";
                return false;
            }
            return true;
        }






        //промежуточная проверка которая вызывается при каждом добавлении нового знака
        //в параметрах новый вводимый символ
        public bool checkForError(String str)
        {
            //если строка пустая, то проверка не нужна
            if (form.textBoxInput.Text.Length == 0) return true;
            //получение последнего введенного знака
            String last = form.textBoxInput.Text.Substring(form.textBoxInput.Text.Length - 2, 1);
            String act = "+-*/^"; //строка знаков
            String var = "abcdxyzt"; //строка символов
            String func = "sin (cos (tg (ctg ("; //строка функций
                                                 //если новый символ знак операции
            if (act.IndexOf(str) != -1)
            {
                //и предыдущий символ тоже знак операции
                if (act.IndexOf(last) != -1)
                {
                    form.labelMistake.Text = "Нельзя вводить два знака действия подряд!";
                    return false;
                }
                //или если знак действия стоит после открывающей скобки 
                if (last.Equals("("))
                {
                    form.labelMistake.Text = "Нельзя вводить знак действия после скобки!";
                    return false;
                }
            }
            //если предыдущий символ и введенный - переменные
            if (var.IndexOf(last) != -1 && var.IndexOf(str) != -1)
            {
                form.labelMistake.Text = "Нельзя вводить две переменные подряд!";
                return false;
            }
            //если между переменной и открывающейся скобки нет знака операции
            if (var.IndexOf(last) != -1 && str.Equals("("))
            {
                form.labelMistake.Text = "Отсутствует знак действия перед скобкой!";
                return false;
            }
            //если между переменной или закрывающейся скобки и функцией нет знака операции
            if (var.IndexOf(last) != -1 && func.IndexOf(str) != -1 || last.Equals(")") && func.IndexOf(str) != -1)
            {
                form.labelMistake.Text = "Отсутствует знак действия перед функцией!";
                return false;
            }
            //если после знака операции введен символ закрывающейся скобки
            if (act.IndexOf(last) != -1 && str.Equals(")"))
            {

                form.labelMistake.Text = "Нельзя вводить закрывающую скобку после знака действия!";
                return false;

            }
            //иначе никакого комментария об ошибке
            form.labelMistake.Text = "";
            //ошибок не найдено
            return true;
        }
    }

}
