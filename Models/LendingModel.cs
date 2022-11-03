using System;

namespace PrestamosWPF.Models;

public class LendingModel
{
    public string? id_lending { get; set; }
    public string username { get; set; }
    public string? id_user { get; set; }
    public string? id_tool { get; set; }
    public string? name { get; set; }
    public DateTime? fecha_prestamo { get; set; }
}  