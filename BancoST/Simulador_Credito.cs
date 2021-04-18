using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoST
{
    public partial class Simulador_Credito : Form
    {
        public Simulador_Credito()
        {
            InitializeComponent();
        }

        private void Simulador_Credito_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                double interes, total, valor_cuotas;
                double monto = double.Parse(txtMonto.Text);
                int cuotas = int.Parse(txtCuotas.Text);

                if (monto < 0)
                {
                    MessageBox.Show("El monto ingresado no puede ser negativo.", "Alerta", MessageBoxButtons.OK);
                }
                else if (monto < 500000)
                {
                    MessageBox.Show("Debe ingresar un minimo de $500.000 o superior en el monto.", "Alerta", MessageBoxButtons.OK);
                }
                else
                {
                    if (cuotas < 1 || cuotas > 36)
                    {
                        MessageBox.Show("La cantidad de cuotas deben estar entre 1 y 36", "Alerta", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (cuotas >= 1 && cuotas <= 12)
                        {
                            interes = 0.1;
                            // Redondeo para que muestre solo 2 decimales
                            total = (double)decimal.Round((decimal)(monto + (monto * interes)), 2);
                            valor_cuotas = (double)decimal.Round((decimal)(total / cuotas), 2);

                            txtMontoTotal.Text = total.ToString();
                            txtValorCuotas.Text = valor_cuotas.ToString();
                        }
                        else if (cuotas >= 13 && cuotas <= 24)
                        {
                            interes = 0.20;
                            total = (double)decimal.Round((decimal)(monto + (monto * interes)), 2);
                            valor_cuotas = (double)decimal.Round((decimal)(total / cuotas), 2);

                            txtMontoTotal.Text = total.ToString();
                            txtValorCuotas.Text = valor_cuotas.ToString();
                        }
                        else if (cuotas >= 25 && cuotas <= 36)
                        {
                            interes = 0.35;
                            total = (double)decimal.Round((decimal)(monto + (monto * interes)), 2);
                            valor_cuotas = (double)decimal.Round((decimal)(total / cuotas), 2);

                            txtMontoTotal.Text = total.ToString();
                            txtValorCuotas.Text = valor_cuotas.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique que haya ingresado los datos correctos en los campos.", "Alerta", MessageBoxButtons.OK);
            }
            

        }
    }
}
