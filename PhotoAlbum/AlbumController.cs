using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhotoAlbum
{

    /// <summary>
    /// Class for retrieving an album
    /// </summary>
    public class AlbumController
    {
        private static readonly HttpClient client = new HttpClient();


        /// <summary>
        /// Asyncronously retrieves all photos with given album id
        /// </summary>
        /// <param name="albumId">Id of album</param>
        /// <returns>List containing all photos with the given album id</returns>
        public static async Task<List<Photo>> FetchAlbum(string albumId)
        {
            if (!int.TryParse(albumId, out int input))
                throw new ArgumentException();

            if (input < 0)
                throw new ArgumentOutOfRangeException();

            var streamTask = client.GetStreamAsync($@"https://jsonplaceholder.typicode.com/photos?albumId={albumId}");
            var photos = await JsonSerializer.DeserializeAsync<List<Photo>>(await streamTask);

            return photos;
        }
    }
}
