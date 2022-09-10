namespace Entidades
{
    public class EArticulo
    {
        public int Id { get; set; }
        public int IdMarca { get; set; }
        public int IdItbis { get; set; }
        public int IdSuplidor { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Referencia { get; set; }
        public int PuntoReorden { get; set; } = 0;
        public decimal Cantidad { get; set; } = 0;
        public decimal Costo { get; set; } = 0;
        public decimal Precio { get; set; } = 0;
        public decimal Beneficio { get; set; } = 0;
        public bool Estado { get; set; }
        public decimal BeneficioMinimo { get; set; } = 0;
    }
}
