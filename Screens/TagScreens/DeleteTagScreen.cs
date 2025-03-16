using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma tags");
            Console.WriteLine("---------------");
            Console.Write("Qual o id da Tag que deseja excluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Delete(int id)
        {
            try 
            {
                var reposity = new Repository<Tag>(Database.Connection);
                reposity.Delete(id);
                Console.WriteLine("Tag excluida com sucesso!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possícel excluir a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}