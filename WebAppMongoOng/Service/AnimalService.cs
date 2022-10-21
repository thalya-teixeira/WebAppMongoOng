using System.Collections.Generic;
using MongoDB.Driver;
using WebAppMongoOng.Models;
using WebAppMongoOng.Utils;

namespace WebAppMongoOng.Service
{
    public class AnimalService
    {
        private readonly IMongoCollection<Animal> _animal;

        public AnimalService(IDatabaseSettings settings)
        {
            var animal = new MongoClient(settings.ConnectionString);
            var database = animal.GetDatabase(settings.DatabaseName);
            _animal = database.GetCollection<Animal>(settings.AnimalCollectionName);
        }

        #region Insert Animal
        public Animal Create(Animal animal)
        {
            _animal.InsertOne(animal);
            return animal;
        }
        #endregion

        #region Busca lista todas animal
        public List<Animal> GetAll() => _animal.Find<Animal>(animal => true).ToList();
        #endregion

        #region Busca pelo id 
        public Animal Get(string id) => _animal.Find<Animal>(animal => animal.Id == id).FirstOrDefault();
        #endregion

        #region Busca pelo nome
        public List<Animal> GetByName(string n) => _animal.Find<Animal>(animal => animal.Name == n).ToList();
        #endregion

        #region Updat Animal
        public void Update(string id, Animal animalIn) => _animal.ReplaceOne(animal => animal.Id == id, animalIn);
        #endregion

        #region Delete Animal
        public void Remove(Animal animalIn) => _animal.DeleteOne(animal => animal.Id == animalIn.Id);
        #endregion
    }
}
