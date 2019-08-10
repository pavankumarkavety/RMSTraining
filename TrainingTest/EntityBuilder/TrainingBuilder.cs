using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingAPI.Models;

namespace TrainingTest.EntityBuilder
{
    public abstract class TrainingBuilder
    {
        public static System.Collections.Generic.List<Training> GetTestTrainings()
        {
            var testTrainings = new List<Training>();
            testTrainings.Add(new Training { Id = 1, Name = "angular", StartDate = DateTime.Today.AddDays(-30), EndDate = DateTime.Today });
            testTrainings.Add(new Training { Id = 1, Name = ".net", StartDate = DateTime.Today.AddDays(-30), EndDate = DateTime.Today });

            return testTrainings;
        }

        public static Training GetTestTraining()
        {
            Training training = new Training
            {
                Id = 1,
                Name = "angular",
                StartDate = DateTime.Today.AddDays(-30),
                EndDate = DateTime.Today
            };

            return training;
        }

        public static Training GetTestInvalidTraining()
        {
            Training training = new Training
            {
                StartDate = DateTime.Today.AddDays(-30),
                EndDate = DateTime.Today
            };

            return training;
        }

    }
}
