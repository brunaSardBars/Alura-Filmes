using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O gênero não pode ter mais de 30 caracteres")]
        public string Genero { get; set; }

        [Range(1,600, ErrorMessage = "O tempo de duração deve estar entre 1 e 600 minutos")]
        public int Duracao { get; set; }

        [Range(0, 18, ErrorMessage = "Classificação Etária deve estar entre 0 e 18 minutos")]
        public int ClassificacaoEtaria { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
