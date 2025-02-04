using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        txtChave = new TextBox();
        txtConta = new TextBox();
        lblStatus = new Label();
        btnApostar = new Button();
        richTextBox1 = new RichTextBox();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        richTextBox2 = new RichTextBox();
        SuspendLayout();
        // 
        // txtChave
        // 
        txtChave.Location = new Point(56, 47);
        txtChave.Margin = new Padding(4, 3, 4, 3);
        txtChave.Name = "txtChave";
        txtChave.Size = new Size(483, 23);
        txtChave.TabIndex = 0;
        // 
        // txtConta
        // 
        txtConta.Location = new Point(56, 116);
        txtConta.Margin = new Padding(4, 3, 4, 3);
        txtConta.Name = "txtConta";
        txtConta.Size = new Size(483, 23);
        txtConta.TabIndex = 1;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(56, 237);
        lblStatus.Margin = new Padding(4, 0, 4, 0);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(0, 15);
        lblStatus.TabIndex = 3;
        // 
        // btnApostar
        // 
        btnApostar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnApostar.Location = new Point(219, 161);
        btnApostar.Margin = new Padding(4, 3, 4, 3);
        btnApostar.Name = "btnApostar";
        btnApostar.Size = new Size(156, 51);
        btnApostar.TabIndex = 2;
        btnApostar.Text = "Apostar";
        btnApostar.UseVisualStyleBackColor = true;
        btnApostar.Click += btnApostar_Click;
        // 
        // richTextBox1
        // 
        richTextBox1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        richTextBox1.Location = new Point(56, 339);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(483, 96);
        richTextBox1.TabIndex = 4;
        richTextBox1.Text = "";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(56, 29);
        label1.Name = "label1";
        label1.Size = new Size(276, 15);
        label1.TabIndex = 5;
        label1.Text = "Insira a chave que pretende apostar (X,X,X,X,X+Y,Y)";
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(56, 98);
        label2.Name = "label2";
        label2.Size = new Size(228, 15);
        label2.TabIndex = 6;
        label2.Text = "Identifique a conta CREDIBANK (8 digitos)";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(56, 321);
        label3.Name = "label3";
        label3.Size = new Size(98, 15);
        label3.TabIndex = 7;
        label3.Text = "Estado da Aposta";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(56, 237);
        label4.Name = "label4";
        label4.Size = new Size(101, 15);
        label4.TabIndex = 8;
        label4.Text = "Dados do Cheque";
        // 
        // richTextBox2
        // 
        richTextBox2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        richTextBox2.Location = new Point(56, 255);
        richTextBox2.Name = "richTextBox2";
        richTextBox2.Size = new Size(483, 47);
        richTextBox2.TabIndex = 9;
        richTextBox2.Text = "";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(634, 510);
        Controls.Add(richTextBox2);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(richTextBox1);
        Controls.Add(btnApostar);
        Controls.Add(lblStatus);
        Controls.Add(txtConta);
        Controls.Add(txtChave);
        Margin = new Padding(4, 3, 4, 3);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox txtChave;
    private System.Windows.Forms.TextBox txtConta;
    private System.Windows.Forms.Label lblStatus;
    private RichTextBox richTextBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private RichTextBox richTextBox2;
    private System.Windows.Forms.Button btnApostar;

    // Validação para a conta do CREDIBANK (8 dígitos)
    private bool IsValidAccountId(string accountId)
    {
        return Regex.IsMatch(accountId, @"^\d{8}$");
    }

    // Validação para a chave do Euromilhões
    private bool IsValidKey(string key)
    {
        // Implementa aqui as regras para a chave do Euromilhões
        // O formato é "X,X,X,X,X+Y,Y" (onde + separa os números das estrelas)
        // números: 5 números distintos entre 1 e 50
        // estrelas: 2 números distintos entre 1 e 12
        // Exemplo válido: 1,23,49,32,5+12,6
        {
        string pattern = @"^(\d{1,2},\d{1,2},\d{1,2},\d{1,2},\d{1,2})\+(\d{1,2},\d{1,2})$";
        Match match = Regex.Match(key, pattern);

        if (!match.Success)
        {
            richTextBox1.Text = "Formato inválido! Deve ser X,X,X,X,X+Y,Y";
            return false;
        }

        var numerosPrincipais = match.Groups[1].Value.Split(',').Select(int.Parse).ToList();
        var estrelas = match.Groups[2].Value.Split(',').Select(int.Parse).ToList();

        if (numerosPrincipais.Count != 5 || estrelas.Count != 2)
        {
            richTextBox1.Text = "A chave deve ter 5 números e 2 estrelas.";
            return false;
        }

        if (numerosPrincipais.Any(n => n < 1 || n > 50) || estrelas.Any(n => n < 1 || n > 12))
        {
            richTextBox1.Text = "Números entre 1-50 e estrelas entre 1-12.";
            return false;
        }

        if (numerosPrincipais.Distinct().Count() != 5 || estrelas.Distinct().Count() != 2)
        {
            richTextBox1.Text = "Os números e estrelas não se podem repetir.";
            return false;
        }

        return true;
        }
    }
    private async void btnApostar_Click(object? sender, EventArgs e)
    {
        richTextBox1.Text = "A Processar...";
        richTextBox2.Text = "A Processar...";


        string chave = txtChave.Text.Trim();
        string conta = txtConta.Text.Trim();

        // Valida os campos
        if (!IsValidAccountId(conta))
        {
            richTextBox1.Text = "ID de conta inválido! Deve conter 8 dígitos.";

            return;
        }
        if (!IsValidKey(chave))
        {
            
            richTextBox1.Text = "Chave da aposta inválida!";

            return;
        }

        try
        {
            // Solicitar o cheque digital ao CrediBank (valor fixo de 10 créditos)
            ChequeDigital cheque = await CrediBankClient.ObterChequeDigitalAsync(conta, 10);
            if (cheque == null)
            {
                richTextBox2.Text = "Falha ao obter cheque digital.";

                return;
            }

            // exibir detalhes do cheque (data, checkID)
            richTextBox2.Text = $"Cheque obtido com sucesso!\n" +
                            $"Data: {cheque.Date:yyyy-MM-dd HH:mm:ss}\n" +
                            $"CheckID: {cheque.CheckID}";

            // Registar a aposta via EuroMilRegister usando o cheque digital obtido
            string resposta = await EuroMilRegisterClient.RegistrarApostaAsync(chave, cheque.CheckID);

            // Exibe o resultado da aposta(mensagem de sucesso ou erro)
            richTextBox1.Text = resposta;

        }
        catch (Exception ex)
        {
            richTextBox1.Text = "Erro: " + ex.Message;

        }
    }

    private void label1_Click(object? sender, EventArgs e)
    {
    }

    private void label3_Click(object sender, EventArgs e)
    {

    }
}
