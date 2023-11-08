
namespace aula13_banco
{
    partial class ExcluirClasse
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
            this.tblTurma = new System.Windows.Forms.DataGridView();
            this.idTurma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.professor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblAlunoClasse = new System.Windows.Forms.DataGridView();
            this.cpfAluno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblTurma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAlunoClasse)).BeginInit();
            this.SuspendLayout();
            // 
            // tblTurma
            // 
            this.tblTurma.AllowUserToAddRows = false;
            this.tblTurma.AllowUserToDeleteRows = false;
            this.tblTurma.AllowUserToOrderColumns = true;
            this.tblTurma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTurma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTurma,
            this.professor});
            this.tblTurma.Location = new System.Drawing.Point(41, 28);
            this.tblTurma.MultiSelect = false;
            this.tblTurma.Name = "tblTurma";
            this.tblTurma.ReadOnly = true;
            this.tblTurma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblTurma.Size = new System.Drawing.Size(245, 328);
            this.tblTurma.TabIndex = 5;
            this.tblTurma.SelectionChanged += new System.EventHandler(this.tblTurma_SelectionChanged);
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
            // tblAlunoClasse
            // 
            this.tblAlunoClasse.AllowUserToAddRows = false;
            this.tblAlunoClasse.AllowUserToDeleteRows = false;
            this.tblAlunoClasse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAlunoClasse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cpfAluno});
            this.tblAlunoClasse.Location = new System.Drawing.Point(386, 28);
            this.tblAlunoClasse.MultiSelect = false;
            this.tblAlunoClasse.Name = "tblAlunoClasse";
            this.tblAlunoClasse.ReadOnly = true;
            this.tblAlunoClasse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblAlunoClasse.Size = new System.Drawing.Size(146, 328);
            this.tblAlunoClasse.TabIndex = 6;
            // 
            // cpfAluno
            // 
            this.cpfAluno.HeaderText = "CPF Aluno";
            this.cpfAluno.Name = "cpfAluno";
            this.cpfAluno.ReadOnly = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(586, 333);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 7;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // ExcluirClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 534);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.tblAlunoClasse);
            this.Controls.Add(this.tblTurma);
            this.Name = "ExcluirClasse";
            this.Text = "ExcluirClasse";
            ((System.ComponentModel.ISupportInitialize)(this.tblTurma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAlunoClasse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblTurma;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTurma;
        private System.Windows.Forms.DataGridViewTextBoxColumn professor;
        private System.Windows.Forms.DataGridView tblAlunoClasse;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpfAluno;
        private System.Windows.Forms.Button btnExcluir;
    }
}