namespace queue_main
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_enq = new System.Windows.Forms.Button();
            this.btn_deq = new System.Windows.Forms.Button();
            this.queue = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_time = new System.Windows.Forms.NumericUpDown();
            this.num_size = new System.Windows.Forms.NumericUpDown();
            this.txtbox_enq = new System.Windows.Forms.TextBox();
            this.txtbox_deq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.queue_size = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_size)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_enq
            // 
            this.btn_enq.Location = new System.Drawing.Point(343, 160);
            this.btn_enq.Name = "btn_enq";
            this.btn_enq.Size = new System.Drawing.Size(138, 30);
            this.btn_enq.TabIndex = 0;
            this.btn_enq.Text = "Enqueue";
            this.btn_enq.UseVisualStyleBackColor = true;
            this.btn_enq.Click += new System.EventHandler(this.btn_enq_Click);
            // 
            // btn_deq
            // 
            this.btn_deq.Location = new System.Drawing.Point(343, 259);
            this.btn_deq.Name = "btn_deq";
            this.btn_deq.Size = new System.Drawing.Size(138, 30);
            this.btn_deq.TabIndex = 1;
            this.btn_deq.Text = "Dequeue";
            this.btn_deq.UseVisualStyleBackColor = true;
            this.btn_deq.Click += new System.EventHandler(this.btn_deq_Click);
            // 
            // queue
            // 
            this.queue.FormattingEnabled = true;
            this.queue.ItemHeight = 16;
            this.queue.Location = new System.Drawing.Point(86, 69);
            this.queue.Name = "queue";
            this.queue.Size = new System.Drawing.Size(190, 244);
            this.queue.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Baş";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Son";
            // 
            // num_time
            // 
            this.num_time.Location = new System.Drawing.Point(431, 122);
            this.num_time.Name = "num_time";
            this.num_time.Size = new System.Drawing.Size(50, 22);
            this.num_time.TabIndex = 5;
            // 
            // num_size
            // 
            this.num_size.Location = new System.Drawing.Point(431, 308);
            this.num_size.Name = "num_size";
            this.num_size.Size = new System.Drawing.Size(50, 22);
            this.num_size.TabIndex = 6;
            this.num_size.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_size.ValueChanged += new System.EventHandler(this.num_size_ValueChanged);
            // 
            // txtbox_enq
            // 
            this.txtbox_enq.Location = new System.Drawing.Point(343, 74);
            this.txtbox_enq.Multiline = true;
            this.txtbox_enq.Name = "txtbox_enq";
            this.txtbox_enq.Size = new System.Drawing.Size(138, 30);
            this.txtbox_enq.TabIndex = 7;
            // 
            // txtbox_deq
            // 
            this.txtbox_deq.Location = new System.Drawing.Point(343, 223);
            this.txtbox_deq.Multiline = true;
            this.txtbox_deq.Name = "txtbox_deq";
            this.txtbox_deq.Size = new System.Drawing.Size(138, 30);
            this.txtbox_deq.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Queue (Banka Kuyruğu)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ad - İş süresi - Bekleme süresi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Kişi Adı (Enqueue)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "İş süresi(dk)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Max Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(340, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Kişi Adı (Baştaki)";
            // 
            // queue_size
            // 
            this.queue_size.AutoSize = true;
            this.queue_size.Location = new System.Drawing.Point(340, 354);
            this.queue_size.Name = "queue_size";
            this.queue_size.Size = new System.Drawing.Size(106, 17);
            this.queue_size.TabIndex = 16;
            this.queue_size.Text = "Queue Size = 6\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 450);
            this.Controls.Add(this.queue_size);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbox_deq);
            this.Controls.Add(this.txtbox_enq);
            this.Controls.Add(this.num_size);
            this.Controls.Add(this.num_time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queue);
            this.Controls.Add(this.btn_deq);
            this.Controls.Add(this.btn_enq);
            this.Name = "Form1";
            this.Text = "Queue ( Banka Kuyruğu)";
            ((System.ComponentModel.ISupportInitialize)(this.num_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_enq;
        private System.Windows.Forms.Button btn_deq;
        private System.Windows.Forms.ListBox queue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_time;
        private System.Windows.Forms.NumericUpDown num_size;
        private System.Windows.Forms.TextBox txtbox_enq;
        private System.Windows.Forms.TextBox txtbox_deq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label queue_size;
    }
}

