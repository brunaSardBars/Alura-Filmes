using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O gênero não pode ter mais de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "O tempo de duração deve estar entre 1 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
