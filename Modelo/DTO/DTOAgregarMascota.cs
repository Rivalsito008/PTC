using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelo.DTO
{
    public class DTOAgregarMascota : dbConexion
    {
        private int idMascota;
        private int idCliente;
        private int idRaza;
        private string nombreMascota;
        private decimal peso;
        private string genero;
        private string dueño;

        public int IdMascota { get => idMascota; set => idMascota = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdRaza { get => idRaza; set => idRaza = value; }
        public string NombreMascota { get => nombreMascota; set => nombreMascota = value; }
        public decimal Peso { get => peso; set => peso = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Dueño { get => dueño; set => dueño = value; }
    }

}
