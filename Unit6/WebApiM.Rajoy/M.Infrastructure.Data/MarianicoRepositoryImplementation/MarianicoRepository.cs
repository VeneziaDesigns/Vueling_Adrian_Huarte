using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using M.Domain.DomainEntities;
using M.Domain.RepositoryContracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace M.Infrastructure.Data.MarianicoRepositoryImplementation
{
    public class MarianicoRepository : IMarianicoRepository
    {
        private readonly string? _marianicoFilePath;

        public MarianicoRepository(IConfiguration configuration)
        {
            _marianicoFilePath = configuration.GetSection("MySettings:MarianicoFilePath").Value;
        }

        public List<Frase> GetAllFrases()
        {
            string? json = File.ReadAllText(_marianicoFilePath);
            return JsonConvert.DeserializeObject<List<Frase>>(json);
        }

        public List<Frase>? GetFraseByDate(string fecha)
        {
            List<Frase>? filtroPorFecha = new();

            string? json = File.ReadAllText(_marianicoFilePath);
            List<Frase>? todasLasFrases = JsonConvert.DeserializeObject<List<Frase>?>(json);

            filtroPorFecha.AddRange(todasLasFrases.Where(f => f.Date.Equals(fecha)));

            return filtroPorFecha;
        }

        public Frase GetFraseById(int id)
        {
            Frase? filtroPorId = new();

            string? json = File.ReadAllText(_marianicoFilePath);
            List<Frase>? todasLasFrases = JsonConvert.DeserializeObject<List<Frase>?>(json);

            filtroPorId = todasLasFrases?.FirstOrDefault(f => f.Id.Equals(id));

            if (filtroPorId == null) return null;
            return filtroPorId;
        }

        public int AddFrase(Frase frase)
        {
            List<Frase>? frases = GetAllFrases();
            frase.Id = GetNextId(frases);
            frases.Add(frase);
            SaveFrases(frases);
            return frase.Id;
        }

        private void SaveFrases(List<Frase> frases)
        {
            var json = JsonSerializer.Serialize(frases, new JsonSerializerOptions { WriteIndented = true });

            using (StreamWriter writer = new(_marianicoFilePath, false, Encoding.UTF8))
            {
                writer.Write(json);
            }

            File.WriteAllText(_marianicoFilePath, json);
        }

        private int GetNextId(List<Frase> frases)
        {
            return frases.Any() ? frases.Max(f => f.Id) + 1 : 1;
        }
    }
}
