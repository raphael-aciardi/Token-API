namespace API_FIlmes_Entity.Data.Dtos
{
    public class ReadUsuarioDto
    {

        public string Login { get; set; }

        public string Senha { get; set; }

        public string email { get; set; }

        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
