using System;
using System.Threading.Tasks;


namespace PhotoAlbum
{
    class Program
    {
        static async Task Main(String[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter album id: ");
                    
                    var album = await AlbumController.FetchAlbum(Console.ReadLine());

                    foreach (var photo in album)
                    {
                        Console.WriteLine($"[{photo.Id}] {photo.Title}");
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"{e.Message} Please enter numbers only");
                }
            }
        }
    }
}
