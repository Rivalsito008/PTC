using Proyecto.Controlador.Mascota;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Vista.AgregarMascotas
{
    public partial class FrmVistaAgregarMascota : Form
    {
        public FrmVistaAgregarMascota()
        {
            InitializeComponent();
            ControladorMascota controladorMascota = new ControladorMascota(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
