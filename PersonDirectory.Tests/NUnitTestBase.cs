using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PersonDirectory.Core.Entities;
using PersonDirectory.Core.Mapper;
using PersonDirectory.Core.Repositories;
using PersonDirectory.Infrastructure.DBContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace PersonDirectory.Tests
{
    [TestFixture]
    public class NUnitTestBase
    {
        [SetUp]
        public void Setup()
        {
        }


        private readonly TestServer _server;
        private readonly HttpClient _client;

        public NUnitTestBase()
        {



        }

        [Test]
        public void Get_order_detail_success()
        {

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
            var person = new Person() { IDNumber = "asdf" };
            var result = CheckPropertyValidation.myValidation(person);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "DB").Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Persons.Add(new Person()
                {
                    //EmployeeId = "12345",
                    //Country = "USA",
                    //State = "NY",
                    //Address = "Test1",
                    //ZipCode = "121312"
                });


                context.SaveChanges();
            }
            using (var context = new ApplicationDbContext(options))
            {
                var logic = new PersonRepository(context, mapper);
                logic.CreatePerson(new BasePerson() { Firstname = "ბექა" });
                context.SaveChanges();
            }
        }
    }

    public static class CheckPropertyValidation
    {
        public static IList<ValidationResult> myValidation(object model)
        {
            var result = new List<ValidationResult>();
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(model);
            Validator.TryValidateObject(model, validationContext, result, true);
            if (model is IValidatableObject) 
                (model as IValidatableObject).Validate(validationContext);
            return result;
        }
    }
}
