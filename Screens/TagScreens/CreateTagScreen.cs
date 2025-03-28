using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova tags");
            Console.WriteLine("---------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Tag{
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Create(Tag tag)
        {
            try 
            {
                var reposity = new Repository<Tag>(Database.Connection);
                reposity.Create(tag);
                Console.WriteLine("Tag cadastrada com sucesso!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possícel salvar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}