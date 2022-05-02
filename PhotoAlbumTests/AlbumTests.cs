using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PhotoAlbumTests
{
    [TestClass]
    public class AlbumTests
    {
        [TestMethod]
        public void TestInvalidInput()
        {
            string testString = "a";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(testString);
            Console.SetIn(stringReader);

            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await AlbumController.FetchAlbum(Console.ReadLine()));
        }

        [TestMethod]
        public void TestArgumentOutOfRangeMin()
        {
            string testString = "-1";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(testString);
            Console.SetIn(stringReader);

            Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await AlbumController.FetchAlbum(Console.ReadLine()));
        }

        [TestMethod]
        public async Task TestRetrieveFirstPhotoId()
        {
            string albumId = "1";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(albumId);
            Console.SetIn(stringReader);

            var album = await AlbumController.FetchAlbum(Console.ReadLine());

            Assert.AreEqual(1, album[0].Id);
        }

        [TestMethod]
        public async Task TestRetrieveFirstPhotoTitle()
        {
            string albumId = "1";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(albumId);
            Console.SetIn(stringReader);

            var album = await AlbumController.FetchAlbum(Console.ReadLine());

            Assert.AreEqual("accusamus beatae ad facilis cum similique qui sunt", album[0].Title);
        }

        [TestMethod]
        public async Task TestRetrieveFirstPhotoUrl()
        {
            string albumId = "1";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(albumId);
            Console.SetIn(stringReader);

            var album = await AlbumController.FetchAlbum(Console.ReadLine());

            Assert.AreEqual(@"https://via.placeholder.com/600/92c952", album[0].Url);
        }

        [TestMethod]
        public async Task TestRetrieveFirstPhotoThumbnailUrl()
        {
            string albumId = "1";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(albumId);
            Console.SetIn(stringReader);

            var album = await AlbumController.FetchAlbum(Console.ReadLine());

            Assert.AreEqual(@"https://via.placeholder.com/150/92c952", album[0].ThumbnailUrl);
        }
    }
}
