using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsynk())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpDateEvento(int eventoId, Evento model)
        {
            try
            {
                
            var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
            if (evento == null) return null;

            model.Id = evento.Id;

            _geralPersist.UpDate(model);
                if (await _geralPersist.SaveChangesAsynk())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
             try
            {
                
            var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
            if (evento == null) throw new Exception("Evento para delete não encontrado.");

            _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsynk();
                
            }
            
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {

            try
            {
                
             var evento = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
             if (evento == null) return null;

             return evento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
             try
            {
                
             var evento = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
             if (evento == null) return null;

             return evento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             try
            {
                
             var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
             if (evento == null) return null;

             return evento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}