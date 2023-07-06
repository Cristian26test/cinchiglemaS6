using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cinchiglemaS6
{
    public partial class MainPage : ContentPage
    {
        private string URL = "http://192.168.200.13/ws_uisrael/post.php";
        private readonly HttpClient cliente= new HttpClient();
        private ObservableCollection <Estudiante> post;
        public MainPage()
        {
            InitializeComponent();
            obtener();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public async void obtener()
        {
            var contenido = await cliente.GetStringAsync(URL);
            List<Estudiante> datosPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            post = new ObservableCollection<Estudiante>(datosPost);
            listaEstudiante.ItemsSource = post;
        }
        private async void btnconsultar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insertar());
        }

        private void listaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante=(Estudiante)e.SelectedItem;
            Navigation.PushAsync(new ActualizarEliminar(objetoEstudiante));
        }
    }

    internal class listaEstudiante
    {
        public static ObservableCollection<Estudiante> ItemsSource { get; internal set; }
    }
}
