using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;

namespace OptixTechTestUnitTests.DealerServiceTests
{
    [TestClass]
    public class DealerServiceTests : DealerServiceTestBase
    {
        [TestMethod]
        public void DealerService_NewDeckContainsExpectedDeckSize()
        {
            var deck = _concreteDealerService.NewDeck();

            deck.Cards.Should().HaveCount(52);
        }
    }
}
