namespace EL
{
    public class ProductosConProveedor
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; } // Este es el nombre del proveedor
    }
}
