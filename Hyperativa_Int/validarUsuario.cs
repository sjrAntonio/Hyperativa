using Hyperativa_BancoDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa_Interface
{
    public class validarUsuario
    {
        public static bool ValidarUsuario(Usuario loginDetalhes)
        {
            /***********************************************************************************
            * Propositalmente utilizei criptografia reversivel e irreversilvel para demonstrar *
            * as possiblidades de seguranca no projeto                                         *
            ***********************************************************************************/
            Hash clsHash = new Hash();
            AES clsAES   = new AES();

            string sUsuarioHash = clsAES.criptografarAES (loginDetalhes.NomeUsuario);
            string sSenhaHash   = clsHash.criptografarHash(loginDetalhes.Senha);

            UsuarioDados clsUsuarioDados = new UsuarioDados();

            bool bConectar = clsUsuarioDados.validarUsuario(sUsuarioHash, sSenhaHash);

            return bConectar;
        }
    }
}
