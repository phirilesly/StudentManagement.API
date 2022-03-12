using Common.Helper.Commons;
using Common.Helper.Commons.Enums;
using MongoDB.Driver;
using StudentManagement.Abstraction.Entities;
using StudentManagement.Abstraction.Enums;
using StudentManagement.Abstraction.Repositories;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Services;
using StudentManagement.Infrastruture.Data.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastracture.Data.Mongo
{
  public  class DegreeProgramRepository:IDegreeProgramRepository
    {
        private readonly MongoContext _context;
        public DegreeProgramRepository(MongoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IDegreeProgramEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType)
        {
            FilterDefinition<DegreeProgramEntity> filter = null;
            foreach (var parameter in searchParameters.Where(
                    parameter => !string.IsNullOrEmpty(parameter.Name) && !string.IsNullOrEmpty(parameter.Value)))
            {
                var validParameter = Enum.TryParse(parameter.Name.ToUpper(), out SearchOptions option);
                if (!validParameter)
                {
                    continue;
                }
                switch (option)
                {
                    case SearchOptions.ID:
                        if (filter == null)
                        {
                            filter = Builders<DegreeProgramEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value));
                        }
                        else
                        {
                            filter = Builders<DegreeProgramEntity>.Filter.Eq(c => c.Id, Guid.Parse(parameter.Value)) & filter;
                        }
                        break;


                }

            }
            if (filter == null) throw new ArgumentException("Invalid search parameters specified");
            List<DegreeProgramEntity> result = await _context.DegreePrograms.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IDegreeProgramEntity> LoadAggregateAsync(Guid id)
        {
            FilterDefinition<DegreeProgramEntity> filter = Builders<DegreeProgramEntity>.Filter.Ne("isDeleted", true);

            filter = Builders<DegreeProgramEntity>.Filter.Eq("_id", id) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid application search parameters specified");

            }
            var result = (await _context.DegreePrograms.FindAsync(filter)).FirstOrDefault();
            return result ?? EntityFactory.CreateDegreeProgram();
        }

        public async Task<Guid> SaveAggregateAsync(IDegreeProgramEntity aggregate)
        {
            FilterDefinition<DegreeProgramEntity> filter = Builders<DegreeProgramEntity>.Filter.Eq("_id", aggregate.Id);

            var result = await _context.DegreePrograms.FindAsync(filter);

            if (result.Any())
            {
                await _context.DegreePrograms.ReplaceOneAsync(filter, aggregate as DegreeProgramEntity);
            }
            else
            {
                await _context.DegreePrograms.InsertOneAsync(aggregate as DegreeProgramEntity);
            }
            return aggregate.Id;
        }

        public async Task<IEnumerable<IDegreeProgramEntity>> FindModelsAsync(List<SearchParameter> searchParameters)
        {
            FilterDefinition<DegreeProgramEntity> filter = Builders<DegreeProgramEntity>.Filter.Ne("isDeleted", true);
            foreach (var parameter in searchParameters.Where(
                    parameter => !string.IsNullOrEmpty(parameter.Name) && !string.IsNullOrEmpty(parameter.Value)))
            {
                var validParameter = Enum.TryParse(parameter.Name.ToUpper(), out SearchOptions option);
                if (!validParameter)
                {
                    continue;
                }


            }
            if (filter == null) throw new ArgumentException("Invalid search parameters specified");
            List<DegreeProgramEntity> result = await _context.DegreePrograms.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IDegreeProgramEntity> LoadModelAsync(Guid modelId)
        {
            var filter = Builders<DegreeProgramEntity>.Filter.Eq("_id", modelId);
            filter = Builders<DegreeProgramEntity>.Filter.Ne("isDeleted", true) & filter;
            if (filter == null)
            {
                throw new ArgumentException("Invalid  search parameters specified");
            }
            var result = await _context.DegreePrograms.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task<Guid> SaveModelAsync(IDegreeProgramEntity model)
        {
            FilterDefinition<DegreeProgramEntity> filter = Builders<DegreeProgramEntity>.Filter.Eq("_id", model.Id);

            var result = await _context.DegreePrograms.FindAsync(filter);

            if (result.Any())
            {
                await _context.DegreePrograms.ReplaceOneAsync(filter, model as DegreeProgramEntity);
            }
            else
            {
                await _context.DegreePrograms.InsertOneAsync(model as DegreeProgramEntity);
            }

            return model.Id;
        }
    }
}
