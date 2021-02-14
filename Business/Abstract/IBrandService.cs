using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        void Add(Brand entity);
        void Update(Brand entity);
        void Delete(Brand entity);
        Brand GetById(int Id);
    }
}
