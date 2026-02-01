namespace cadastroApp
{
    partial class FormPrincipal
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtnome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            notifyIcon1 = new NotifyIcon(components);
            txtCpf = new TextBox();
            btnAtualizar = new Button();
            btnInserir = new Button();
            btnListar = new Button();
            dgvCadastro = new DataGridView();
            txtId = new TextBox();
            btnTestarConexao = new Button();
            btnexcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCadastro).BeginInit();
            SuspendLayout();
            // 
            // txtnome
            // 
            txtnome.Location = new Point(116, 53);
            txtnome.Name = "txtnome";
            txtnome.Size = new Size(608, 23);
            txtnome.TabIndex = 0;
            txtnome.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 53);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 97);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "cpf";
            label2.Click += label2_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(116, 97);
            txtCpf.MaxLength = 11;
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(608, 23);
            txtCpf.TabIndex = 3;
            txtCpf.KeyPress += txtCpf_KeyPress;
            // 
            // btnInserir
            // 
            btnInserir.Location = new Point(61, 173);
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new Size(75, 23);
            btnInserir.TabIndex = 5;
            btnInserir.Text = "Inserir";
            btnInserir.UseVisualStyleBackColor = true;
            btnInserir.Click += button2_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(150, 173);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 6;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // dgvCadastro
            // 
            dgvCadastro.AllowUserToAddRows = false;
            dgvCadastro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCadastro.Location = new Point(61, 230);
            dgvCadastro.MultiSelect = false;
            dgvCadastro.Name = "dgvCadastro";
            dgvCadastro.ReadOnly = true;
            dgvCadastro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCadastro.Size = new Size(663, 150);
            dgvCadastro.TabIndex = 7;
            dgvCadastro.CellClick += dgvCadastro_CellContentClick;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(674, 178);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 8;
            txtId.Visible = false;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(234, 173);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(75, 23);
            btnAtualizar.TabIndex = 11;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnexcluir
            // 
            btnexcluir.Location = new Point(318, 173);
            btnexcluir.Name = "btnexcluir";
            btnexcluir.Size = new Size(75, 23);
            btnexcluir.TabIndex = 9;
            btnexcluir.Text = "Excluir";
            btnexcluir.UseVisualStyleBackColor = true;
            btnexcluir.Click += btnexcluir_Click;
            // 
            // btnTestarConexao
            // 
            btnTestarConexao.Location = new Point(402, 173);
            btnTestarConexao.Name = "btnTestarConexao";
            btnTestarConexao.Size = new Size(110, 23);
            btnTestarConexao.TabIndex = 10;
            btnTestarConexao.Text = "Testar conexão";
            btnTestarConexao.UseVisualStyleBackColor = true;
            btnTestarConexao.Click += btnTestarConexao_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 450);
            Controls.Add(btnexcluir);
            Controls.Add(btnTestarConexao);
            Controls.Add(txtId);
            Controls.Add(dgvCadastro);
            Controls.Add(btnListar);
            Controls.Add(btnInserir);
            Controls.Add(btnAtualizar);
            Controls.Add(txtCpf);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtnome);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            ((System.ComponentModel.ISupportInitialize)dgvCadastro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private TextBox txtnome;
        private Label label1;
        private Label label2;
        private NotifyIcon notifyIcon1;
        private TextBox txtCpf;
        private Button btnInserir;
        private Button btnListar;
        private DataGridView dgvCadastro;
        private TextBox txtId;
        private Button btnTestarConexao;
        private Button btnexcluir;
        private Button btnAtualizar;
    }
}