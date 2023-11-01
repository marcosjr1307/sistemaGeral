
namespace aula13_banco
{
    partial class ConsultarClasse
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblClasse = new System.Windows.Forms.DataGridView();
            this.idTurma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.professor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpfAluno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblClasse)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtrar:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(310, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(257, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tblClasse
            // 
            this.tblClasse.AllowUserToAddRows = false;
            this.tblClasse.AllowUserToDeleteRows = false;
            this.tblClasse.AllowUserToOrderColumns = true;
            this.tblClasse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblClasse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTurma,
            this.professor,
            this.cpfAluno});
            this.tblClasse.Location = new System.Drawing.Point(250, 138);
            this.tblClasse.Name = "tblClasse";
            this.tblClasse.ReadOnly = true;
            this.tblClasse.Size = new System.Drawing.Size(349, 328);
            this.tblClasse.TabIndex = 4;
            // 
            // idTurma
            // 
            this.idTurma.HeaderText = "ID Turma";
            this.idTurma.Name = "idTurma";
            this.idTurma.ReadOnly = true;
            // 
            // professor
            // 
            this.professor.HeaderText = "Professor";
            this.professor.Name = "professor";
            this.professor.ReadOnly = true;
            // 
            // cpfAluno
            // 
            this.cpfAluno.HeaderText = "CPF Aluno";
            this.cpfAluno.Name = "cpfAluno";
            this.cpfAluno.ReadOnly = true;
            // 
            // ConsultarClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.tblClasse);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "ConsultarClasse";
            this.Text = "ConsultarClasse";
            this.Load += new System.EventHandler(this.ConsultarClasse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblClasse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView tblClasse;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTurma;
        private System.Windows.Forms.DataGridViewTextBoxColumn professor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpfAluno;
    }
}