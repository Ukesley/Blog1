using Blog.Models;
using Blog.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo role");
            Console.WriteLine("---------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Role{
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Create(role);
                Console.WriteLine("Role criado com sucesso!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possivel criar um role!!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}