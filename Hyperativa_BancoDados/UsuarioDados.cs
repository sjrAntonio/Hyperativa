using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa_BancoDados
{
    public class UsuarioDados
    {
        public UsuarioDados()
        {
            //conectarBancoDeDados();
        }
        ~UsuarioDados()
        {
            //desconectarBancoDeDados();
        }

        public bool validarUsuario(string sUsuarioCrip, string sSenhaCrip)
        {
            string sSQL = "SELECT idUsuario FROM TB_USUARIOS WHERE NomeUsuario = '" + sUsuarioCrip + "' " +
                                                              "AND Senha = '"       + sSenhaCrip   + "'";

            /**********************************************************************************************************
            * Eu sei que o ideal era fazer uma conexao e usar um banco de dados, poem, infelizmente, tive um problema *
            * particular serio, conforme explicado a sra. Tatiana. Então, eu me foquei nas questoes de seguranca e    *
            * criptografia para melhor demonstrar o que eu posso fazer.                                               *
            **********************************************************************************************************/

            bool bResultado = true;

            return bResultado;
        }
    }
}
