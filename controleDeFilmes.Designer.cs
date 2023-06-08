namespace Plastinaflix
{
    partial class controleDeFilmes
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
            label2 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            textBox5 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(46, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(464, 265);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Controle de Filmes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 183);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 14;
            label2.Text = "Duração:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(32, 201);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(396, 23);
            textBox2.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 117);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 12;
            label6.Text = "Descrição:";
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
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Titulo:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(32, 68);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(396, 23);
            textBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(324, 334);
            button1.Name = "button1";
            button1.Size = new Size(150, 31);
            button1.TabIndex = 9;
            button1.Text = "Adicionar Filme";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(78, 334);
            button2.Name = "button2";
            button2.Size = new Size(138, 31);
            button2.TabIndex = 10;
            button2.Text = "Limpar Campos";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // controleDeFilmes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 390);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "controleDeFilmes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Filmes";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label6;
        private TextBox textBox5;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label2;
        private TextBox textBox2;
    }
}