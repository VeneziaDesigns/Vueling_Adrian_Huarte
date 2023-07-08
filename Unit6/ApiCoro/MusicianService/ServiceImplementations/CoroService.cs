using System.Collections.Generic;
using System.Linq;
using MusicianDomain.DomainEntities;
using MusicianDomain.RepositoryContracts;
using MusicianRepository.DataModels;
using MusicianService.ServiceContracts;
using MusiciansManagement.DTOs;

namespace MusicianService.ServiceImplementations
{
    public class CoroService : ICoroService
    {
        private readonly IConciertoRepository _conciertoRepository;
        private readonly IMusicosRepository _musicosRepository;
        private readonly IDiasOcupadosRepository _diasOcupadosRepository;
        private readonly ICacheRepository _cacheRepository;

        public CoroService(IConciertoRepository conciertoRepository, IMusicosRepository musicosRepository, 
                            IDiasOcupadosRepository diasOcupadosRepository, ICacheRepository cacheRepository)
        {
            _conciertoRepository = conciertoRepository;
            _musicosRepository = musicosRepository;
            _diasOcupadosRepository = diasOcupadosRepository;
            _cacheRepository = cacheRepository;
        }

        public List<MusicianDTO> GetConcert(string date)
        {
            List<Musicos>? cacheMusicians = _cacheRepository.GetCache();

            //todo if (cacheMusicians is not null) return cacheMusicians;

            List<Musicos>? musicians = _musicosRepository.GetMusicians();
            _cacheRepository.SetCache(musicians);

            List<Musicos>? availableMusicians = _diasOcupadosRepository.GetFreeDays(musicians, date);
            List<MusicianNeedForMeetingInfo>? requiredMusicians = _conciertoRepository.GetTypes();

            List<Musicos>? musiciansOrderByCountRole = MusiciansOrderByCountRole(availableMusicians);
            List<MusicianDTO> musiciansToConcert = AssignMusiciansToConcert(requiredMusicians, musiciansOrderByCountRole);

            return musiciansToConcert;
        }

        private static List<Musicos>? MusiciansOrderByCountRole(List<Musicos>? availableMusicians)
        {
            List<Musicos>? result = availableMusicians?.OrderBy(m => m.Categorias.Count()).ToList();

            return result;
        }

        private static List<MusicianDTO> AssignMusiciansToConcert(List<MusicianNeedForMeetingInfo>? requiredMusicians, 
                                                                    List<Musicos>? musiciansOrderByCountRole)
        {
            List<MusicianDTO>? musiciansToConcert = new();

            foreach (MusicianNeedForMeetingInfo? role in requiredMusicians)
            {
                int count = 0;

                foreach (Musicos? musician in musiciansOrderByCountRole)
                {
                    if (musician.Categorias?.Contains(role.Role) == true)
                    {
                        musiciansToConcert.Add(new MusicianDTO
                        {
                            Name = musician.Nombre,
                            Role = role.Role
                        });

                        count++; // Incrementar el contador de músicos asignados al rol requerido

                        if (count >= role.Amount)
                        {
                            break; // Se ha asignado el número necesario de músicos para el rol requerido
                        }
                    }
                }
            }

            return musiciansToConcert;
        }
    }
}
