using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace SiteB.Business
{
    public class Login
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public bool Erro { get; set; }
        public string MensagemErro { get; set; }

        public Login()
        {
            this.Erro = false;
            this.MensagemErro = string.Empty;
        }

        public Entities.Login AutenticarLogin(string CPF, string Senha)
        {
            Entities.Login[] login = ListaUsuario(new Entities.Login(CPF, Senha));
            Entities.Login users = login.FirstOrDefault();

            if (users == null)
            {
                this.Erro = true;
                this.MensagemErro = "Usuário ou Senha inválidos!";
            }

            return users;
        }

        public bool LoginCadastrado(string Login)
        {
            Entities.Login[] login = ListaUsuario(new Entities.Login(CPF));
            Entities.Login users = login.FirstOrDefault();

            bool existe = users != null && users.Id > 0;

            return existe;
        }

        public Entities.Login[] ListaUsuario()
        {
            return ListaUsuario(null);
        }


        public Entities.Login[] ListaUsuario(Entities.Login login)
        {
            List<Entities.Login> lstLogin = new List<Entities.Login>();

            Dados.Connection connection = new Dados.Connection(this.ConnectionString);


            connection.AbrirConexao();

            StringBuilder sqlString = new StringBuilder();
            sqlString.AppendLine("SELECT * FROM SiteBLogin");

            if (login != null)
            {
                sqlString.AppendLine("WHERE 1 = 1");

                if (login.Id > 0)
                {
                    sqlString.AppendLine("AND Id = " + login.Id + "");
                }


                if (!string.IsNullOrEmpty(login.Senha) && login.Senha.Length > 0)
                {
                    sqlString.AppendLine("AND SENHA = '" + login.Senha + "'");
                }

            }
        }
    }
}
