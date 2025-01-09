#nullable disable
using System;
using System.Collections.Generic;

namespace users.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Password { get; set; }

    public string Genero { get; set; }

    public string Atributos { get; set; }

    public bool Maneja { get; set; }

    public bool Lentes { get; set; }

    public bool Diabetico { get; set; }

    public string Enfermedades { get; set; }

    public bool Admin { get; set; }

    public bool Estado { get; set; }

}
