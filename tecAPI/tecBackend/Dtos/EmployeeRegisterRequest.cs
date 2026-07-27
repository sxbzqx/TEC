namespace tecBackend.Dtos;

public record EmployeeRegisterRequest(
    string Tabel,
    string Fio,
    DateTime BirthDate,
    string Login,
    string Password,
    string? Mail
);