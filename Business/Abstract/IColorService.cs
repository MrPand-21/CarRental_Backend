using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        void Add(Color entity);
        void Update(Color entity);
        void Delete(Color entity);
        Color GetById(int Id);
    }
}
