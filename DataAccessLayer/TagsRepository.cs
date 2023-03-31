using CourseWorkSpring2023.Abstract;
using CourseWorkSpring2023.Entities;
using CourseWorkSpring2023.Data;
using System.Collections.Generic;

namespace CourseWorkSpring2023.DataAccessLayer
{
    public class TagsRepository : ICrud<PostsTags>
    {
        private readonly ApplicationDbContext db;

        public TagsRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public void Create(PostsTags model)
        {
            db.Tags.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Tags.Remove(Read(id));
            db.SaveChanges();
        }

        public IEnumerable<PostsTags> GetList() => db.Tags;

        public PostsTags Read(int id) => db.Tags.Find(id);

        public void Update(PostsTags model)
        {
        }
    }
}
