using Microsoft.Data.SqlClient;

namespace WebAppUsuarios.Models
{
    public class AccesoDatos
    {
        //Almacena la cadena de conexion a la DB
        private readonly string _conexion;

        public AccesoDatos(IConfiguration configuration)
        {
            _conexion = configuration.GetConnectionString("DefaultConnection");
        }

        //Metodo para crear usuario
        public void AgregarUsuario(Usuarios nuevoUsuario)
        {
            using(SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spInsertarDatos @Nombre,@Correo";

                    using(SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nuevoUsuario.Nombre);
                        cmd.Parameters.AddWithValue("@Correo", nuevoUsuario.Correo);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar el ususario" + ex.Message);
                }
            }
        }
    }
}
