using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Oborotki
{
    public int Id { get; set; }

    /// <summary>
    /// Счет
    /// </summary>
    public string Schet { get; set; } = null!;

    /// <summary>
    /// Ном.№
    /// </summary>
    public string Number { get; set; } = null!;

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Дата поступления
    /// </summary>
    public string Date { get; set; } = null!;

    /// <summary>
    /// Ед.изм.
    /// </summary>
    public string Edizm { get; set; } = null!;

    /// <summary>
    /// Цена
    /// </summary>
    public double Cena { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    public double AmountNa4alo { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    public double SummaNa4alo { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    public double AmountPrihod { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    public double SummaPrihod { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    public double AmountRashod { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    public double SummaRashod { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    public double AmountKonec { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    public double SummaKonec { get; set; }

    /// <summary>
    /// Подразделение
    /// </summary>
    public string Otdel { get; set; } = null!;
}
