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
    public partial class Form1 : Form
    {
        private Form1Model formModel;

        public Form1()
        {
            InitializeComponent();
            formModel = new Form1Model(this);
            formModel.fillStack();            
        }

        //обработчик нажатия на кнопки
        private void button_Click(object sender, EventArgs e)
        {
            //определение какая именно кнопка нажата по тегу
            switch ((sender as Button).Tag.ToString())
            {
                case "1": //Start
                          //в начале алгоритма заполняются необходимые переменные
                    if (formModel.start)
                    {
                        //временной строке присваивается входная
                        tmpText.Text = inputText.Text ;
                        //из нее создается массив символов для более простого обращения к следующему
                        //символу или знаку
                        formModel.ex = tmpText.Text.Split(' ');
                        //очищается выходная строка от предыдущих итераций массива, если они был
                        outputText.Clear();
                        //булевая переменная меняется, чтобы в дальнейшем эта часть кода была неактивна
                        formModel.start = false;

                        formModel.stack.Clear();
                        formModel.stack.Add(" ");
                    }
                    //переменная для получение результата выполнения одной итерации алгоритма
                    int res;
                    //если пошагово
                    if (formModel.byStep)
                    {
                        //кнопка "старт" меняется на "такт"
                        buttonBegin.Text = "Такт";
                        //вызывается метод для выполнения одной итерации алгоритма
                        res = formModel.getWork();
                        //если алгоритм закончился с результатом 4
                        //значит все прошлой успешно
                        if (res == 4)
                        {
                            //это отобразит комментарий в форме
                            label6.Text = "Готово!";
                            //алгоритм готов к новой задаче
                            formModel.start = true;
                            buttonBegin.Text = "Старт";
                            break;
                        }
                        if (res == 5)
                        {
                            //если результат 5, значит в выражении есть ошибка
                            label6.Text = "Ошибка скобочной структуры!";
                            formModel.start = true;
                            buttonBegin.Text = "Старт";
                            break;
                        }
                    }
                    else
                        //автоматическое выполнение алгоритма
                        while (true)
                        {
                            //цикл закончится если результатом вернется одно из двух значений
                            res = formModel.getWork();
                            if (res == 4)
                            {
                                label6.Text = "Готово!";
                                formModel.start = true;
                                break;
                            }
                            if (res == 5)
                            {
                                label6.Text = "Ошибка скобочной структуры!";
                                break;
                            }
                        }
                    break;
                //кнопка очистить
                case "2": //clear
                    formModel.pointerStack = 0;
                    formModel.start = true;
                    buttonBegin.Text = "Старт";
                    tmpText.Clear();
                    outputText.Clear();
                    formModel.stack.Clear();
                    formModel.stack.Add(" ");
                    formModel.fillStack();
                    break;
                //кнопка вызова клавиатуры
                case "3": //keyboard
                          //создание окна
                    Form2 keyboard = new Form2();
                    //присваивание новому окну владельца
                    keyboard.Owner = this;
                    //Если в входной строке было выражение оно отправится во второе окно для редактирования
                    keyboard.textBoxInput.Text = inputText.Text;
                    //показать окно
                    keyboard.ShowDialog();
                    break;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //определяет будет ли алгоритм пошаговым
            formModel.byStep = checkBox1.Checked;
        }
        //метод при изменении размера окна
        private void Form1_Resize(object sender, EventArgs e)
        {
            //меняется только масштаб таблицы, поэтому вызываем снова метод заполнения
            //в котором размер ячейки будет узменен соответственно новому размеру таблицы
            formModel.fillStack();
        }
        private void tableStack_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
    public class Form1Model
    {
        private Form1 form;
        //таблица принятия решений
        public int[,] tableDes;
        //строка символов для нахождения индекса
        public String textOfCharacter;
        //переменная для проверки запуска
        public bool start;
        // переменная для проверка метода выполнения(пошагово)
        public bool byStep;
        //указатель для стека
        public int pointerStack;
        //стек
        public List<String> stack = new List<String>();
        public String[] ex;

        public Form1Model(Form1 f)
        {
            form = f;

            tableDes = new int[,]
            {
                {4, 1, 1, 1, 1, 1, 1, 5, 1, 6},
                {2, 2, 2, 1, 1, 1, 1, 2, 1, 6},
                {2, 2, 2, 1, 1, 1, 1, 2, 1, 6},
                {2, 2, 2, 2, 2, 1, 1, 2, 1, 6},
                {2, 2, 2, 2, 2, 1, 1, 2, 1, 6},
                {2, 2, 2, 2, 2, 2, 1, 2, 1, 6},
                {5, 1, 1, 1, 1, 1, 1, 3, 1, 6},
                {2, 2, 2, 2, 2, 2, 1, 2, 7, 6}
            };

            textOfCharacter = " +-*/^()";
            start = true;
            byStep = false;
            pointerStack = 0;
            stack.Clear();
            stack.Add(" ");
        }
        //метод вывода стека на экран
        public void fillStack()
        {
            form.tableStack.RowCount = 10;
            //очистка предыдущего состояния стека
            for (int i = 0; i < form.tableStack.RowCount; i++)
            {
                form.tableStack.Rows[i].Cells[0].Value = "";
                form.tableStack.Rows[i].Cells[1].Value = "";
            }
            //заполнение
            for (int i = 1; i < stack.Count; i++)
                form.tableStack.Rows[form.tableStack.RowCount - i].Cells[0].Value = stack[i];
            //указатель
            form.tableStack.Rows[form.tableStack.RowCount - 1 - pointerStack].Cells[1].Value = "<";
            //маштабирование строк по размеру таблицы
            for (int i = 0; i < form.tableStack.RowCount; i++)
                form.tableStack.Rows[i].Height = (form.tableStack.Height - form.tableStack.ColumnHeadersHeight) / form.tableStack.RowCount;
            //маштабирование столбцов по ширине
            form.tableStack.Columns[0].Width = form.tableStack.Width / 2;
            form.tableStack.Columns[1].Width = form.tableStack.Width / 2;
            form.tableStack.ClearSelection();
        }

        //метод выполнения одной итерации алгоритма
        public int getWork()
        {
            //получение первого символа в временной строке
            string symbol = ex[0];

            //это индекс столбца в таблице принятия решений
            int column;

            //определение идекса столбца на основе полученного выше символа
            if (symbol == "sin" || symbol == "cos" || symbol == "ctg" || symbol == "tg")
            {
                column = 8;
            }
            else
            {
                column = textOfCharacter.IndexOf(symbol);
                if (column == -1) column = 9;
            }

            //определение индекса строки на основе верхнего символа в стеке
            int row = textOfCharacter.IndexOf(stack[pointerStack]);            
            if(row == -1){
                row = 7;
            }

            //на основе двух индексов находится в таблице ячейка
            //соответствующая пересечению указанных индексов
            //результатом будет число - действие для алгоритма
            int res = tableDes[row, column];

            switch (res)
            {
                case 1: //добавить символ в стек
                    form.label6.Text = "Добавить символ в стек.";
                    stack.Insert(++pointerStack, symbol);
                    break;
                case 2: // извлечь символ из стека и отправить его в выходную строку
                    form.label6.Text = "Извлечь символ из стека и отправить его в выходную строку.";
                    form.outputText.Text += stack[pointerStack] + " ";
                    pointerStack--;
                    break;
                case 3: //удалить "(" из стека и ")" из входной строки
                    form.label6.Text = "Удалить '(' из стека и ')' из входной строки.";
                    stack.RemoveAt(pointerStack);
                    pointerStack--;
                    break;
                case 6: //переслать символ из входной строки в выходную
                    form.label6.Text = "Переслать символ из входной строки в выходную.";
                    form.outputText.Text += symbol + " ";
                    break;
            }
            //при всех действия кроме второго из временной строки удаляется первый символ
            if (res != 2)
            {
                String[] tmp = new String[ex.Length - 1];
                for (int i = 0; i < ex.Length - 1; i++)
                    tmp[i] = ex[i + 1];
                ex = tmp;                
            }

            //заполнение стека
            fillStack();
            form.tmpText.Clear();
            //и изменение временной строки
            for (int i = 0; i < ex.Length; i++)
                form.tmpText.Text += ex[i] + " ";

            return res;
        }
    }

}
