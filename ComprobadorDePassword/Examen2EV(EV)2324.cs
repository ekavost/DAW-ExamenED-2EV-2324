using ComprobadorDePasswordApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComprobadorDePasswordApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ComprobadorDePassword miComprobador = new ComprobadorDePassword();
        private void btnComprobar_click(object sender, EventArgs e)
        {
            try
            {
                int resultado = miComprobador.TestPassword(txtPassword.Text);

                if (resultado == 1)
                    MessageBox.Show("Contraseña débil");
                else if (resultado == 2)
                    MessageBox.Show("Contraseña normal");
                else if (resultado == 3)
                    MessageBox.Show("Contraseña fuerte");
                else if (resultado == 4)
                    MessageBox.Show("Contraseña muy fuerte");
            }
            catch (Exception error)
            {
                if (error.Message.Contains(ComprobadorDePassword.ERROR_EMPTY_PASSWORD))
                {
                    MessageBox.Show("La contraseña no puede estar vacía");
                }
                else if (error.Message.Contains(ComprobadorDePassword.ERROR_SHORT_PASSWORD))
                {
                    MessageBox.Show("Contraseña demasiado corta");
                }
            }
            
        }
    }
}
