using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using DAL;
using System.Web.Http.Cors;

namespace WebApi_Academic.Controllers
{
    [EnableCorsAttribute("*","*","*")]
    public class PessoaController : ApiController
    {
        // GET: api/Pessoa
        public IEnumerable<Pessoa> Get()
        {
            
            PessoaDal pessoaDal = new PessoaDal();            
            return pessoaDal.ListPessoa();
        }

        // GET: api/Pessoa/5
        public Pessoa Get(int id)
        {
            PessoaDal pessoaDal = new PessoaDal();
            Pessoa pessoa = new Pessoa();
            pessoa.Id = id;
            pessoaDal.LerPessoa(pessoa);
            return pessoa;
        }

        // POST: api/Pessoa
        public List<Pessoa> Post([FromBody]Pessoa pessoa)
        {
            PessoaDal pessoaDal = new PessoaDal();
            Pessoa _pessoa = new Pessoa();
            _pessoa.Nome =pessoa.Nome;
            pessoaDal.Incluir(_pessoa);
            return pessoaDal.ListPessoa();
           
        }

        // PUT: api/Pessoa/5
        public List<Pessoa> Put(int id,[FromBody]Pessoa pessoa)
        {
            PessoaDal pessoaDal = new PessoaDal();
            Pessoa _pessoa = new Pessoa();
            _pessoa.Id =id;
            _pessoa.Nome = pessoa.Nome;
            pessoaDal.Atualizar(_pessoa);
            return pessoaDal.ListPessoa();
        }

        // DELETE: api/Pessoa/5
        public List<Pessoa> Delete(int id)
        {
            PessoaDal pessoaDal = new PessoaDal();
            Pessoa _pessoa = new Pessoa();
            _pessoa.Id = id;
            pessoaDal.Deletar(_pessoa);
            return pessoaDal.ListPessoa();
        }
    }
}
