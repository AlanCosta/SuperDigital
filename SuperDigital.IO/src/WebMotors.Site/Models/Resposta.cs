using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDigital.Site.Models
{
    public class Resposta
    {
        public int Codigo { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public string HTML { get; set; }

        public Resposta() { }

        public Resposta(int _codigo, bool _sucesso, string _mensagem)
        {
            this.Codigo = _codigo;
            this.Sucesso = _sucesso;
            this.Mensagem = _mensagem;
        }

        public Resposta(int _codigo, bool _sucesso, string _mensagem, string _HTML)
        {
            this.Codigo = _codigo;
            this.Sucesso = _sucesso;
            this.Mensagem = _mensagem;
            this.HTML = _HTML;
        }

        private Resposta CriarResposta()
        {
            Resposta resposta = new Resposta();

            resposta.Codigo = this.Codigo;
            resposta.Sucesso = this.Sucesso;
            resposta.Mensagem = this.Mensagem;
            resposta.HTML = this.HTML;

            return resposta;
        }

    }


}
