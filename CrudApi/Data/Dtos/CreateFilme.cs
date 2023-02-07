using System.ComponentModel.DataAnnotations;

namespace AluraAPI.Data.Dtos
{
    public class CreateFilme
    {
      
            [Required(ErrorMessage = " O titulo do filme é obrigatório")]
            public string Titulo { get; set; }
            [Required]
            [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
            public string Duracao { get; set; }
            [Required(ErrorMessage = " O Genero é obrigatório")]
            public string Genero { get; set; }

  
    }

}

