[TestClass]
public class EditAuthorViewModelTests
{
    public TestContext TestContext { get; set; }

    public static IEnumerable<object[]> EditAuthorViewModelTestData
    {
        get
        {
            string csvPath = Path.Combine(AppContext.BaseDirectory, "EditAuthorViewModelTestsData.csv");
            string[] lines = File.ReadAllLines(csvPath);
            return lines.Select(line => line.Split(',')).Skip(1);
        }
    }

    [TestMethod]
    [DynamicData(nameof(EditAuthorViewModelTestData))]
    public void VariousInputPatternsErrorTest(string testId, string authorId, string authorFirstName, string authorLastName, string phone, string expectedErrorCount, string firstErrorMessage, string secondErrorMessage)
    {
        EditAuthorViewModel model = new EditAuthorViewModel()
        {
            AuthorId = authorId,
            AuthorFirstName = authorFirstName,
            AuthorLastName = authorLastName,
            Phone = phone
        };

        var results = ValidationUtil.ValidateObject(model);
        TestContext.WriteLine($"TestId: {testId}, ExpectedErrorCount: {expectedErrorCount}");
        Assert.AreEqual(int.Parse(expectedErrorCount), results.Count(), $"TestId: {testId}");
        if (string.IsNullOrEmpty(firstErrorMessage) == false)
        {
            Assert.IsTrue(results.Select(r => r.ErrorMessage == firstErrorMessage).Any(), $"TestId: {testId}");
        }
        if (string.IsNullOrEmpty(secondErrorMessage) == false)
        {
            Assert.IsTrue(results.Select(r => r.ErrorMessage == secondErrorMessage).Any(), $"TestId: {testId}");
        }
        TestContext.WriteLine($"TestId: {testId} Successed.");
    }
}
