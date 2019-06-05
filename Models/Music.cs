using MongoDB.Bson;

namespace MinhaApi.Models
{
    public class Music {
        public ObjectId _id;
        public string NomeMusica{get; set;}
        public string Artista {get; set;}

        public string Duracao {get; set;}

        public int Ano {get; set;}
    }
}