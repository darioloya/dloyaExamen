using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dloyaExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro(string usuarioConectado)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuarioConectado;
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            double valorCurso = 1500;
            if (Convert.ToDouble(txtMontoInicial.Text) <= 0)
            {
                DisplayAlert("Error", "Ingrese un Monto Inicial", "Cerrar");
            }
            else if (Convert.ToDouble(txtMontoInicial.Text) > valorCurso)
            {
                DisplayAlert("Error", "El monto Inicial no debe superar el valor del curso " + valorCurso.ToString(), "Cerrar");
            }
            else
            {
                double montoInical = Convert.ToDouble(txtMontoInicial.Text);
                double valorPendiente = valorCurso - montoInical;
                double valorCuota = valorPendiente / 4;
                double valorInteres = valorCurso * 0.04;
                double valorCuotaInteres = valorCuota + valorInteres;
                txtPagoMensual.Text = valorCuotaInteres.ToString();
            }
        }

        private void btnResumen_Clicked(object sender, EventArgs e)
        {
            if (pkPais.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Seleccione un Pais", "Cerrar");
            }
            else if (pkCiudad.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Seleccione una Ciudad", "Cerrar");
            }
            else if (Convert.ToDouble(txtMontoInicial.Text) <= 0)
            {
                DisplayAlert("Error", "Debe ingresar el monto inicial", "Cerrar");
            }
            else if (Convert.ToDouble(txtPagoMensual.Text) <= 0)
            {
                DisplayAlert("Error", "Debe calcular el pago mensual", "Cerrar");
            }
            else if (txtNombre.Text == "")
            {
                DisplayAlert("Error", "Ingrese el nombre del estudiante", "Cerrar");
            }
            else if (txtApellido.Text == "")
            {
                DisplayAlert("Error", "Ingrese el apellido del estudiante", "Cerrar");
            }
            else if (txtEdad.Text == "" || Convert.ToInt32(txtEdad.Text) <= 0)
            {
                DisplayAlert("Error", "Ingrese una edad valida", "Cerrar");
            }
            else
            {
                string usuarioConectado = lblUsuarioConectado.Text;
                string fecha = txtFecha.Date.ToString("dd/MM/yyyy");
                string pais = pkPais.Items[pkPais.SelectedIndex];
                string ciudad = pkCiudad.Items[pkCiudad.SelectedIndex];
                double montoInicial = Convert.ToDouble(txtMontoInicial.Text);
                double pagoMensual = Convert.ToDouble(txtPagoMensual.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int edad = Convert.ToInt32(txtEdad.Text);

                double pagoTotal = (pagoMensual * 4) + montoInicial;

                Navigation.PushAsync(new Resumen(usuarioConectado, fecha, pais, ciudad, montoInicial, pagoMensual, nombre, apellido, edad, pagoTotal));
            }
        }
    }
}