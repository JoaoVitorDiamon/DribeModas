﻿using Estoque;
using Pedidos;
using ProdutoDLL;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Drawing;
using QuestPDF.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Adapters.Entities;
using Usuario;

namespace ProjetoJeffersonADM
{
    public partial class Pedidos : Form
    {
        readonly NotaFiscal nota = new NotaFiscal();
        readonly Pedido pedidos = new Pedido(DateTime.Now, 0, 0, 0, 0, 0, 0, "",0);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
          int nHeightEllipse
          );
        DataTable pedido;
        public Pedidos()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            

        }



        private void Pedidos_Load(object sender, EventArgs e)
        {

            pedido = Dao.ObterPedidos();
            bunifuDataGridView1.DataSource = pedido;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pedido = Dao.ObterPedidos();
            bunifuDataGridView1.DataSource = pedido;

        }

        private void apagar_btn_Click(object sender, EventArgs e)
        {

            if (bunifuDataGridView1.SelectedCells.Count > 0)
            {

                int indexDaLinha = bunifuDataGridView1.SelectedCells[0].RowIndex;

                int id = Convert.ToInt32(bunifuDataGridView1.Rows[indexDaLinha].Cells["ID"].Value);
                int quantidade = Convert.ToInt32(bunifuDataGridView1.Rows[indexDaLinha].Cells["Quantidade"].Value);
                int idProduto = Convert.ToInt32(bunifuDataGridView1.Rows[indexDaLinha].Cells["ProdutoID"].Value);
                int idFabricante = Convert.ToInt32(bunifuDataGridView1.Rows[indexDaLinha].Cells["IDFabricante"].Value);

                pedidos.RemoverPedidos(id, quantidade, idProduto, idFabricante);

            }

            Pedidos peddos = new Pedidos();
            pedido = Dao.ObterPedidos();
            bunifuDataGridView1.DataSource = pedido;
        }

        private void Pedidos_Load_1(object sender, EventArgs e)
        {
            pedido = Dao.ObterPedidos();
            bunifuDataGridView1.DataSource = pedido;
        }

        private void pesquisa_txt_TextChanged(object sender, EventArgs e)
        {
            string termoDePesquisa = pesquisa_txt.Text.Trim();

            if (!string.IsNullOrEmpty(termoDePesquisa))
            {
                string filtro = $"Cliente LIKE '%{termoDePesquisa}%' OR " +
                                $"Convert(ClienteID, 'System.String') LIKE '%{termoDePesquisa}%' OR " +
                                $"forma_pagamento LIKE '%{termoDePesquisa}%' OR " +
                                $"Convert(ProdutoID, 'System.String') LIKE '%{termoDePesquisa}%' OR " +
                                $"Produto LIKE '%{termoDePesquisa}%' OR " +
                                $"Convert(Quantidade, 'System.String') LIKE '%{termoDePesquisa}%' OR " +
                                $"Convert(PrecoUnitario, 'System.String') LIKE '%{termoDePesquisa}%' OR " +
                                $"Convert(ValorTotal, 'System.String') LIKE '%{termoDePesquisa}%' OR " +
                                $"Convert(Parcelas, 'System.String') LIKE '%{termoDePesquisa}%'";

                DataView filtrar = new DataView(pedido);
                filtrar.RowFilter = filtro;
                bunifuDataGridView1.DataSource = filtrar;
            }
            else
            {
                bunifuDataGridView1.DataSource = pedido;
            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {

            if (bunifuDataGridView1.SelectedCells.Count > 0)
            {
                int indexDaLinha = bunifuDataGridView1.SelectedCells[0].RowIndex;

                string nomeCli = bunifuDataGridView1.Rows[indexDaLinha].Cells["Cliente"].Value.ToString();
                int idCliente = Convert.ToInt32(bunifuDataGridView1.Rows[indexDaLinha].Cells["ClienteID"].Value);
                string formaPagamento = bunifuDataGridView1.Rows[indexDaLinha].Cells["forma_pagamento"].Value.ToString();
                int idProduto = Convert.ToInt32(bunifuDataGridView1.Rows[indexDaLinha].Cells["ProdutoID"].Value);
                string nomeProduto = bunifuDataGridView1.Rows[indexDaLinha].Cells["Produto"].Value.ToString();
                int quantidade = Convert.ToInt32(bunifuDataGridView1.Rows[indexDaLinha].Cells["Quantidade"].Value);
                double precoUnitario = Convert.ToDouble(bunifuDataGridView1.Rows[indexDaLinha].Cells["PrecoUnitario"].Value);
                double valorTotal = Convert.ToDouble(bunifuDataGridView1.Rows[indexDaLinha].Cells["ValorTotal"].Value);
                int parcelas = Convert.ToInt32(bunifuDataGridView1.Rows[indexDaLinha].Cells["Parcelas"].Value);
                string cpf = Dao.AcharCPF(idCliente);
                string rua = Dao.AcharEndereco(idCliente);
                string cidade = Dao.AcharCidade(idCliente);
                string telefone = Dao.AcharTelefone(idCliente);
                string fabricante = bunifuDataGridView1.Rows[indexDaLinha].Cells["Fabricante"].Value.ToString();
                string nomeSemEspacos = nomeCli.Replace(" ", "");

                nota.EmitirNotaFiscal(nomeSemEspacos,nomeCli,cpf,rua,cidade,telefone,idProduto,nomeProduto,quantidade,precoUnitario,valorTotal,formaPagamento);
          
            }
            else
            {
                MessageBox.Show("Nenhuma célula selecionada na DataGridView.");
            }

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Main2 main = new Main2();
            this.Hide();
            main.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            TelaProdutos telaProdutos = new TelaProdutos();
            this.Hide();
            telaProdutos.Show();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            this.Hide();
            clientes.Show();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Estoque estoque = new Estoque();
            this.Hide();
            estoque.Show();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            this.Hide();
            fornecedor.Show();
        }

        private void bunifuPanel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Financas financas = new Financas();
            this.Hide();
            financas.Show();
        }
    }
}





