using HealthClinic.Contexts;
using HealthClinic.Domains;
using Newtonsoft.Json;

namespace HealthClinic.Utils.CID
{
    public class JsonTools
    {
        private readonly IWebHostEnvironment _env;

        public JsonTools(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string ObterCaminhoDoJSON()
        {
            var jsonFileName = "cid10.json"; // Substitua pelo nome do seu arquivo JSON
            var caminhoCompleto = Path.Combine(_env.ContentRootPath, jsonFileName);

            Console.WriteLine(caminhoCompleto);
            return caminhoCompleto;
        }
    }
}
