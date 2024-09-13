using Proyecto.Modelo.DAO;
using Proyecto.Vista.AgregarMascotas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Proyecto.Controlador.Mascota
{
    public class ContoladorAgregarMascota
    {
        FrmAgregarMascota ObjAgregarMascota;
        public ContoladorAgregarMascota(FrmAgregarMascota Vista)
        {
            ObjAgregarMascota = Vista;

            Vista.Load += new EventHandler(CargaInicial);
            //Botones
            Vista.btnIngresar.Click += new EventHandler(IngresarMascota);
            Vista.btnActualizar.Click += new EventHandler(ActualizarMascota);
            Vista.btnReiniciar.Click += new EventHandler(ReiniciarCampos);
        }

        void CargaInicial(object sender, EventArgs e)
        {
            LlenarComboCliente();
            LlenarComboRaza();
        }

        void LlenarComboCliente()
        {
            //Creando un objeto de la clase ProductsViewDAO
            DAOAgregarMascota daoSupplier = new DAOAgregarMascota();
            DataSet ds = daoSupplier.obtenerCliente();
            ObjAgregarMascota.cmbCliente.DataSource = ds.Tables["Suppliers"];
            ObjAgregarMascota.cmbCliente.DisplayMember = "Nombre";
            ObjAgregarMascota.cmbCliente.ValueMember = "IdCliente";
        }

        void LlenarComboRaza()
        {
            //Creando un objeto de la clase ProductsViewDAO
            DAOAgregarMascota daoSupplier = new DAOAgregarMascota();
            DataSet ds = daoSupplier.obtenerRaza();
            ObjAgregarMascota.cmbCliente.DataSource = ds.Tables["Suppliers"];
            ObjAgregarMascota.cmbCliente.DisplayMember = "RazaMascota";
            ObjAgregarMascota.cmbCliente.ValueMember = "IdRaza";
        }
        void IngresarMascota(object sender, EventArgs e)
        {
            // Validamos que ninguno de los campos esté vacío o inválido
            if (string.IsNullOrEmpty(ObjAgregarMascota.txtNombreMascota.Text.Trim()) ||
                ObjAgregarMascota.cmbCliente.SelectedIndex == -1 ||
                string.IsNullOrEmpty(ObjAgregarMascota.txtPeso.Text.Trim()) ||
                !decimal.TryParse(ObjAgregarMascota.txtPeso.Text.Trim(), out decimal peso) || peso <= 0 ||
                string.IsNullOrEmpty(ObjAgregarMascota.txtGenero.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAgregarMascota.txtNombreDueño.Text.Trim()) ||
                ObjAgregarMascota.cmbRaza.SelectedIndex == -1)
            {
                MessageBox.Show("Datos faltantes o incorrectos, complete el formulario con la información requerida", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se crea un objeto de tipo DAOAgregarMascota
            DAOAgregarMascota daoMascota = new DAOAgregarMascota();

            // Se mandan los valores de la vista hacia el DTO de la mascota
            daoMascota.NombreMascota = ObjAgregarMascota.txtNombreMascota.Text.Trim();
            daoMascota.IdCliente = Convert.ToInt32(ObjAgregarMascota.cmbCliente.SelectedValue);
            daoMascota.IdRaza = Convert.ToInt32(ObjAgregarMascota.cmbRaza.SelectedValue);
            daoMascota.Peso = peso; // Se usa el valor ya validado del peso
            daoMascota.Genero = ObjAgregarMascota.txtGenero.Text.Trim();
            daoMascota.Dueño = ObjAgregarMascota.txtNombreDueño.Text.Trim();

            // Registrar mascota en la base de datos
            int resultado = daoMascota.RegistrarMascota();
            if (resultado == 1)
            {
                MessageBox.Show("La mascota fue registrada exitosamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ObjAgregarMascota.Close();
            }
            else
            {
                MessageBox.Show("La mascota no pudo ser registrada", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        void ActualizarMascota(object sender, EventArgs e)
        {
            // Se crea un objeto de tipo DAOAgregarMascota (o el DAO correspondiente a la actualización de mascotas)
            DAOAgregarMascota daoUpdate = new DAOAgregarMascota();

            // Asignación de los valores de los controles al DAO
            daoUpdate.NombreMascota = ObjAgregarMascota.txtNombreMascota.Text.Trim();
            daoUpdate.IdCliente = int.Parse(ObjAgregarMascota.cmbCliente.SelectedValue.ToString());
            daoUpdate.Peso = decimal.Parse(ObjAgregarMascota.txtPeso.Text.Trim());
            daoUpdate.Genero = ObjAgregarMascota.txtGenero.Text.Trim();
            daoUpdate.Dueño = ObjAgregarMascota.txtNombreDueño.Text.Trim();
            daoUpdate.IdRaza = int.Parse(ObjAgregarMascota.cmbRaza.SelectedValue.ToString());

            // Llamada al método de actualización en la base de datos
            int retorno = daoUpdate.ActualizarMascota();
            if (retorno == 1)
            {
                // Mostrar mensaje de éxito
                MessageBox.Show("La mascota seleccionada fue actualizada", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reiniciar los campos
                ReiniciarCampos(sender, e);
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("La mascota seleccionada no pudo ser actualizada", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReiniciarCampos(object sender, EventArgs e)
        {
            // Limpiar los TextBox
            ObjAgregarMascota.txtNombreMascota.Text = string.Empty; // Limpiar el campo Nombre de la Mascota
            ObjAgregarMascota.cmbCliente.SelectedIndex = -1;       // Restablecer el ComboBox Cliente (no seleccionar ninguno)
            ObjAgregarMascota.txtPeso.Text = string.Empty;         // Limpiar el campo Peso
            ObjAgregarMascota.txtGenero.Text = string.Empty;        // Restablecer el ComboBox Género (no seleccionar ninguno)
            ObjAgregarMascota.txtNombreDueño.Text = string.Empty;  // Limpiar el campo Nombre del Dueño
            ObjAgregarMascota.cmbRaza.SelectedIndex = -1;          // Restablecer el ComboBox Raza (no seleccionar ninguno)
        }

    }
}
