using Proyecto.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Data;

namespace Proyecto.Modelo.DAO
{
    public class DAOAgregarMascota : DTOAgregarMascota
    {
        SqlCommand command = new SqlCommand();
        //Mostrar datos en el data grid view
        public DataSet MostrarTabla()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM ViewAgregarMascotas";
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                cmdSelect.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "ViewAgregarMascotas");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show($"Error al intentar mostrar datos, verifique su conexión a internet o acceso al servidor o base de datos estèn activos", "Error de ejecuciòn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }

        }

        //Llenar combobox
        public DataSet obtenerCliente()
        {
            try
            {
                // Asegúrate de que command esté inicializado correctamente
                command.Connection = getConnection();

                // Definir la instrucción SQL para obtener solo el IdCliente y Nombre
                string query = "SELECT IdCliente, Nombre FROM Propietario";

                // Crear un objeto de tipo comando con la instrucción y la conexión
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);

                // Crear un adaptador de datos y llenar el DataSet
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Propietarios");

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los propietarios: {ex.Message}", "Error de Ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                // Asegúrate de que la conexión se cierra en el bloque finally
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public DataSet obtenerRaza()
        {
            try
            {
                // Asegúrate de que command esté inicializado correctamente
                command.Connection = getConnection();

                // Definir la instrucción SQL para obtener solo IdRaza y NombreMascota
                string query = "SELECT IdRaza, RazaMascota FROM Raza";

                // Crear un objeto de tipo comando con la instrucción y la conexión
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);

                // Crear un adaptador de datos y llenar el DataSet
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Raza");

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las razas: {ex.Message}", "Error de Ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                // Asegúrate de que la conexión se cierra en el bloque finally
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        //Agregar Mascota
        public int RegistrarMascota()
        {
            try
            {
                // Establecemos una conexión
                command.Connection = getConnection();

                // Definir la consulta de inserción para la tabla Mascota
                string queryInsert = "INSERT INTO Mascota (IdCliente, IdRaza, NombreMascota, Peso, Genero, Dueño) " +
                                     "VALUES (@IdCliente, @IdRaza, @NombreMascota, @Peso, @Genero, @Dueño)";

                // Creamos el objeto SqlCommand con la consulta y la conexión
                SqlCommand cmdInsert = new SqlCommand(queryInsert, command.Connection);

                // Asignamos el valor a cada parámetro con los datos del DTO o las variables correspondientes
                cmdInsert.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmdInsert.Parameters.AddWithValue("@IdRaza", IdRaza);
                cmdInsert.Parameters.AddWithValue("@NombreMascota", NombreMascota);
                cmdInsert.Parameters.AddWithValue("@Peso", Peso);
                cmdInsert.Parameters.AddWithValue("@Genero", Genero);
                cmdInsert.Parameters.AddWithValue("@Dueño", Dueño);

                // Ejecutamos la consulta y retornamos el número de filas afectadas
                return cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Mostramos un mensaje en caso de error
                MessageBox.Show($"{ex.Message} No se pudo registrar la mascota, verifique la conexión a internet o que los servicios estén activos",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                // Cerramos la conexión
                command.Connection.Close();
            }
        }

        //Actualizar
        public int ActualizarMascota()
        {
            try
            {
                // Establecemos una conexión
                command.Connection = getConnection();

                // Definir la consulta de actualización para la tabla Mascota
                string queryUpdate = "UPDATE Mascota SET IdCliente = @IdCliente, IdRaza = @IdRaza, NombreMascota = @NombreMascota, " +
                                     "Peso = @Peso, Genero = @Genero, Dueño = @Dueño WHERE IdMascota = @IdMascota";

                // Creamos el objeto SqlCommand con la consulta y la conexión
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, command.Connection);

                // Asignamos el valor a cada parámetro con los datos del DTO o las variables correspondientes
                cmdUpdate.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmdUpdate.Parameters.AddWithValue("@IdRaza", IdRaza);
                cmdUpdate.Parameters.AddWithValue("@NombreMascota", NombreMascota);
                cmdUpdate.Parameters.AddWithValue("@Peso", Peso);
                cmdUpdate.Parameters.AddWithValue("@Genero", Genero);
                cmdUpdate.Parameters.AddWithValue("@Dueño", Dueño);
                cmdUpdate.Parameters.AddWithValue("@IdMascota", IdMascota);

                // Ejecutamos la consulta y retornamos el número de filas afectadas
                return cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Mostramos un mensaje en caso de error
                MessageBox.Show($"{ex.Message} No se pudo actualizar la información de la mascota, verifique su conexión a internet o que los servicios estén activos",
                                "Error de actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                // Cerramos la conexión
                command.Connection.Close();
            }
        }

    }
}
