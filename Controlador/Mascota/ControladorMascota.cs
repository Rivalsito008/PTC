using Proyecto.Modelo.DAO;
using Proyecto.Vista.AgregarMascotas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Controlador.Mascota
{
    public class ControladorMascota
    {
        FrmVistaAgregarMascota ObjVistaMascota;
        public ControladorMascota(FrmVistaAgregarMascota Vista) 
        {
            ObjVistaMascota = Vista;

            Vista.Load += new EventHandler(CargaInicial);
            Vista.btnAgregar.Click += new EventHandler(AbrirFormularioAgregar);
            Vista.btnActualizar.Click += new EventHandler(AbrirFormularioAgregar);
        }
        void CargaInicial(object sender, EventArgs e)
        {
            MostrarTabla();
        }

        void MostrarTabla()
        {
            DAOAgregarMascota daoM = new DAOAgregarMascota();
            DataSet ds = daoM.MostrarTabla();
            ObjVistaMascota.dgvMascotas.DataSource = ds.Tables["ViewAgregarMascotas"];
        }

        private void AbrirFormularioAgregar(object sender, EventArgs e)
        {
            // Crear una instancia del formulario que quieres mostrar
            FrmAgregarMascota formulario = new FrmAgregarMascota();
            formulario.ShowDialog();
        }

    }
}
