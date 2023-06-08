namespace Plastinaflix
{
    partial class Orquestrador
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
            btnAdicionarFilme = new Button();
            btnControleSessoes = new Button();
            btnCriarReserva = new Button();
            SuspendLayout();
            // 
            // btnAdicionarFilme
            // 
            btnAdicionarFilme.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdicionarFilme.Location = new Point(12, 22);
            btnAdicionarFilme.Name = "btnAdicionarFilme";
            btnAdicionarFilme.Size = new Size(229, 45);
            btnAdicionarFilme.TabIndex = 0;
            btnAdicionarFilme.Text = "Adicionar Filme";
            btnAdicionarFilme.UseVisualStyleBackColor = true;
            btnAdicionarFilme.Click += btnAdicionarSessão_Click;
            // 
            // btnControleSessoes
            // 
            btnControleSessoes.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnControleSessoes.Location = new Point(12, 103);
            btnControleSessoes.Name = "btnControleSessoes";
            btnControleSessoes.Size = new Size(229, 45);
            btnControleSessoes.TabIndex = 1;
            btnControleSessoes.Text = "Controle de sessões";
            btnControleSessoes.UseVisualStyleBackColor = true;
            btnControleSessoes.Click += btnControleSessoes_Click;
            // 
            // btnCriarReserva
            // 
            btnCriarReserva.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCriarReserva.Location = new Point(12, 186);
            btnCriarReserva.Name = "btnCriarReserva";
            btnCriarReserva.Size = new Size(229, 45);
            btnCriarReserva.TabIndex = 2;
            btnCriarReserva.Text = "Criar Reserva";
            btnCriarReserva.UseVisualStyleBackColor = true;
            btnCriarReserva.Click += btnCriarReserva_Click;
            // 
            // Orquestrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 256);
            Controls.Add(btnCriarReserva);
            Controls.Add(btnControleSessoes);
            Controls.Add(btnAdicionarFilme);
            Name = "Orquestrador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Orquestrador";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdicionarFilme;
        private Button btnControleSessoes;
        private Button btnCriarReserva;
    }
}