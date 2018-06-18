using Carmelo.Word.Core.DataModels;
using Carmelo.Word.Pages;
using Carmelo.Word.ValueConverters;
using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace Carmelo.Word.UnitTests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class ApplicationPageValueConverterUnitTest
    {
        [Test]
        public void Convert_LoginConvert_ReturnsLogin()
        {
            var converter = new ApplicationPageValueConverter();

            LoginPage actual = (LoginPage)converter.Convert(ApplicationPage.Login, null, null, new CultureInfo("en-US", false));

            Assert.IsTrue(actual.GetType() == typeof(LoginPage));
        }
    }
}
