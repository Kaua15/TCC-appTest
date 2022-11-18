using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcctelaTogepi.Models;

namespace tcctelaTogepi
{
    public class OcorrenciaRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://realtimedatabase-66971-default-rtdb.firebaseio.com/");

        public async Task<bool> SaveOcorrencia(OcorrenciaModel ocorrencia)
        {
            var data = await firebaseClient.Child(nameof(OcorrenciaModel)).PostAsync(JsonConvert.SerializeObject(ocorrencia));
            if(!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<OcorrenciaModel>>GetAll()
        {
            return (await firebaseClient.Child(nameof(OcorrenciaModel)).OnceAsync<OcorrenciaModel>()).Select(item => new OcorrenciaModel
            {
                tipoProblema = item.Object.tipoProblema,
                descricao = item.Object.descricao,
                latitude = item.Object.latitude,
                longitude = item.Object.longitude,
                Id = item.Key
            }).ToList();
        }
    }
}
