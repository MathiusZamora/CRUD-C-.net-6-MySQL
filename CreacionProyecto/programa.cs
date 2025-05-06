using BLL;

static void main()
{
    foreach (var item in BLL_Roles.Listar())
    {

        Console.WriteLine(item.IdRol+" "+ item.Rol);
    }


}

main();