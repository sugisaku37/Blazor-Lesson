using System.ComponentModel.DataAnnotations;
using System.Reflection;

public class ValidationUtil
{
    public static IList<ValidationResult> ValidateObject(object objectToValidate)
    {
        ValidationContext ctx = new ValidationContext(objectToValidate, null);
        List<ValidationResult> results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(objectToValidate, ctx, results, true);

        // 子プロパティについても確認
        Type type = objectToValidate.GetType();
        TypeInfo info = type.GetTypeInfo();
        foreach (PropertyInfo pi in type.GetRuntimeProperties())
        {
            if (pi.PropertyType.Namespace != "System")
            {
                var child = pi.GetValue(objectToValidate);
                if (child == null)
                {
                    continue;
                }

                var internalResults = ValidateObject(child);
                results.AddRange(internalResults);
            }
        }

        return results;
    }
    public static void ThrowIfObjectIsNotValid(object objectToValidate)
    {
        var results = ValidateObject(objectToValidate);
        if (results != null && results.Count > 0)
        {
            if (results[0].MemberNames == null ) throw new ValidationException(results[0].ErrorMessage);
            throw new ValidationException($"{results[0].ErrorMessage} ({string.Join(",", results[0].MemberNames.ToArray())})");
        }
    }
}