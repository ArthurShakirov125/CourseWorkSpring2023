using System.Collections.Generic;

namespace CourseWorkSpring2023.Abstract
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetList();
        void Delete(int id);

        void Create(T model);

        void Update(T model);

        T Read(int id);
    }
}
