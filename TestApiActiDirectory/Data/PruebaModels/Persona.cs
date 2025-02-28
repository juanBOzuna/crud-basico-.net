using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApiActiDirectory.Data.PruebaModels;

public partial class Persona
{
    public int Id { get; set; }

    [MaxLength(200,ErrorMessage ="El nombre debe tener menos de 200 caracteres")]
    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    [MinLength(5, ErrorMessage ="Debe tener mas de 5 años")]
    public int? Edad { get; set; }

    [EmailAddress(ErrorMessage ="El email debe tener un formato valido.")]
    public string? Correo { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
