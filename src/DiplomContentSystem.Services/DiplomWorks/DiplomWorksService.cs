using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
namespace DiplomContentSystem.Services.DiplomWorks
{
    public class DiplomWorksService
    {
        private readonly IRepository<DiplomWork> _repository;
        public DiplomWorksService(IRepository<DiplomWork> repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            else
                _repository = repository;
        }

        public Dto.ListResponse<DiplomWorkListItem> GetDiplomWorks(DiplomWorkRequest request)
        {
            var queryBuilder = new DiplomWorksQueryBuilder();
            var response = new ListResponse<DiplomWorkListItem>();
            string[] includes = { "Teacher", "Students" };

            var query = queryBuilder.UseDto(request)
                                    .UsePaging()
                                    .UseFilters()
                                    .UseSortings(defaultSorting: "id")
                                    .Build();

            response.TotalCount = _repository.Count(query.FilterExpression);
            response.Items = _repository.Get(query, includes).Select(x =>
            {
                return new DiplomWorkListItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                    TeacherId = x.TeacherId,
                    Teacher = x.Teacher.FIO
                };
            });
            return response;
        }

        public DiplomWork Get(int id)
        {
            return _repository.Get(id);
        }

        public bool AddDiplomWork(DiplomWork DiplomWork)
        {
            var dbDiplomWork = new DiplomWork();
            //dbDiplomWork.FIO = DiplomWork.FIO;
            //dbDiplomWork.PositionId = DiplomWork.PositionId;
            //dbDiplomWork.MaxWorkCount = DiplomWork.MaxWorkCount;
            //dbDiplomWork.SpecialityId = 1;
            _repository.Add(dbDiplomWork);
            _repository.SaveChanges();
            return true;
        }

        public bool UpdateDiplomWork(DiplomWork DiplomWork)
        {
            var dbDiplomWork = new DiplomWork();
            dbDiplomWork.Id = DiplomWork.Id;
           // dbDiplomWork.FIO = DiplomWork.FIO;
          //  dbDiplomWork.PositionId = DiplomWork.PositionId;
          //  dbDiplomWork.MaxWorkCount = DiplomWork.MaxWorkCount;
          //  dbDiplomWork.SpecialityId = 1;
            _repository.Update(dbDiplomWork);
            _repository.SaveChanges();
            return true;
        }
    }
}
