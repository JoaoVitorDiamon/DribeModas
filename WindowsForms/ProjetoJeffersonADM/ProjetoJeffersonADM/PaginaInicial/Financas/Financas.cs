﻿using Bunifu.Dataviz.WinForms;
using Fabricante;
using ProjetoJeffersonADM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuario;

namespace ProjetoJeffersonADM
{
    public partial class Financas : Form
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

        readonly private BunifuDatavizBasic.Canvas canvas;


        Point DragCursor;
        Point DragForm;
        bool Dragging;


        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void Login_Click(object sender, EventArgs e)
        {
        }


        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private const int SombraDaJanela = 0x0002000;

        protected override CreateParams CreateParams
        {

            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = SombraDaJanela;
                return cp;
            }

        }
        private void CriarGrafico()
        {
            double valorEntrada = Dao.ValorTotal();
            double valorSaida = Dao.AcharDespesasLojas();
            var canvas = new BunifuDatavizBasic.Canvas();
            bunifuDatavizBasic1.colorSet.Add(Color.Green); 
            bunifuDatavizBasic1.colorSet.Add(Color.Red);
            var dataPoint = new BunifuDatavizBasic.DataPoint(BunifuDatavizBasic._type.Bunifu_column);

            dataPoint.addLabely("Entrada", valorEntrada.ToString());
            dataPoint.addLabely("Saida", valorSaida.ToString());

            canvas.addData(dataPoint);

            bunifuDatavizBasic1.Render(canvas);

        }
        public Financas()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));


        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

  
        private void Financas_Load(object sender, EventArgs e)
        {
            CriarGrafico();
            despesas.Text = $"R$:{Dao.AcharDespesasLojas()}";
            entrada.Text = $"R$:{Dao.ValorTotal()}";
        }

        private void bunifuDatavizBasic1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDatavizAdvanced1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            this.Hide();
            fornecedor.Show();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            this.Hide();
            pedidos.Show();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Estoque estoque = new Estoque();
            this.Hide();
            estoque.Show();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            this.Hide();
            clientes.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            TelaProdutos telaProdutos = new TelaProdutos();
            this.Hide();
            telaProdutos.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Main2 main2 = new Main2();
            this.Hide();
            main2.Show();
        }

        private void bunifuDatavizBasic1_Load_1(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            Entrada_saida saida = new Entrada_saida();
            this.Hide();
            saida.Show();
        }

        private void bunifuButton14_Click(object sender, EventArgs e)
        {
            Main2 main2 = new Main2();
            this.Hide(); 
            main2.Show();
        }

        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            TelaProdutos telaProdutos = new TelaProdutos();
            this.Hide();
            telaProdutos.Show();
        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            this.Hide();
            clientes.Show();
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            Estoque estoque = new Estoque();
            this.Hide();
            estoque.Show();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            this.Hide();
            pedidos.Show();
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            this.Hide();
            fornecedor.Show();
        }
    }
}
