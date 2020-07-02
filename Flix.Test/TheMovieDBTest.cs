using Flix.API.Models;
using Flix.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flix.Api.UnitTest
{
    [TestClass]
    public class TheMovieDBTest

    {

        [TestMethod]
        public void TheMovieDbType()
        {

            //Arrange
            var item = new TheMoviedb();

            //Act
            var result = item.GetPopularity();

            //Assert

            Assert.IsInstanceOfType(result, typeof(Search));
            
        }

      
    }

}



