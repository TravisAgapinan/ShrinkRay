using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Services;

namespace URLShortenerTests.Services
{   
    [TestClass]
    public class UtilityServiceTests
    {
        [TestMethod]
        public void TestSlugReturnLength()
        {
           // Assert
            Assert.AreEqual(8, UtilityService.MakeSlug(8).Length);
            
        }

        [TestMethod]
        public void TestSlugNotNull()
        {
            // Assert
            Assert.IsNotNull(UtilityService.MakeSlug(8));
        }

        
    }
}
