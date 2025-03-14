﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuario;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjetoJeffersonADM
{

    public partial class EditarClientes : Form
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
       readonly ClientesDLL.Clientes cli;
        public EditarClientes(string id, string nome, string rg, string cpf, string telefone, string rua, string bairro, string cidade, string estado, string email)
        {
            InitializeComponent();
            idCliente_txt.Text = id;
            nomeCli_txt.Text = nome;
            rgcli_txt.Text = rg;
            cpfCli_txt.Text = cpf;
            telCli_txt.Text = telefone;
            ruaCli_txt.Text = rua;
            bairroCli_txt.Text = bairro;
            cidadeCli_txt.Text = cidade;
            estadoCli_txt.Text = estado;
            emailCli_txt.Text = email;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

            cli = new ClientesDLL.Clientes(nome, rg, cpf, telefone, rua, bairro, cidade, estado, email, "0");

        }

        private void EditarClientes_Load(object sender, EventArgs e)
        {

        }

 

        private void EditarClientes_Load_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
           this.Hide();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            int IdConvertido = int.Parse(idCliente_txt.Text);
            try
            {
                if (String.IsNullOrWhiteSpace(nomeCli_txt.Text))
                {
                    nome.Show(this, "Nome do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(rgcli_txt.Text))
                {
                    nome.Show(this, "Rg do cliente esta vazio:", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else if (String.IsNullOrWhiteSpace(cpfCli_txt.Text))
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
                cli.AtualizarCliente(IdConvertido, nomeCli_txt.Text, rgcli_txt.Text, cpfCli_txt.Text, telCli_txt.Text, ruaCli_txt.Text, bairroCli_txt.Text, cidadeCli_txt.Text, estadoCli_txt.Text, emailCli_txt.Text);
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cpfCli_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
