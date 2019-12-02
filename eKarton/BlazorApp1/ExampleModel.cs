using System.ComponentModel.DataAnnotations;
public class ExampleModel
{
    //[Required]
    [StringLength(10, ErrorMessage = "Name is too long.")]
    public string Name { get; set; }

    //[Required]
    //[StringLength(10, ErrorMessage = "Name is too long.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "UPRN must be numeric")]
    //[Display(Name = "CONTACT_NUMBER ")]
    // [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered CONTACT_NUMBER format is not valid.")]
    public int BrojFaksimila { get; set; }
}
