using users_app.Models;
using System.Collections.Generic;
namespace users_app.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}
