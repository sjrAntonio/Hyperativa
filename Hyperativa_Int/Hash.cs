using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hyperativa_Interface
{
    public class Hash
    {
        private HashAlgorithm _algoritmo = SHA512.Create();

        public Hash()
        {
            _algoritmo = SHA512.Create();
        }

        public Hash(HashAlgorithm algoritmo)
        {
            _algoritmo = algoritmo;
        }
        public string criptografarHash(string sCriprografar)
        {
            var encodedValue      = Encoding.UTF8.GetBytes(sCriprografar);
            var encryptedPassword = _algoritmo.ComputeHash(encodedValue);

            var sb = new StringBuilder();

            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool verificarHash(string sValorDigitado, string sValorCriprografado)
        {
            if (string.IsNullOrEmpty(sValorDigitado))      throw new NullReferenceException("Informe o parametro a ser verificado");
            if (string.IsNullOrEmpty(sValorCriprografado)) throw new NullReferenceException("Informe o parametro criprografado");

            var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(sValorDigitado));

            var sb = new StringBuilder();

            foreach (var caractere in encryptedPassword)
            {
                sb.Append(caractere.ToString("X2"));
            }

            return sb.ToString() == sValorCriprografado;
        }
    }
}