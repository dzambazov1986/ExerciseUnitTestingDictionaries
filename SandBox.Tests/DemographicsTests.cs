using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;

namespace SandBox.Tests
{
    public partial class DemographicsTests
    {
        [TestCaseSource(nameof(TestCasesForDatabase))]
        public void Test_Database_ShouldRegisterAndUnregisterCorrectly(DatabaseData databaseData)
        {
            //Act
            Dictionary<string, string> result = Demographics.Database(databaseData.InputData);

            //Assert
            Assert.That(result, Is.EqualTo(databaseData.ExpectedData));
        }

        public static IEnumerable<DatabaseData> TestCasesForDatabase()
        {
            yield return new DatabaseData
            {
                InputData = new string[]
                {
                    "register John CS1234JS",
                    "register Andy AB4142CD",
                    "register Jesica VR1223EE",
                    "unregister AB4142CD"
                },
                ExpectedData = new Dictionary<string, string>
                {
                    { "CS1234JS", "John"},
                    { "VR1223EE", "Jesica"},
                },
            };

            yield return new DatabaseData
            {
                InputData = new string[]
                {
                    "register John CS1234JS",
                    "register Andy AB4142CD",
                    "register Jesica VR1223EE",
                    "unregister CS1234JS"
                },
                ExpectedData = new Dictionary<string, string>
                {
                    { "AB4142CD", "Andy"},
                    { "VR1223EE", "Jesica"},
                },
            };
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test_CountUserWithEqualUsernames_ShouldReturnCorrectCount(
            Data data)
        {
            //Act
            Dictionary<string, int> result = Demographics.CountUserWithEqualUsernames(data.InputData);

            //Assert
            Assert.That(result, Is.EqualTo(data.ExpectedData));
        }

        public static IEnumerable<Data> TestCases()
        {
            //This test case cover...
            yield return new Data
            {
                InputData = new List<string> { "Stoyan", "Shopov", "Stoyan" },
                ExpectedData = new Dictionary<string, int>
                {
                    { "Stoyan", 2 },
                    { "Shopov", 1 }
                }
            };


            //This test case cover...
            yield return new Data
            {
                InputData = new List<string> { "Stoyan", },
                ExpectedData = new Dictionary<string, int>
                {
                    { "Stoyan", 1 }
                }
            };

            yield return new Data
            {
                InputData = new List<string> { "", },
                ExpectedData = new Dictionary<string, int>
                {

                }
            };

            yield return new Data
            {
                InputData = new List<string> { null, },
                ExpectedData = new Dictionary<string, int>
                {

                }
            };
        }
    }
}