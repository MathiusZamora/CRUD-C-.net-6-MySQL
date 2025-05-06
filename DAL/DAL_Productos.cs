using EL;
using System.IO.Pipes;

namespace DAL
{
    public static class DAL_Productos
    {
        public static Productos Insert(Productos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                // Validar si el proveedor existe antes de insertar
                if (!bd.Proveedores.Any(p => p.IdProveedor == Entidad.IdProveedor))
                    throw new Exception("El proveedor especificado no existe.");

                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Productos.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }

        public static bool Update(Productos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                var Registro = bd.Productos.Find(Entidad.IdProducto);

                if (Registro == null)
                    throw new Exception("Producto no encontrado.");

                // Validar si el proveedor existe antes de actualizar
                if (!bd.Proveedores.Any(p => p.IdProveedor == Entidad.IdProveedor))
                    throw new Exception("El proveedor especificado no existe.");

                Registro.Descripcion = Entidad.Descripcion;
                Registro.Cantidad = Entidad.Cantidad;
                Registro.IdProveedor = Entidad.IdProveedor; // Actualizar el proveedor
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = Entidad.FechaActualizacion;

                return bd.SaveChanges() > 0;
            }
        }

        public static bool Anular(Productos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                var Registro = bd.Productos.Find(Entidad.IdProducto);

                if (Registro == null)
                    throw new Exception("Producto no encontrado.");

                Registro.Activo = false;
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }

        public static bool Existe(Productos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                return bd.Productos.Any(a => a.IdProducto == Entidad.IdProducto);
            }
        }

        public static Productos Registro(Productos Entidad)
        {
            using (BDInventario bd = new BDInventario())
            {
                return bd.Productos.SingleOrDefault(a => a.IdProducto == Entidad.IdProducto);
            }
        }

        // Método solo para obtener la lista de productos con los proveedores
        public static List<ProductosConProveedor> Lista(bool Activo = true)
        {
            using (BDInventario bd = new BDInventario())
            {
                // Consulta que obtiene productos con los datos de proveedor
                return (from p in bd.Productos
                        join prov in bd.Proveedores on p.IdProveedor equals prov.IdProveedor
                        where p.Activo == Activo
                        select new ProductosConProveedor
                        {
                            IdProducto = p.IdProducto,
                            Descripcion = p.Descripcion,
                            Cantidad = p.Cantidad,
                            IdProveedor = prov.IdProveedor,  // ID del proveedor
                            NombreProveedor = prov.NombreProveedor  // Nombre del proveedor
                        }).ToList();
            }
        }



        public static bool ValidarDescripcionProduct(string Descripcion, int IdRegistro)
        {
            using (BDInventario bd = new())
            {
                return bd.Productos.Any(a => a.Descripcion == Descripcion && a.IdProducto != IdRegistro && a.Activo == true);
            }
        }

        public static bool ValidarCantidadProduct(string Cantidad, int IdRegistro)
        {
            using (BDInventario bd = new())
            {
                return bd.Productos.Any(a => a.Cantidad == Cantidad && a.IdProducto != IdRegistro && a.Activo == true);
            }
        }
    }
}
