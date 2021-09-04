using System.Collections.Generic;
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
        [DataTestMethod]
        [DataRow(new string [] {"A-B-C"}, "A", "C", "A-B-C", DisplayName = "ABC")]
        [DataRow(new string [] {"A-B", "B-C"}, "A", "C", "A-B-C", DisplayName = "ABC different syntax")]
        public async Task QuickGraphPathFinder_ShouldFindShortestPath(string[] relations, string from, string to, string expectedPath)
        {
            var builder = new ResortInfoBuilder();
            foreach (var relation in relations)
            {
                builder = builder.ParseABNRelation(relation);
            }

            var resortInfo = builder.Build();

            var provider = new Mock<IResortInfrastructureProvider>();
            provider.Setup(x => x.GetResortInfrastructure(It.IsAny<CancellationToken>()))
                .ReturnsAsync(resortInfo);

            var engine = new QuickGraphSearchEngine.PathFinder(provider.Object);

            await engine.Initialize();

            var result = await engine.FindShortestPath("A", "C");

            Assert.AreEqual(expectedPath, result.ToStringPath());
        }
    }
}
