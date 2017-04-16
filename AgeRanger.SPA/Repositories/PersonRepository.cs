using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using AgeRanger.SPA.Models;
using AgeRanger.SPA.Interface;

namespace AgeRanger.SPA.Repositories
{
    public class PersonRepository : IPersonRepository, IDisposable
    {
        // local properties
        AgeRangerEntities _entity = new AgeRangerEntities();


    #region " Override Dispose "

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    // Release
                    if (_entity != null)
                    {
                        _entity.Dispose();
                        _entity = null;
                    }
                }
                catch (Exception ex)
                {
                    string errMsg = ex.Message;
                }
            }
        }

    #endregion


        public IEnumerable<Person> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return _entity.People;
        }

        public IEnumerable<PersonWithAgeGroup> GetAllWithAgeGroup()
        {
            // For MSSQL
            //strSQL = "SELECT a.Id, a.FirstName, a.LastName, a.Age, CASE WHEN a.AgeGroup IS NULL THEN (SELECT Top 1 Description FROM AgeGroup ORDER BY MinAge DESC) ELSE a.AgeGroup END as AgeGroup FROM ( SELECT Id, FirstName, LastName, Age, (SELECT Description FROM AgeGroup a WHERE ( p.Age >= ISNULL(a.MinAge,0) AND p.Age < a.MaxAge )) as AgeGroup FROM Person p ) a ORDER BY a.Id;";
            
            string strSQL = "SELECT Id, FirstName, LastName, Age, CASE WHEN AgeGroup IS NULL THEN (SELECT Description FROM AgeGroup WHERE (MinAge<>'' AND MinAge IS NOT NULL) ORDER BY MinAge DESC LIMIT 1) ELSE AgeGroup END as AgeGroup FROM ( 	SELECT Id, FirstName, LastName, Age, (SELECT Description FROM AgeGroup a WHERE ( p.Age >= IFNULL(a.MinAge,0) AND p.Age < a.MaxAge )	) as AgeGroup FROM Person p ) ORDER BY Id;";
            return _entity.Database.SqlQuery<PersonWithAgeGroup>(strSQL).ToList();
        }

        public Person Get(int id)
        {
            // TO DO : Code to find a record in database
            return _entity.People.Find(id);
        }

        public bool Add(Person item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            _entity.People.Add(item);
            _entity.SaveChanges();
            return true;
        }

        public bool Update(Person item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database
            var rec = _entity.People.Single(x => x.Id.Equals(item.Id));
            rec.FirstName = item.FirstName;
            rec.LastName = item.LastName;
            rec.Age = item.Age;
            _entity.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            Person rec = _entity.People.Find(id);
            _entity.People.Remove(rec);
            _entity.SaveChanges();

            return true;
        }

    } // class
} // namespace