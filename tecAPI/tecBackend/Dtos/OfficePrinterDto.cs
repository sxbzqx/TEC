namespace tecBackend.Models;

public record OfficePrinterDto(
    int Id,
    string InvNum,
    string Name,
    string Department,
    string UserDep,
    string TypeSelen,
    string ReplaceSelen,
    string NumZaprSelen,
    string NumZapr,
    string TypeCartr,
    string SerialNumber,
    string TypeToner,
    string KolToner,
    string InputMonth,
    string InputYear
);