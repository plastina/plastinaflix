namespace Plastinaflix
{
    partial class controleDeSessoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label3 = new Label();
            hourPicker = new DateTimePicker();
            dateTimePicker = new DateTimePicker();
            label2 = new Label();
            label6 = new Label();
            textBox5 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(hourPicker);
            groupBox1.Controls.Add(dateTimePicker);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(47, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(464, 333);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Controle de Sessões";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 248);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 19;
            label3.Text = "Data:";
            // 
            // hourPicker
            // 
            hourPicker.Format = DateTimePickerFormat.Time;
            hourPicker.ImeMode = ImeMode.NoControl;
            hourPicker.Location = new Point(32, 202);
            hourPicker.Name = "hourPicker";
            hourPicker.ShowUpDown = true;
            hourPicker.Size = new Size(71, 23);
            hourPicker.TabIndex = 18;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(32, 266);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(263, 23);
            dateTimePicker.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 184);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 15;
            label2.Text = "Horário:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 117);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 12;
            label6.Text = "Sala:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(32, 135);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(396, 23);
            textBox5.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 50);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Titulo do Filme:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(32, 68);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(396, 23);
            textBox1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(79, 397);
            button2.Name = "button2";
            button2.Size = new Size(138, 31);
            button2.TabIndex = 7;
            button2.Text = "Limpar Campos";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(325, 397);
            button1.Name = "button1";
            button1.Size = new Size(150, 31);
            button1.TabIndex = 6;
            button1.Text = "Criar Sessão";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // controleDeSessoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 452);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "controleDeSessoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sessões";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private Label label6;
        private TextBox textBox5;
        private Label label2;
        private Label label3;
        private DateTimePicker hourPicker;
        private DateTimePicker dateTimePicker;
    }
}