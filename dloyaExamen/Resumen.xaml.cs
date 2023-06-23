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
    public partial class Resumen : ContentPage
    {
        public Resumen(string usuarioConectado, string fecha, string pais, string ciudad, double montoInicial, double pagoMensual, string nombre, string apellido, int edad, double pagoTotal)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = usuarioConectado;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
            txtFecha.Text = fecha;
            txtPais.Text = pais;
            txtCiudad.Text = ciudad;
            txtMontoInicial.Text = montoInicial.ToString();
            txtPagoMensulal.Text = pagoMensual.ToString();
            txtPagoTotal.Text = pagoTotal.ToString();
        }

        private void btnCerrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}