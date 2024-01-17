namespace EFIntro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class User
{
    public int? Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public List<int> PostIds { get; set; }
}