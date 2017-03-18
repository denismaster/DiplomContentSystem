using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
namespace DiplomContentSystem.Services
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

        private Expression<Func<DiplomWork, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "name": return diplomWork => diplomWork.Name;
                case "endDate": return diplomWork => diplomWork.EndDate;
                case "startDate": return diplomWork => diplomWork.StartDate;
                default: return diplomWork => diplomWork.Id;
            }
        }

        public Dto.ListResponse<DiplomWorkListItem> GetDiplomWorks(DiplomWorkRequest request)
        {
            var dbRequest = new Query<DiplomWork>();
            var response = new ListResponse<DiplomWorkListItem>();

            string[] includes = { "Teacher", "Students" };
            dbRequest.Skip = request.Skip;
            dbRequest.Take = request.Take;
            if (!string.IsNullOrEmpty(request.Name))
            {
                dbRequest.FilterExpression = DiplomWork => DiplomWork.Name.Contains(request.Name);
            }
            dbRequest.SortExpressions = (request == null || request.Sortings == null) ? null : request.Sortings
                .Select(sorting =>
                {
                    return new SortExpression<DiplomWork>(GetSortExpression(sorting.FieldName), (SortDirection)sorting.Direction);
                })
                .ToList();
            if (!dbRequest.SortExpressions.Any())
            {
                dbRequest.SortExpressions.Add(new SortExpression<DiplomWork>(GetSortExpression(""), SortDirection.Ascending));
            }
            response.TotalCount = _repository.Count(dbRequest.FilterExpression);
            response.Items = _repository.Get(dbRequest, includes).Select(x =>
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
            string[] includes = { "Teacher", "Student" };
            return _repository.Get(id, includes);
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
