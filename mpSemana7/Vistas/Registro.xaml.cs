using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mpSemana7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public Registro()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try 
            {
                var datos = new Estudiante
                {
                    Nombre = txtNombre.Text,
                    Usuario = txtUsuario.Text,
                    Contrasena  = txtContrasena.Text,
                };
                conexion.InsertAsync(datos);
                txtNombre.Text ="";
                txtUsuario.Text = "";
                txtContrasena.Text = "";
                DisplayAlert("ALERTA", "Datos Grabados Exitosamente", "Cerrar");
                Navigation.PushAsync(new Login());

            }
            catch(Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }

        }
    }
}