using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteB.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string Perfil { get; set; }
        public DateTime DtCriacao { get; set; }
        public bool Ativo { get; set; }

        public Login() { }

        public Login(string CPF)
        {
            this.CPF = CPF;
        }

        public Login(string CPF, string Senha)
        {
            this.CPF = CPF;
            this.Senha = Senha;
        }

        public Login(int Id, string Nome, string Email, string Senha, string CPF, string Perfil, DateTime DtCriacao, bool Ativo)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
            this.CPF = CPF;
            this.Perfil = Perfil;
            this.DtCriacao = DtCriacao;
            this.Ativo = Ativo;
        }
    }
}
