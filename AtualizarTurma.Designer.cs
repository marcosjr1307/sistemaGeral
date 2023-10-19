
namespace aula13_banco
{
    partial class AtualizarTurma
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtModal = new System.Windows.Forms.ComboBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.Professor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaSemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdAlunos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Excluído = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Modalidade:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Professor,
            this.DiaSemana,
            this.Hora,
            this.QtdAlunos,
            this.Excluído});
            this.dataGridView1.Location = new System.Drawing.Point(89, 101);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(543, 213);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // txtModal
            // 
            this.txtModal.FormattingEnabled = true;
            this.txtModal.Location = new System.Drawing.Point(218, 51);
            this.txtModal.Name = "txtModal";
            this.txtModal.Size = new System.Drawing.Size(352, 21);
            this.txtModal.TabIndex = 23;
            this.txtModal.SelectedIndexChanged += new System.EventHandler(this.txtModal_SelectedIndexChanged);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(89, 351);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(543, 23);
            this.btnAtualizar.TabIndex = 26;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // Professor
            // 
            this.Professor.HeaderText = "Professor";
            this.Professor.Name = "Professor";
            // 
            // DiaSemana
            // 
            this.DiaSemana.HeaderText = "Dia da Semana";
            this.DiaSemana.Name = "DiaSemana";
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // QtdAlunos
            // 
            this.QtdAlunos.HeaderText = "Qtd Alunos";
            this.QtdAlunos.Name = "QtdAlunos";
            // 
            // Excluído
            // 
            this.Excluído.FalseValue = "";
            this.Excluído.HeaderText = "Excluído";
            this.Excluído.Name = "Excluído";
            this.Excluído.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Excluído.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Excluído.TrueValue = "";
            // 
            // AtualizarTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtModal);
            this.Name = "AtualizarTurma";
            this.Text = "Atualizar Turma";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox txtModal;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Professor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdAlunos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Excluído;
    }
}