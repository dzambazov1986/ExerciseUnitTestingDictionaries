//Demographics.CountUserWithEqualUsernames();
//Demographics.CountCharsString
//Demographics.CountEvenAndOddNumbers
//Demographics.Database
namespace SandBox.Tests
{
    public partial class DemographicsTests
    {
        public class DatabaseData
        {
            public string[] InputData { get; set; }

            public Dictionary<string, string> ExpectedData { get; set; }
        }
    }
}