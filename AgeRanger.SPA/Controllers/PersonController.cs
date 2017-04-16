using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AgeRanger.SPA.Interface;
using AgeRanger.SPA.Models;
using AgeRanger.SPA.Repositories;

namespace AgeRanger.SPA.Controllers
{
    public class PersonController : ApiController
    {
        // local properties
        static readonly IPersonRepository _repository = new PersonRepository();

        /// <summary>
        /// To read all Person's details with Age Group Descriptions
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAllPersons()
        {
            return _repository.GetAllWithAgeGroup();
        }

        /// <summary>
        /// To perform add new person
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IEnumerable PostPerson(Person item)
        {
            if (_repository.Add(item))
            {
                // When return, read all with Agegroup again as AgeGroup is not stored in [Person]
                return _repository.GetAllWithAgeGroup();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// To perform update of Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rec"></param>
        /// <returns></returns>
        public IEnumerable PutPerson(int id, Person rec)
        {
            rec.Id = id;
            if (_repository.Update(rec))
            {
                // Refresh the grid with updated Person Details
                return _repository.GetAllWithAgeGroup();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// To perform deletion of person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletePerson(int id)
        {
            if (_repository.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    } // class
} // namespace
