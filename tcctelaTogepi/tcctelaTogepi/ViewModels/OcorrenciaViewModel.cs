using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tcctelaTogepi.Models;

namespace tcctelaTogepi.ViewModels
{
    public class OcorrenciaViewModel
    {
        OcorrenciaRepository repository;

        public OcorrenciaViewModel()
        {
            repository = new OcorrenciaRepository();
        }

        public async Task<bool> insertBD(string problema, string desc, double lat, double lon) // double lat, double long
        {
            OcorrenciaModel ocorrencia = new OcorrenciaModel();
            ocorrencia.latitude = lat; // lat
            ocorrencia.longitude = lon; // long
            ocorrencia.tipoProblema = problema;
            ocorrencia.descricao = desc;

            var isSaved = await repository.SaveOcorrencia(ocorrencia);
            return isSaved;
        }
    }
}
