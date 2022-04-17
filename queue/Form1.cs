using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace queue_main
{
    public partial class Form1 : Form
    {
        Queue kuyruk;
        public Form1()
        {
            InitializeComponent();
            kuyruk = new Queue();
            kuyruk.Enqueue("Dilek - 5 - 0");
            kuyruk.Enqueue("Mustafa - 3 - 5 ");
            kuyruk.Enqueue("Mehmet - 8 - 8");
            kuyruk.Enqueue("Fatma - 10 -16");
            kuyruk.Enqueue("Füsun - 2 - 26");
            kuyruk.Enqueue("Fethi - 7 - 28");
            kuyruk.Enqueue("Ümit - 7 - 2");
            get_queue();
        }

        private void btn_enq_Click(object sender, EventArgs e)
        {
            string enq_item;
            string enq_ocp_time;
            //  string enq_waiting_time; // random olarak bekleme süresi üretilir. 

            Random waiting_time = new Random(); // Bekleme süresi random olarak üretiliyor ..
           
            // string waiting_time = rastgele.ToString(); // burada bir hata var veri tipini yazdırıyor..??
            if (txtbox_enq.Text != "")
            {
                enq_item = txtbox_enq.Text;
                enq_ocp_time = num_time.Value.ToString();
                kuyruk.Enqueue(enq_item +" - " + enq_ocp_time+" - " + waiting_time.Next(30));
            }
            get_queue();
        }
        public void get_queue()
        {
            int count = kuyruk.Count;
            if (count >= (Convert.ToInt32(num_size.Value)) + 1) // belki bu num_size.Value olabilir.. 
            {
                kuyruk.Dequeue();
                btn_enq.Enabled = false;
                btn_deq.Enabled = true;
                MessageBox.Show("Queue maximum sayıyı geçemez", "HATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (0 < count && count <= (Convert.ToInt32(num_size.Value)))
            {
                btn_enq.Enabled = true;
                btn_deq.Enabled = true;
                queue.Items.Clear();
                foreach (var item in kuyruk)
                {
                    queue.Items.Add(item.ToString());
                }

                string peek_item = kuyruk.Peek().ToString();
                txtbox_deq.Text = peek_item;
                queue_size.Text = ("Queue Size = " + kuyruk.Count.ToString());
                if (count == (Convert.ToInt32(num_size.Value)))
                    MessageBox.Show("Queue maximum sayıya ulaştı", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            else if (count == 0)
            {
                queue.Items.Clear();
                txtbox_enq.Text = "";
                txtbox_deq.Text = "";
                queue_size.Text = ("Queue Size = " + kuyruk.Count.ToString());
                btn_enq.Enabled = true;
                btn_deq.Enabled = false;
                MessageBox.Show("Queue Boş", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

        }

        private void btn_deq_Click(object sender, EventArgs e)
        {
            kuyruk.Dequeue();
            get_queue();
        }

        private void num_size_ValueChanged(object sender, EventArgs e)
        {
            if (kuyruk.Count >= Convert.ToInt32(num_size.Value))
            {
                num_size.Value = kuyruk.Count;
                btn_enq.Enabled = false;
                MessageBox.Show("Queue Maximum Sayısı Azaltılamaz", "HATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
               btn_enq.Enabled = true;
            }
        }
    }
}
