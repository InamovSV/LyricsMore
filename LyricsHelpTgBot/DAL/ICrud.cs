using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsHelpTgBot.DAL
{
    public interface ICrud<T> where T : class
    {
        void Create(T item);
        void Remove(T item);
        void Update(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
