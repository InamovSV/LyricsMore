using LyricsHelpTgBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsHelpTgBot.DAL
{
    class UserRep : ICrud<User>
    {
        Context context;

        public UserRep(Context context)
        {
            this.context = context;
        }

        public void Create(User item)
        {
            context.Users.Add(item);
            context.SaveChanges();
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public User GetByLogin(string login)
        {
            return context.Users.SingleOrDefault(item => item.Login == login);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToArray();
        }

        public void Remove(User item)
        {
            context.Users.Remove(item);
            context.SaveChanges();
        }

        public void Update(User item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
