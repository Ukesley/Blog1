using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
             Console.Clear();
            Console.WriteLine("Excluir um usuário");
            Console.WriteLine("---------------");
            Console.Write("Qual o id do usuário que deseja excluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário excluido com sucesso!! ");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possivel excluir o usuário!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}