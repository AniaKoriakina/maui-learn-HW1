using HW1.Models.Enums;

namespace HW1.Models;

public class UserForm
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public double Age { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public bool IsAgreed {get; set; }
}