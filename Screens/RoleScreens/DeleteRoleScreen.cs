using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma role");
            Console.WriteLine("---------------");
            Console.Write("Qual o id da role que deseja excluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Role deletado com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possicel deletar o role!!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}