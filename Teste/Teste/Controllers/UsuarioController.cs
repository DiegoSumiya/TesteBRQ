using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Teste.Domain.Entities;
using System.Data;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Connection()
        {
            string stringDeConexao = _configuration.GetConnectionString("TesteDB");
            SqlConnection conexao = new SqlConnection(stringDeConexao);
            return conexao;
        }
        [HttpPost]
        public void InsertUsuario(Usuario usuario)
        {
            SqlConnection connection = Connection();
            SqlCommand sqlCommand = new SqlCommand("insert_usuario", connection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@CPF", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            sqlCommand.Parameters.AddWithValue("@Sexo", usuario.Sexo);
            sqlCommand.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);

            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        [HttpGet]
        [Route("{id}")]
        public Usuario GetId(int id)
        {
            SqlConnection connection = Connection();
            SqlCommand sqlCommand = new SqlCommand("select_usuario", connection);
            sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();

            SqlDataReader tabela = sqlCommand.ExecuteReader();
            bool existeDados = tabela.Read();
            Usuario usuario = new Usuario();

            if (existeDados)
            {
                usuario.Id = tabela.GetInt32("Id");
                usuario.Nome = tabela.GetString("Nome");
                usuario.Cpf = tabela.GetString("CPF");
                usuario.Email = tabela.GetString("Email");
                usuario.Telefone = tabela.GetString("Telefone");
                usuario.Sexo = tabela.GetString("Sexo");
                usuario.DataNascimento = tabela.GetDateTime("DataNascimento");
            }

            connection.Close();
            return usuario;
        }
        [HttpGet]
        
        public List<Usuario> GetListUsuario()
        {
            SqlConnection connection = Connection();
            SqlCommand sqlCommand = new SqlCommand("select_usuario_todos", connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();

            SqlDataReader tabela = sqlCommand.ExecuteReader();
            bool existeDados = tabela.Read();
            List<Usuario> usuario = new List<Usuario>();

            while(existeDados)
            {
                Usuario usu = new Usuario();
                usu.Id = tabela.GetInt32("Id");
                usu.Nome = tabela.GetString("Nome");
                usu.Cpf = tabela.GetString("CPF");
                usu.Email = tabela.GetString("Email");
                usu.Telefone = tabela.GetString("Telefone");
                usu.Sexo = tabela.GetString("Sexo");
                usu.DataNascimento = tabela.GetDateTime("DataNascimento");

                usuario.Add(usu);
                existeDados = tabela.Read();
            }
            connection.Close();

            return usuario;
        }

        [HttpPut]
        public void UpdateUsuario(Usuario usuario)
        {
            SqlConnection connection = Connection();
            SqlCommand sqlCommand = new SqlCommand("update_usuario", connection);
            sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = usuario.Id;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();

            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@CPF", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            sqlCommand.Parameters.AddWithValue("@Sexo", usuario.Sexo);
            sqlCommand.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);

            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteUsuario(int id)
        {
            SqlConnection connection = Connection();
            SqlCommand sqlCommand = new SqlCommand("delete_usuario", connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();

            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
