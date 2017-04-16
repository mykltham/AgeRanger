using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgeRanger.SPA.Models;

namespace AgeRanger.SPA.Interface
{
    interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        IEnumerable<PersonWithAgeGroup> GetAllWithAgeGroup();
        Person Get(int id);
        bool Add(Person item);
        bool Update(Person item);
        bool Delete(int id);
    }
} // namespace