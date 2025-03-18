using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias");
            Console.WriteLine("---------------");
            List();
            Console.ReadKey();
            MenuCategoryScrenn.Load();
        }

        private static void List()
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                var categories = repository.Get();
                foreach(var item in categories)
                    Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel listar as categorias!!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}