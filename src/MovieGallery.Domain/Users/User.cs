namespace MovieGallery.Domain.Users;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime UpdatedOnUtc { get; private set; }

    private User(
        Guid id,
        string firstName,
        string lastName,
        string email,
        string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(
        Guid? id,
        string firstName,
        string lastName,
        string email,
        string password)
    {
        return new(
            id ?? Guid.NewGuid(),
            firstName,
            lastName,
            email,
            password);
    }
}