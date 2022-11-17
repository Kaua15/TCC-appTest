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

        public async Task<bool> insertBD(string problema, string desc) // double lat, double long
        {
            OcorrenciaModel ocorrencia = new OcorrenciaModel();
            ocorrencia.MyProperty = "test";
            ocorrencia.latitude = 1; // lat
            ocorrencia.longitude = 1; // long
            ocorrencia.tipoProblema = problema;
            ocorrencia.descricao = desc;

            var isSaved = await repository.SaveOcorrencia(ocorrencia);
            return isSaved;
        }
    }
}
