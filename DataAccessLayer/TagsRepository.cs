using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Custom;
using CourseWorkSpring2023.Data;
using System.Collections.Generic;

namespace CourseWorkSpring2023.DataAccessLayer
{
    public class TagsRepository : ICrud<PostsTags>
    {
        private readonly ApplicationDbContext _context;

        public void Create(PostsTags model)
        {
            _context.Tags.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Tags.Remove(Read(id));
            _context.SaveChanges();
        }

        public IEnumerable<PostsTags> GetList() => _context.Tags;

        public PostsTags Read(int id) => _context.Tags.Find(id);

        public void Update(PostsTags model)
        {
        }
    }
}
