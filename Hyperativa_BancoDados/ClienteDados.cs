using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa_BancoDados
{
    public class ClienteDados
    {
        public ClienteDados()
        {
            //conectarBancoDeDados();
        }
        ~ClienteDados()
        {
            //desconectarBancoDeDados();
        }

        public bool cadastrarCliente(int idCliente, string sLote, string sNomeCliente, string sNumeroCC)
        {
            string sSQL = "INSERT INTO TB_CLIENTE VALUES (" + idCliente.ToString() + ", '" +
                                                              sLote + "', '" +
                                                              sNomeCliente + "', '" +
                                                              sNumeroCC + ")";

            /**********************************************************************************************************
            * Eu sei que o ideal era fazer uma conexao e usar um banco de dados, porem, infelizmente tive um problema *
            * particular serio, conforme explicado a sra. Tatiana. Então, eu me foquei nas questoes de seguranca e    *
            * criptografia para melhor demonstrar o que eu posso fazer.                                               *
            **********************************************************************************************************/

            bool bResultado = true;

            return bResultado;
        }
    }
}
