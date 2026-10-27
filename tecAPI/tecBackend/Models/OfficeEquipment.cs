using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tecBackend.Models;

[Table("office_equipment")]
public class OfficeEquipment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    public string Type { get; set; } = string.Empty; // 'computer', 'laptop', 'printer', 'other'

    [Column("source_id")]
    public int SourceId { get; set; }

    [Column("inv_num")]
    public string? InvNum { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("network_name")]
    public string? NetworkName { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("department")]
    public string? Department { get; set; }

    [Column("user_dep")]
    public string? UserDep { get; set; }

    [Column("user_fio")]
    public string? UserFio { get; set; }

    // Аппаратная часть
    [Column("cpu")]
    public string? Cpu { get; set; }

    [Column("ram_1")]
    public string? Ram1 { get; set; }

    [Column("ram_2")]
    public string? Ram2 { get; set; }

    [Column("hdd_1")]
    public string? Hdd1 { get; set; }

    [Column("hdd_2")]
    public string? Hdd2 { get; set; }

    [Column("video")]
    public string? Video { get; set; }

    [Column("monitor")]
    public string? Monitor { get; set; }

    [Column("optical")]
    public string? Optical { get; set; }

    [Column("audio")]
    public string? Audio { get; set; }

    [Column("speakers")]
    public string? Speakers { get; set; }

    // Оргтехника
    [Column("serial_number")]
    public string? SerialNumber { get; set; }

    [Column("type_cartr")]
    public string? TypeCartr { get; set; }

    [Column("num_zapr")]
    public string? NumZapr { get; set; }

    [Column("type_selen")]
    public string? TypeSelen { get; set; }

    [Column("replace_selen")]
    public string? ReplaceSelen { get; set; }

    [Column("type_toner")]
    public string? TypeToner { get; set; }

    [Column("kol_toner")]
    public string? KolToner { get; set; }

    // Эксплуатация
    [Column("input_month")]
    public string? InputMonth { get; set; }

    [Column("input_year")]
    public string? InputYear { get; set; }
}