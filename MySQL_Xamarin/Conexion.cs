using System;
using Android.Content;
using Android.Widget;
using MySql.Data.MySqlClient;

namespace MySQL_Xamarin
{
	public class Conexion
	{
	/// <summary>
	/// Prueba la conexión a la base de datos utilizando las credenciales correspondientes
	/// </summary>
	/// <param name="context"></param>
	/// <param name="Usuario"></param>
	/// <param name="Contrasenia"></param>
	/// <returns></returns>
		public bool TryConnection(Context context, string Usuario,string Contrasenia)
		{
			MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
			Builder.Port = 3306;
			Builder.Server = "sql9.freemysqlhosting.net"; //Al ser una BD Online debes usar la ip de tu servidor y no localhost
			Builder.Database = "sql9377454";
			Builder.UserID = Usuario; //Es el usuario de la base de datos
			Builder.Password = Contrasenia; //La contraseña del usuario
			try
			{
				MySqlConnection ms = new MySqlConnection(Builder.ToString());
				ms.Open();
				return true;
			}
			catch (Exception ex)
			{
				Toast.MakeText(context,ex.ToString(), ToastLength.Long).Show(); //Muestra un Toast con el error (Puede ser muy largo)
				return false;
			}
		}
	}
}