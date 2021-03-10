using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
  public  class Orden
    {
        public int Id { get; set; }
        public int BeneficiarioId { get; set; }
        public Beneficiario Beneficiario { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        public List<OrdenDetalle> ListadeOrdenDetalle { get; set; }
        public bool Activo { get; private set; }

        public Orden()
        {
            Activo = true;


            Fecha = DateTime.Now;
        }
    }

    public class OrdenDetalle
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }

        public int DesaparecidoId { get; set; }
        public Desaparecido Desaparecido { get; set; }

        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }
    }
}
