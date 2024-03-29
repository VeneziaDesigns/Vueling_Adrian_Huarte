﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.IRepositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
