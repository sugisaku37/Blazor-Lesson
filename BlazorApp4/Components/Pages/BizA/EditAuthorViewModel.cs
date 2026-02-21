using System.ComponentModel.DataAnnotations;

[CustomValidation(typeof(EditAuthorViewModel), "NameAndPhoneCheck")]
public class EditAuthorViewModel
{
    [Display(Name = "筆者ID")]
    public string AuthorId { get; set; } = "";

    [Display(Name = "筆者名（名）")]
    [Required(ErrorMessage = "筆者名（名）は必須入力です。")]
    [RegularExpression(@"^[\u0020-\u007a]{1,20}$", ErrorMessage = "筆者名（名）は半角20文字以内で入力してください。")]
    public string AuthorFirstName { get; set; } = "";
    
    [Display(Name = "筆者名（姓）")]
    [Required(ErrorMessage = "筆者名（姓）は必須入力です。")]
    [RegularExpression(@"^[\u0020-\u007a]{1,40}$", ErrorMessage = "筆者名（姓）は半角40文字以内で入力してください。")]
    public string AuthorLastName { get; set; } = "";
    
    [Display(Name = "電話番号")]
    [Required(ErrorMessage = "電話番号は必須入力です。")]
    [RegularExpression(@"^\d{3} \d{3}-\d{4}$", ErrorMessage = "電話番号は012 345-6789 のように入力してください。")]
    public string Phone { get; set; } = "";

    public static ValidationResult NameAndPhoneCheck(EditAuthorViewModel model, ValidationContext context)
    {
        if (model.AuthorFirstName == "Akinori" && model.AuthorLastName == "Sugimura")
        {
            return new ValidationResult("Akinori Sugimura という名前は予約済みのため登録できません", new List<string> { "AuthorFirstName", "AuthorLastName" });
        }
        return ValidationResult.Success;
    }
}