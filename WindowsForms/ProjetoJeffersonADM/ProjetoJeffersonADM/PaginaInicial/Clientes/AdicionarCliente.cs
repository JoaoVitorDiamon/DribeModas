﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoJeffersonADM.PaginaInicial.Clientes
{

    public partial class AdicionarCliente : Form
    {
    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn(
         int nLeftRect,
         int nTopRect,
         int nRightRect,
         int nBottomRect,
         int nWidthEllipse,
         int nHeightEllipse
         );
        public AdicionarCliente()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(nomeCliente_txt.Text))
                {
                    nome.Show(this, "Nome do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
               else if (String.IsNullOrWhiteSpace(rgcli_txt.Text))
                {
                    nome.Show(this, "Rg do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(cpfCli_txt.Text) || !Validacao.ValidaCPF.IsCpf(cpfCli_txt.Text))
                {
                    nome.Show(this, "Insira um Cpf valido", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(telCli_txt.Text))
                {
                    nome.Show(this, "Telefone do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(ruaCli_txt.Text))
                {
                    nome.Show(this, "Rua do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(bairroCli_txt.Text))
                {
                    nome.Show(this, "Bairro do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(cidadeCli_txt.Text))
                {
                    nome.Show(this, "Cidade do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(estadoCli_txt.Text))
                {
                    nome.Show(this, "Estado do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(emailCli_txt.Text))
                {
                    nome.Show(this, "Email do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                ClientesDLL.Clientes clientes = new ClientesDLL.Clientes(nomeCliente_txt.Text,rgcli_txt.Text,cpfCli_txt.Text,telCli_txt.Text,ruaCli_txt.Text,bairroCli_txt.Text,cidadeCli_txt.Text,estadoCli_txt.Text,emailCli_txt.Text,"indefinido");
            clientes.AdicionarCliente();
                this.Hide();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AdicionarCliente_Load(object sender, EventArgs e)
        {

        }

        private void cpfCli_txt_TextChanged(object sender, EventArgs e)
        {
            string text = cpfCli_txt.Text.Replace(".", "").Replace("/", "").Replace("-", "");

            if (text.Length > 3)
                text = text.Insert(3, ".");
            if (text.Length > 7)
                text = text.Insert(7, ".");
            if (text.Length > 11)
                text = text.Insert(11, "-");


            cpfCli_txt.Text = text;
            cpfCli_txt.SelectionStart = cpfCli_txt.Text.Length;
        }

        private void rgcli_txt_TextChanged(object sender, EventArgs e)
        {
            string text = rgcli_txt.Text.Replace(".", "").Replace("/", "").Replace("-", "");

            if (text.Length > 2)
                text = text.Insert(2, ".");
            if (text.Length > 6)
                text = text.Insert(6, ".");
            if (text.Length > 10)
                text = text.Insert(10, "-");


            rgcli_txt.Text = text;
            rgcli_txt.SelectionStart = rgcli_txt.Text.Length;
        }
    }
}


