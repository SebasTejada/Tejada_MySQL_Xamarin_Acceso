using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace MySQL_Xamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
		//Declaración de los componentes.
		Button access;
		EditText User, Password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
			//Se asignan los controles del Layout a una varaible del mismo tipo
			access = FindViewById<Button>(Resource.Id.btn_entrar);
			User = FindViewById<EditText>(Resource.Id.et_user);
			Password = FindViewById<EditText>(Resource.Id.et_password);

			//La accion de presionar el boton
			access.Click += delegate {
			//Se crea una instancia de la clase Conexion
				Conexion con = new Conexion();
				//Se prueba la conexion pasando los datos de los EditText que son usuario y contraseña
				if (con.TryConnection(this,User.Text,Password.Text)){
					Toast.MakeText(this, "Conexion Exitosa!", ToastLength.Long).Show();
				}
				else{
					Toast.MakeText(this, "Error!", ToastLength.Long).Show();
				}
			};
		}
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}