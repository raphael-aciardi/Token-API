using System.ComponentModel.DataAnnotations;

namespace API_FIlmes_Entity.Models;

public class Usuario
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O login do usuário é obrigatório")]
    public string Login { get; set; }
    [Required(ErrorMessage = "A senha do usuário é obrigatória")]
    public string Senha { get; set; }
    [Required(ErrorMessage = "O e-mail do usuário é obrigatório")]
    public string email { get; set; }
}
