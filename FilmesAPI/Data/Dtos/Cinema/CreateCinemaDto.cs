﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }

    }
}
