
namespace aula13_banco
{
    partial class CadastrarTurma
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQtdMaxAlunos = new System.Windows.Forms.TextBox();
            this.lblQtdMax = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtDSemana = new System.Windows.Forms.TextBox();
            this.txtProf = new System.Windows.Forms.TextBox();
            this.txtModal = new System.Windows.Forms.TextBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblDSemana = new System.Windows.Forms.Label();
            this.lblProf = new System.Windows.Forms.Label();
            this.lblModal = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Modalidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQtdMaxAlunos);
            this.groupBox1.Controls.Add(this.lblQtdMax);
            this.groupBox1.Controls.Add(this.btnCadastrar);
            this.groupBox1.Controls.Add(this.txtHora);
            this.groupBox1.Controls.Add(this.txtDSemana);
            this.groupBox1.Controls.Add(this.txtProf);
            this.groupBox1.Controls.Add(this.txtModal);
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Controls.Add(this.lblDSemana);
            this.groupBox1.Controls.Add(this.lblProf);
            this.groupBox1.Controls.Add(this.lblModal);
            this.groupBox1.Location = new System.Drawing.Point(72, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turma";
            // 
            // txtQtdMaxAlunos
            // 
            this.txtQtdMaxAlunos.Location = new System.Drawing.Point(149, 172);
            this.txtQtdMaxAlunos.Name = "txtQtdMaxAlunos";
            this.txtQtdMaxAlunos.Size = new System.Drawing.Size(278, 20);
            this.txtQtdMaxAlunos.TabIndex = 10;
            // 
            // lblQtdMax
            // 
            this.lblQtdMax.AutoSize = true;
            this.lblQtdMax.Location = new System.Drawing.Point(31, 175);
            this.lblQtdMax.Name = "lblQtdMax";
            this.lblQtdMax.Size = new System.Drawing.Size(95, 13);
            this.lblQtdMax.TabIndex = 9;
            this.lblQtdMax.Text = "Máximo de alunos:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(52, 212);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(380, 23);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(149, 134);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(283, 20);
            this.txtHora.TabIndex = 7;
            // 
            // txtDSemana
            // 
            this.txtDSemana.Location = new System.Drawing.Point(149, 97);
            this.txtDSemana.Name = "txtDSemana";
            this.txtDSemana.Size = new System.Drawing.Size(283, 20);
            this.txtDSemana.TabIndex = 6;
            // 
            // txtProf
            // 
            this.txtProf.Location = new System.Drawing.Point(149, 59);
            this.txtProf.Name = "txtProf";
            this.txtProf.Size = new System.Drawing.Size(283, 20);
            this.txtProf.TabIndex = 5;
            // 
            // txtModal
            // 
            this.txtModal.Location = new System.Drawing.Point(149, 19);
            this.txtModal.Name = "txtModal";
            this.txtModal.ReadOnly = true;
            this.txtModal.Size = new System.Drawing.Size(283, 20);
            this.txtModal.TabIndex = 4;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(31, 137);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(33, 13);
            this.lblHora.TabIndex = 3;
            this.lblHora.Text = "Hora:";
            // 
            // lblDSemana
            // 
            this.lblDSemana.AutoSize = true;
            this.lblDSemana.Location = new System.Drawing.Point(31, 97);
            this.lblDSemana.Name = "lblDSemana";
            this.lblDSemana.Size = new System.Drawing.Size(81, 13);
            this.lblDSemana.TabIndex = 2;
            this.lblDSemana.Text = "Dia da semana:";
            // 
            // lblProf
            // 
            this.lblProf.AutoSize = true;
            this.lblProf.Location = new System.Drawing.Point(31, 66);
            this.lblProf.Name = "lblProf";
            this.lblProf.Size = new System.Drawing.Size(54, 13);
            this.lblProf.TabIndex = 1;
            this.lblProf.Text = "Professor:";
            // 
            // lblModal
            // 
            this.lblModal.AutoSize = true;
            this.lblModal.Location = new System.Drawing.Point(31, 22);
            this.lblModal.Name = "lblModal";
            this.lblModal.Size = new System.Drawing.Size(65, 13);
            this.lblModal.TabIndex = 0;
            this.lblModal.Text = "Modalidade:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Modalidade});
            this.dataGridView1.Location = new System.Drawing.Point(11, 305);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(568, 226);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Modalidade
            // 
            this.Modalidade.HeaderText = "Modalidade";
            this.Modalidade.Name = "Modalidade";
            this.Modalidade.ReadOnly = true;
            // 
            // CadastrarTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CadastrarTurma";
            this.Text = "Cadastro de Turma";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TextBox txtDSemana;
        private System.Windows.Forms.TextBox txtProf;
        private System.Windows.Forms.TextBox txtModal;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblDSemana;
        private System.Windows.Forms.Label lblProf;
        private System.Windows.Forms.Label lblModal;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtQtdMaxAlunos;
        private System.Windows.Forms.Label lblQtdMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modalidade;
    }
}