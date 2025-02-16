public class CustomerDto
{
    public Guid UserId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; private set; }
    public Address Address { get; set; }
    public bool IsActive { get; set; }

    public CustomerDto(
        Guid userId,
        string firstName,
        string lastName,
        string email,
        DateOnly dateOfBirth,
        Address address
    )
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Email = email;
        Address = address;
    }
}
