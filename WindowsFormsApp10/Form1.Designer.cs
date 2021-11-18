
namespace WindowsFormsApp10
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Ports = new System.Windows.Forms.ComboBox();
            this.comboBox_Rate = new System.Windows.Forms.ComboBox();
            this.comboBox_Dbits = new System.Windows.Forms.ComboBox();
            this.comboBox_Sbits = new System.Windows.Forms.ComboBox();
            this.comboBox_Pbits = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOPen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonSend = new System.Windows.Forms.Button();
            this.tb_DataOut = new System.Windows.Forms.RichTextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_Pbits);
            this.groupBox1.Controls.Add(this.comboBox_Sbits);
            this.groupBox1.Controls.Add(this.comboBox_Dbits);
            this.groupBox1.Controls.Add(this.comboBox_Rate);
            this.groupBox1.Controls.Add(this.comboBox_Ports);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 260);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ComPort Contol";
            // 
            // comboBox_Ports
            // 
            this.comboBox_Ports.FormattingEnabled = true;
            this.comboBox_Ports.Location = new System.Drawing.Point(110, 28);
            this.comboBox_Ports.Name = "comboBox_Ports";
            this.comboBox_Ports.Size = new System.Drawing.Size(155, 24);
            this.comboBox_Ports.TabIndex = 0;
            // 
            // comboBox_Rate
            // 
            this.comboBox_Rate.FormattingEnabled = true;
            this.comboBox_Rate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600"});
            this.comboBox_Rate.Location = new System.Drawing.Point(110, 70);
            this.comboBox_Rate.Name = "comboBox_Rate";
            this.comboBox_Rate.Size = new System.Drawing.Size(155, 24);
            this.comboBox_Rate.TabIndex = 1;
            this.comboBox_Rate.Text = "9600";
            // 
            // comboBox_Dbits
            // 
            this.comboBox_Dbits.FormattingEnabled = true;
            this.comboBox_Dbits.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.comboBox_Dbits.Location = new System.Drawing.Point(110, 114);
            this.comboBox_Dbits.Name = "comboBox_Dbits";
            this.comboBox_Dbits.Size = new System.Drawing.Size(155, 24);
            this.comboBox_Dbits.TabIndex = 2;
            this.comboBox_Dbits.Text = "8";
            // 
            // comboBox_Sbits
            // 
            this.comboBox_Sbits.FormattingEnabled = true;
            this.comboBox_Sbits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.comboBox_Sbits.Location = new System.Drawing.Point(110, 157);
            this.comboBox_Sbits.Name = "comboBox_Sbits";
            this.comboBox_Sbits.Size = new System.Drawing.Size(155, 24);
            this.comboBox_Sbits.TabIndex = 3;
            this.comboBox_Sbits.Text = "One";
            // 
            // comboBox_Pbits
            // 
            this.comboBox_Pbits.FormattingEnabled = true;
            this.comboBox_Pbits.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.comboBox_Pbits.Location = new System.Drawing.Point(110, 200);
            this.comboBox_Pbits.Name = "comboBox_Pbits";
            this.comboBox_Pbits.Size = new System.Drawing.Size(155, 24);
            this.comboBox_Pbits.TabIndex = 4;
            this.comboBox_Pbits.Text = "None";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "COM PORT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "BAUD RATE";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "DATA BITS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "STOP BITS";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "PARITY BITS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.buttonClose);
            this.groupBox2.Controls.Add(this.buttonOPen);
            this.groupBox2.Location = new System.Drawing.Point(12, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 97);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // buttonOPen
            // 
            this.buttonOPen.Location = new System.Drawing.Point(16, 21);
            this.buttonOPen.Name = "buttonOPen";
            this.buttonOPen.Size = new System.Drawing.Size(77, 32);
            this.buttonOPen.TabIndex = 0;
            this.buttonOPen.Text = "OPEN";
            this.buttonOPen.UseVisualStyleBackColor = true;
            this.buttonOPen.Click += new System.EventHandler(this.buttonOPen_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(110, 21);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(78, 32);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 59);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(172, 29);
            this.progressBar1.TabIndex = 2;
            // 
            // buttonSend
            // 
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSend.Location = new System.Drawing.Point(220, 289);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(77, 77);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send Data";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // tb_DataOut
            // 
            this.tb_DataOut.Location = new System.Drawing.Point(310, 21);
            this.tb_DataOut.Name = "tb_DataOut";
            this.tb_DataOut.Size = new System.Drawing.Size(470, 354);
            this.tb_DataOut.TabIndex = 3;
            this.tb_DataOut.Text = "";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 385);
            this.Controls.Add(this.tb_DataOut);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Pbits;
        private System.Windows.Forms.ComboBox comboBox_Sbits;
        private System.Windows.Forms.ComboBox comboBox_Dbits;
        private System.Windows.Forms.ComboBox comboBox_Rate;
        private System.Windows.Forms.ComboBox comboBox_Ports;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOPen;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.RichTextBox tb_DataOut;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

