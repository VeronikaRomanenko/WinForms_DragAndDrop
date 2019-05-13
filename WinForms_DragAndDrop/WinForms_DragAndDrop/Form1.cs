using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_DragAndDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            textBox1.MouseDown += TextBox1_MouseDown;
            listBox1.DragEnter += ListBox1_DragEnter;
            listBox1.DragDrop += ListBox1_DragDrop;
        }

        private void ListBox1_DragDrop(object sender, DragEventArgs e)
        {
            //при отпускании кнопки производим копирование данных в элемент списка
            listBox1.Items.Add(e.Data.GetData(DataFormats.StringFormat).ToString());
        }

        private void ListBox1_DragEnter(object sender, DragEventArgs e)
        {
            //припопадании на адресат формируем соответствующую иконку для курсора
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //при опускании клавиши мыши выполняем буксировку содержимого источника
            textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //разрешаем списку стать адресатом буксировки
            listBox1.AllowDrop = true;
        }
    }
}
