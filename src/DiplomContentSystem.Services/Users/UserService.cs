using System;
using System.Collections.Generic;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using AutoMapper;
namespace DiplomContentSystem.Services.Users
{
    public class UserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _repository = repository;
            _mapper = mapper;
            
        }

        public Dto.ListResponse<UserListItem> GetUsers(UserRequest request)
        {
            var queryBuilder = new UsersQueryBuilder();
            var response = new ListResponse<UserListItem>();
            //string[] includes = {"Position","Department"};

            var query = queryBuilder.UseDto(request)
                                    .UsePaging()
                                    .UseFilters()
                                    .UseSortings(defaultSorting:"id")
                                    .Build();

            response.TotalCount = _repository.Count(query.FilterExpression);
            response.Items = _mapper.Map<IEnumerable<UserListItem>>(_repository.Get(query));

            return response;
        }

        public User Get(int id)
        {   
            return _repository.Get(id);
        }

        public bool AddUser(UserEditItem userDto)
        {
            var dbUser = _mapper.Map<User>(userDto);
            _repository.Add(dbUser);
            _repository.SaveChanges();
            return true;
        }

        public bool UpdateUser(UserEditItem userDto)
        {
            var dbUser = _mapper.Map<User>(userDto);
            _repository.Update(dbUser);
            _repository.SaveChanges();
            return true;
        }
    }
}
