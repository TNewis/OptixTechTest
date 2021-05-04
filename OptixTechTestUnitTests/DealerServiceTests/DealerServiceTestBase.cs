using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OptixTechTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OptixTechTestUnitTests.DealerServiceTests
{
    [TestClass]
    public class DealerServiceTestBase
    {
        internal DealerService _concreteDealerService;

        [TestInitialize]
        public void Initialise()
        {
            _concreteDealerService = new DealerService();
        }
    }
}
