using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de roles");
            Console.WriteLine("---------------");
            List();
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void List()
        {
            try
            {
                var repositoy = new Repository<Role>(Database.Connection);
                var roles = repositoy.Get();
                foreach(var item in roles)
                    Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possivel listar os roles!!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}