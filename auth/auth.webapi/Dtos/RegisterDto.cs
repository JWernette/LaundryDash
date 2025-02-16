namespace auth.webapi.Dtos;

public record RegisterDto(
    string email,
    string password,
    AccountType accountType = AccountType.CUSTOMER
);
