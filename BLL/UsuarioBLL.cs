﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;
using System.Security.Cryptography;

namespace BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAO _usuario;

        public UsuarioBLL()
        {
            if (_usuario == null)
                _usuario = new UsuarioDAO();
        }

        public void Novo(Usuario entidade)
        {
            _usuario.Novo(entidade);
        }

        public void Remover(Usuario entidade)
        {
            _usuario.Remover(entidade);
        }

        public void Editar(Usuario entidade)
        {
            _usuario.Editar(entidade);
        }

        public List<Usuario> Listar()
        {
            return _usuario.Listar();
        }

        public Usuario Listar(Usuario entidade)
        {
            return _usuario.Listar(entidade);
        }

        public void Desabilitar(Usuario entidade)
        {
            _usuario.Desabilitar(entidade);
        }

        public Usuario ListarLinhaNegocio(Usuario entidade)
        {
            return _usuario.ListarLinhaNegocio(entidade);
        }

        public Usuario ListarPerfil(Usuario entidade)
        {
            return _usuario.ListarPerfil(entidade);
        }

        public Usuario Validar(Usuario entidade)
        {
            return _usuario.Validar(entidade);
        }

        public string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5Hash(input);

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
