using System;
using MySql.Data.MySqlClient; // Importa la libreria par la conexion con MySQL

namespace CRUDMySQLCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Datos de conexion a la base de datos
            string conexionString = "datasource=localhost;" +
                "username=root;" +
                "password='';" +
                "database=pruebas";

            // Se crea la conexion
            MySqlConnection dbConexion = new MySqlConnection(conexionString);

            // Metodos del CRUD, solo descomenta lo que ocupes

            //mostrarUsuarios(dbConexion);

            //mostrarUsuario(dbConexion);

            //insertarUsuario(dbConexion);

            //editarUsuario(dbConexion);

            //eliminarUsuario(dbConexion);
        }

        // Metodo que muestra todos los usuarios registrados
        public static void mostrarUsuarios(MySqlConnection dbConexion)
        {
            string consulta = "SELECT * FROM usuarios"; // Consulta

            MySqlCommand cmdDB = new MySqlCommand(consulta, dbConexion); // Crea la conexion

            MySqlDataReader lectura; 

            try
            {
                dbConexion.Open(); // Se abre la conexion

                lectura = cmdDB.ExecuteReader(); // Se ejecuta la consulta

                if (lectura.HasRows) // Si se detectan registros
                {
                    while (lectura.Read()) // Se recorre los datos leidos
                    {
                        string[] row = { lectura.GetString(0), lectura.GetString(1), lectura.GetString(2), lectura.GetString(3) };
                        Console.WriteLine(row[0] + "-" + row[1] + ", " + row[2] + ", " + row[3]);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                }

                dbConexion.Close(); // Se cierra la conexion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void insertarUsuario(MySqlConnection dbConexion)
        {
            // Datos del nuevo usuario
            string nombre = "jacobo";
            string telefono = "66542342";
            string email = "jacobo@hola.es";

            // Consulta
            string consulta = "INSERT INTO usuarios(nombre, telefono, email) VALUES('" + nombre + "', '" + telefono + "', '" + email + "')";

            // Se crea la conexion
            MySqlCommand cmdDB = new MySqlCommand(consulta, dbConexion);

            try
            {
                dbConexion.Open(); // Se abre la conexion

                MySqlDataReader lectura = cmdDB.ExecuteReader(); // Se ejecuta la consulta
                Console.WriteLine("Usuario insertado correctamente");

                dbConexion.Close(); // Se cierra la conexion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            mostrarUsuarios(dbConexion);
        }

        public static void mostrarUsuario(MySqlConnection dbConexion)
        {
            // Identificador a buscar
            string idUsuario = "12";

            // Consulta
            string consulta = "SELECT * FROM usuarios WHERE idUsuario='" + idUsuario + "'";

            // Se crea la conexion
            MySqlCommand cmdDB = new MySqlCommand(consulta, dbConexion);

            MySqlDataReader lectura;

            try
            {
                dbConexion.Open(); // Se abre la conexion

                lectura = cmdDB.ExecuteReader(); // Se ejecuta la consulta

                if (lectura.HasRows) // Si existen registros
                {
                    while (lectura.Read()) // Se lee el registro
                    {
                        string[] row = { lectura.GetString(0), lectura.GetString(1), lectura.GetString(2), lectura.GetString(3), };
                        Console.WriteLine(row[0] + "-" + row[1] + ", " + row[2] + ", " + row[3]);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                }

                dbConexion.Close(); // Se cierra la conexion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            mostrarUsuarios(dbConexion);
        }

        public static void editarUsuario(MySqlConnection dbConexion)
        {
            // Datos del usuario para editar
            string idUsuario = "12";

            string nombre = "lourdes";
            string telefono = "32234242";
            string email = "lourdes@hola.es";

            // Consulta
            string consulta = "UPDATE `usuarios` SET `nombre`='" + nombre + "', `telefono`='" + telefono + "', `email`='" + email + "' WHERE idUsuario='" + idUsuario + "'";

            // Se crea la conexion
            MySqlCommand cmdDB = new MySqlCommand(consulta, dbConexion);

            MySqlDataReader lectura;

            try
            {
                dbConexion.Open(); // Se abre la conexion

                lectura = cmdDB.ExecuteReader(); // Se ejecuta la consulta
                Console.WriteLine("Usuario actualizado correctamente");

                dbConexion.Close(); // Se cierra la conexion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            mostrarUsuarios(dbConexion);



        }

        public static void eliminarUsuario(MySqlConnection dbConexion)
        {
            // Identificador del usuario
            string idUsuario = "12";

            // Consulta
            string consulta = "DELETE FROM usuarios WHERE idUsuario='" + idUsuario + "'";

            // Se crea la conexion
            MySqlCommand cmdDB = new MySqlCommand(consulta, dbConexion);

            MySqlDataReader lectura;

            try
            {
                dbConexion.Open(); // Se abre la conexion

                lectura = cmdDB.ExecuteReader(); // Se ejecuta la consulta
                Console.WriteLine("Usuario eliminado exitosamente");

                dbConexion.Close(); // Se cierra la conexion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            mostrarUsuarios(dbConexion);
        }
    }
}
