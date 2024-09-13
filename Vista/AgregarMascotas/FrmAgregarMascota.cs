
using Proyecto.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Modelo.DAO;
using Proyecto.Controlador.Mascota;

namespace Proyecto.Vista.AgregarMascotas
{
    public partial class FrmAgregarMascota : Form
    {
        public FrmAgregarMascota()
        {
            InitializeComponent();
            ContoladorAgregarMascota controladorAgregarMascota = new ContoladorAgregarMascota(this);
        }

    }
}
