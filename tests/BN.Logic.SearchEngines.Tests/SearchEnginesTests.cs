using BN.Logic.Interfaces;
using BN.Logic.SearchEngines.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BN.Logic.SearchEngines.Tests
{
    [TestClass]
    public class SearchEnginesTests
    {
        [TestMethod]
        public async Task CanFindSimplePath()
        {
            var builder = new ResortInfoBuiler();
            var resortInfo = builder.ParseABNRelation("A - B - C").Build();



            var provider = new Mock<IResortInfrastructureProvider>();
            provider.Setup(x => x.GetResortInfrastructure(It.IsAny<CancellationToken>()))
                .ReturnsAsync(resortInfo);

            var engine = new QuickGraphSearchEngine.PathFinder(provider.Object);

            await engine.Initialize();

            var result = await engine.FindShortestPath("A", "C");

            Assert.IsTrue(result.IsPathFound);
            Assert.IsTrue(result.Path.Count() == 3);
        }
    }
}
