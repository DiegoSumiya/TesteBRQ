using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Domain.Entities
{
    public class Usuario
    {
        public Usuario(){}
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string  Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
