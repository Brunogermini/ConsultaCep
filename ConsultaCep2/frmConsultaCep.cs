using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaCep2
{
    public partial class frmConsultaCep : Form
    {
        public frmConsultaCep()
        {
            InitializeComponent();
        //gpbResultado.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBairro.Text =String.Empty;
            txtCep.Text = String.Empty;
            txtCidade.Text = String.Empty;
            txtEstado.Text = String.Empty;
            txtRua.Text = String.Empty;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            txtRua.Text = String.Empty;
            txtEstado.Text = String.Empty;
            txtCidade.Text = String.Empty;
            txtBairro.Text = String.Empty;
            
            if (!string.IsNullOrWhiteSpace(txtCep.Text))
            {
                
                using ( var ws = new wsCorreios2.AtendeClienteClient())
                {
                    try
                    {
                        
                        var endereco = ws.consultaCEP(txtCep.Text);
                        txtRua.Text = endereco.end;
                        txtEstado.Text = endereco.uf;
                        txtCidade.Text = endereco.cidade;
                        txtBairro.Text = endereco.bairro;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("Informe um Cep válido",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

         

        }

    }
}
