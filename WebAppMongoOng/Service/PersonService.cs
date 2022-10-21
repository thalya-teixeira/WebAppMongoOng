using System.Collections.Generic;
using MongoDB.Driver;
using WebAppMongoOng.Models;
using WebAppMongoOng.Utils;

namespace WebAppMongoOng.Service
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _person;

        public PersonService(IDatabaseSettings settings)
        {
            var person = new MongoClient(settings.ConnectionString);
            var database = person.GetDatabase(settings.DatabaseName);
            _person = database.GetCollection<Person>(settings.PersonCollectionName);
        }

        #region Insert Person
        public Person Create(Person person)
        {
            _person.InsertOne(person);
            return person;
        }
        #endregion

        #region Busca lista todas pessoas
        public List<Person> GetAll() => _person.Find<Person>(person => true).ToList();
        #endregion

        #region Busca pelo id 
        public Person Get(string id) => _person.Find<Person>(person => person.Id == id).FirstOrDefault();
        #endregion

        #region Busca pelo nome
        public List<Person> GetByName(string name) => _person.Find<Person>(person => person.Name == name).ToList();
        #endregion

        #region Busca Animal
        public Person GetByAnimal(string id) => _person.Find(person => person.Animal.Id == id).FirstOrDefault();
        #endregion

        #region Updat Person
        public void Update(string id, Person personIn) => _person.ReplaceOne(person => person.Id == id, personIn);
        #endregion

        #region Delete Person
        public void Remove(Person personIn) => _person.DeleteOne(person => person.Id == personIn.Id);
        #endregion
    }
}
