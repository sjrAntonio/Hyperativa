using Hyperativa_BancoDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa_Interface
{
    public class cadastrarCliente
    {
        public static bool cadastrarClienteCC(Cliente clienteDetalhes)
        {
            bool bCartao = validarCartaoCredito.validarCC(clienteDetalhes.NumeroCartaoCredito); //Apenas uma validacao como regra de negocio

            if (!bCartao) { throw new Exception("Numero do cartao invalido"); }

            /***********************************************************************************
            * Propositalmente utilizei criptografia reversivel e irreversilvel para demonstrar *
            * as possiblidades de seguranca no projeto                                         *
            ***********************************************************************************/
            Hash clsHash = new Hash();
            AES  clsAES  = new AES();

            string sLote         = clsAES.criptografarAES(clienteDetalhes.Lote.ToString());
            string sNomeCliente  = clsAES.descriptografarAES(clienteDetalhes.NomeCliente);
            string sNumeroCartao = clsHash.criptografarHash(clienteDetalhes.NumeroCartaoCredito);

            ClienteDados clsClienteDados = new ClienteDados();

            bool bCadastrar = clsClienteDados.cadastrarCliente(clienteDetalhes.idCliente, sLote, sNomeCliente, sNumeroCartao);

            return bCadastrar;
        }
    }
}
