using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Tarea1_3.Datos;
using Tarea1_3.Tablas;
using System.IO;

namespace Tarea1_3.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_Principal : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public V_Principal()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            btnBuscar.Clicked += BtnBuscar_Clicked;
            btnRegistrar.Clicked += BtnRegistrar_Clicked;
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new V_Registro());
        }

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
                var rutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Datos_Usuario.db3");
                var db = new SQLiteConnection(rutaDB);
                db.CreateTable<TDatos>();
                    Navigation.PushAsync(new V_Consulta());
                    //DisplayAlert("Aviso", "Existen contactos con este nombre", "OK");
               
           
        }

        private IEnumerable<TDatos> SELECT_WHERE(SQLiteConnection db, string nombre)
        {
            /*return db.Query<T_Contacto>("SELECT * FROM T_Contacto WHERE Nombre=?", nombre);*/
            return db.Query<TDatos>("SELECT * FROM TDatos WHERE Nombre =?", nombre);
        }
    }
}