using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace stack_main
{
    public partial class Form1 : Form
    {
        Stack stack;
        public Form1()
        {
            InitializeComponent();
            stack = new Stack();
            stack.Push("Data Structures");
            stack.Push("Computer Organization");
            stack.Push("Automata");
            stack.Push("Algorithms");
            stack.Push("C# How to Program");
            stack.Push("Wireless Internet");
            get_stack();
        }


        private void push_Click(object sender, EventArgs e)
        {
            string push_item;
            if (textBox1.Text != "")
            {
                push_item = textBox1.Text;
                stack.Push(push_item);
            }
            get_stack();
        }

        private void pop_Click(object sender, EventArgs e)
        {

            stack.Pop();
            get_stack();

        }
        public void get_stack()
        {
          
            int count = stack.Count;
            if (count >= Convert.ToInt32(numericUpDown1.Text) +1)
            {
                stack.Pop();
                pop.Enabled = true;
                push.Enabled = false;
                MessageBox.Show("Stack Maximum Sayıyı Geçemez", "HATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);         
            }
            else if (0 < count && count <= (Convert.ToInt32(numericUpDown1.Text)))
            {
                pop.Enabled = true;
                push.Enabled = true;
                listBox1.Items.Clear();
                foreach (var item in stack)
                {
                    listBox1.Items.Add(item.ToString());

                }
                string peek_item = stack.Peek().ToString();
                textBox1.Text = peek_item;
                textBox2.Text = peek_item;
                label7.Text = ("Stack Size = " + stack.Count.ToString());
                if(count == (Convert.ToInt32(numericUpDown1.Value)))
                    MessageBox.Show("Stack Maximum Sayıya Ulaştı", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
            else if (count == 0) {
                listBox1.Items.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                label7.Text = ("Stack Size = " + stack.Count.ToString());
                pop.Enabled = false;
                push.Enabled = true;
                MessageBox.Show("Stack Boş", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (stack.Count >= Convert.ToInt32(numericUpDown1.Value)) {
                numericUpDown1.Value = stack.Count;
                push.Enabled = false;
                MessageBox.Show("Stack Maximum Sayısı Azaltılamaz", "HATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                push.Enabled = true;
            }
        }
    }
}
