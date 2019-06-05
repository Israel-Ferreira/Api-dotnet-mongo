using MinhaApi.Services.Config;
using MinhaApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MinhaApi.Services
{
    public class MusicService : IService<Music>
    {
        private readonly IMongoCollection<Music> _music;

        public MusicService(IConfiguration config)
        {
            var database = new ConnectDatabase<Music>(config.GetConnectionString("MusicDB"),"Musics","Music");
            _music = database.GetConn();
        }

        public Music Create(Music entity)
        {
            _music.InsertOne(entity);
            return entity;
        }

        public List<Music> Get()
        {
            return _music.Find(music => true).ToList();
        }

        public Music Get(string id)
        {
            return _music.Find<Music>(music => music._id.Equals(id)).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _music.DeleteOne(music =>  music._id.Equals(id));
        }

        public void Update(string id, Music entity)
        {
            _music.ReplaceOne(music => music._id.Equals(id),entity);
        }
    }
}