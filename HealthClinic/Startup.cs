using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Utils.CID;
using Newtonsoft.Json;

namespace HealthClinic
{
    public class Startup
    {
        public void InserirDadosIniciais(HealthClinicContext context)
        {
            var json = File.ReadAllText("C:\\Users\\57267874800\\Desktop\\HealthClinic\\HealthClinic\\Utils\\CID\\cid10.json"); // Leia o JSON de um arquivo
            var cids = JsonConvert.DeserializeObject<List<CID>>(json);

            try
            {
                context.CIDs.AddRange(cids);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HealthClinicContext context)
        {
            InserirDadosIniciais(context);

        }
    }
}
