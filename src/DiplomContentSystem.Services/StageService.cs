using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using System.Linq.Expressions;

namespace DiplomContentSystem.Services
{
    public class StageService
    {
        private readonly IRepository<Stage> _repository;
        public StageService(IRepository<Stage> repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            else
                _repository = repository;
        }

        private Expression<Func<Stage, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "startDate": return stage => stage.StartDate;
                case "endDate": return stage => stage.EndDate;
                case "name": return stage => stage.Name;
                default: return stage => stage.Id;
            }
        }

        public ListResponse<StageListItem> GetStages(StageRequest request)
        {
            var dbRequest = new Request<Stage>();
            var response = new ListResponse<StageListItem>();

            string[] includes = null;
            dbRequest.Skip = request.Skip;
            dbRequest.Take = request.Take;
            dbRequest.SortExpressions = (request == null || request.Sortings == null) ? null : request.Sortings
                .Select(sorting =>
                {
                    return new SortExpression<Stage>(GetSortExpression(sorting.FieldName), (SortDirection)sorting.Direction);
                })
                .ToList();
            if (!dbRequest.SortExpressions.Any())
            {
                dbRequest.SortExpressions.Add(new SortExpression<Stage>(GetSortExpression(""), SortDirection.Ascending));
            }
            response.TotalCount = _repository.Count(null);
            response.Items = _repository.Get(dbRequest, includes).Select(x =>
                {
                    return new StageListItem()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Status = x.Status,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate
                    };
                });
            return response;
        }

        public Stage Get(int id)
        {
            string[] includes = null;
            return _repository.Get(id, includes);
        }

        public bool AddStage(Stage stage)
        {
            var dbStage = new Stage();
            dbStage.Id = stage.Id;
            dbStage.Name = stage.Name;
            dbStage.Description = stage.Description;
            dbStage.Status = stage.Status;
            dbStage.StartDate = stage.StartDate;
            dbStage.EndDate = stage.EndDate;
            _repository.Add(dbStage);
            _repository.SaveChanges();
            return true;
        }

        public bool UpdateStage(Stage stage)
        {
            var dbStage = new Stage();
            dbStage.Id = stage.Id;
            dbStage.Name = stage.Name;
            dbStage.Description = stage.Description;
            dbStage.Status = stage.Status;
            dbStage.StartDate = stage.StartDate;
            dbStage.EndDate = stage.EndDate;
            _repository.Update(dbStage);
            _repository.SaveChanges();
            return true;
        }
    }
}
