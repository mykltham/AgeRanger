using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeRanger.SPA.Controllers;
using AgeRanger.SPA.Models;
using AgeRanger.SPA.Repositories;

namespace AgeRanger.SPA.Tests
{
    [TestClass]
    public class PersonRepositoryUnitTest
    {
        [TestMethod]
        public void TestGetAllPersons()
        {
            // Arrange
            var entity = new PersonRepository();

            // Act
            var result = entity.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable));
        }

        [TestMethod]
        public void TestGetAllPersonsWithAgeGroup()
        {
            // Arrange
            var entity = new PersonRepository();

            // Act
            var result = entity.GetAllWithAgeGroup();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable));
        }

        [TestMethod]
        public void TestGetPersonById()
        {
            int id = 1;

            // Arrange
            var entity = new PersonRepository();

            // Act
            var result = entity.Get(id);

            // Assert
            Assert.IsTrue(result.Id.Equals(id));
        }

        [TestMethod]
        public void TestAddPerson()
        {

            // Arrange
            var entity = new PersonRepository();
            Person rec = new Person();
            Random rand = new Random();

            // Assign
            rec.FirstName = "Unit Test";
            rec.LastName = DateTime.Now.ToString("yyyy-MM-dd.HH:mm:ss");
            rec.Age = rand.Next(0, 6000);

            // Act
            var result = entity.Add(rec);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUpdatePerson()
        {

            // Arrange
            var entity = new AgeRangerEntities();
            var repo = new PersonRepository();
            Person rec = new Person();
            Random rand = new Random();

            // Assign
            rec = entity.People.Where(x => x.FirstName.Contains("Unit")).FirstOrDefault();
            if (rec != null)
            {
                rec.FirstName = "Unit Test - Updated";
                rec.LastName = DateTime.Now.ToString("yyyy-MM-dd.HH:mm:ss");
                rec.Age = rand.Next(0, 6000);
            }

            // Act
            var result = repo.Update(rec);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDeletePerson()
        {

            // Arrange
            var entity = new AgeRangerEntities();
            var repo = new PersonRepository();
            Person rec = new Person();

            // Act
            rec = entity.People.Where(x => x.FirstName.Contains("Unit")).FirstOrDefault();
            var result = repo.Delete((int)rec.Id);

            // Assert
            Assert.IsTrue(result);
        }



    } // class
} // namespace
