using System.ComponentModel.DataAnnotations;

namespace API_FIlmes_Entity.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required(ErrorMessage = "O login do usuário é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório")]
        public string Email { get; set; }
    }
}
