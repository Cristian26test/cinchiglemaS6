using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cinchiglemaS6
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActualizarEliminar : ContentPage
	{
        private string URL = "http://192.168.200.13/ws_uisrael/post.php?codigo=";

        public ActualizarEliminar (Estudiante datos)
		{
			InitializeComponent ();
            txtcodigo.Text = datos.codigo.ToString();
            txtnombre.Text = datos.nombre.ToString();
            txtapellido.Text = datos.apellido.ToString();
            txtedad.Text = datos.edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var datos = new System.Collections.Specialized.NameValueCollection();
               
                datos.Add("nombre", txtnombre.Text);
                datos.Add("apellido", txtapellido.Text);
                datos.Add("edad", txtedad.Text);

                var parametros = txtcodigo.Text+ "&nombre=" + txtnombre.Text + "&apellido=" + txtapellido.Text + "&edad="+txtedad.Text ;

                cliente.UploadValues(URL + parametros, "PUT", datos);
                DisplayAlert("Alerta", "Dato Actualizado", "Cerrar");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var datos = new System.Collections.Specialized.NameValueCollection();
                datos.Add("codigo", txtcodigo.Text);
                

                cliente.UploadValues(URL + txtcodigo.Text, "DELETE", datos);
                DisplayAlert("Alerta", "Dato Eliminado", "Cerrar");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}