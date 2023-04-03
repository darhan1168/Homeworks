﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace BLL.Abstractions.Interfaces
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task Add(T obj);

        Task Delete(Guid id);

        Task<T> GetById(Guid id);

        Task<List<T>> GetAll();

        Task<T> GetByPredicate(Func<T, bool> predicate);

        Task Update(Guid id, T obj);
    }
}