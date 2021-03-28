using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BN.Logic.Interfaces;
using BN.Models;
using Newtonsoft.Json;

namespace BN.UI.Console.App.Services
{
    public class FromFileResortInfoProvider : IResortInfrastructureProvider
    {
        private readonly string _path;

        public FromFileResortInfoProvider(string pathToResoltInfoFile)
        {
            _path = pathToResoltInfoFile;
        }

        public async Task<ResortInfrastructure> GetResortInfrastructure(CancellationToken cancellationToken = default(CancellationToken))
        {
            var content = await File.ReadAllTextAsync(_path, cancellationToken);
            var objects = JsonConvert.DeserializeObject<IList<IResortObject>>(content,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto});
            return new ResortInfrastructure {Objects = objects};
        }
    }
}