using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LiteDB;
using SnapGas.Models;
using System.Reflection;

namespace SnapGas.Services
{
    public class LiteDBDataStore : IDisposable
    {
        public string DatabasePath { get; private set; }

        public LiteRepository Database { get; set; }

        private BsonMapper _mapper { get; set; }

        private Dictionary<Type, string> _collectionNames { get; set; } = new Dictionary<Type, string>();

        public LiteQueryable<Car> Cars
        {
            get => this.Get<Car>();
            set => this.Save(value);
        }

        public LiteQueryable<FuelingInstance> FuelingInstances
        {
            get => this.Get<FuelingInstance>();
            set => this.Save(value);
        }

        public LiteQueryable<EfficiencyReport> EfficiencyReports
        {
            get => this.Get<EfficiencyReport>();
            set => this.Save(value);
        }

        public LiteDBDataStore()
        {
            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal).ToLower();
            var fileName = "snapgas.db";
            this.DatabasePath = Path.Combine(dbFolder, fileName);
            this.Database = new LiteRepository(new LiteDatabase(this.DatabasePath, this._mapper));
        }

        public void ClearDB()
        {
            var collectionNames = this.Database.Database.GetCollectionNames().ToList();

            foreach (var collectionName in collectionNames)
            {
                this.Database.Database.DropCollection(collectionName);
            }
        }

        public void FullResync()
        {
            var collections = this.Database.Database.GetCollectionNames();

            foreach (var collection in collections)
            {

            }
        }

        public string GetCollectionName<TEntity>()
        {
            string collectionName = null;

            if (!this._collectionNames.TryGetValue(typeof(TEntity), out collectionName))
            {
                Type t = typeof(TEntity);
                var collectionAttribute = t.GetCustomAttributes<CollectionAttribute>().FirstOrDefault();

                if (collectionAttribute != null)
                {
                    collectionName = collectionAttribute.CollectonName;
                }

                var add = false;
                if (collectionName != null && !this._collectionNames.Any(c => c.Value == collectionName))
                {
                    add = true;
                }
                if (add)
                {
                    this._collectionNames.Add(t, collectionName);
                }
            }

            if (collectionName == null)
            {
                throw new Exception("Collection name not found");
            }

            return collectionName;
        }

        public Type GetBaseType<TEntity>()
        {
            var baseTypeAttribute = typeof(TEntity).GetCustomAttributes<BaseTypeAttribute>().FirstOrDefault();
            return baseTypeAttribute?.BaseType;
        }

        public LiteQueryable<TEntity> Get<TEntity>(string collectionName = null)
        {
            var collName = collectionName ?? GetCollectionName<TEntity>();

            return this.Database.Query<TEntity>(collName);
        }

        public void Save<TEntity>(TEntity item, string collectionName = null, bool dataSync = true) where TEntity : class
        {
                var collName = collectionName ?? this.GetCollectionName<TEntity>();
                var coll = this.Database.Database.GetCollection<TEntity>(collName);
                coll.Upsert(item);
        }

        public void Dispose()
        {
            this.Database.Dispose();
        }  
    }
}
