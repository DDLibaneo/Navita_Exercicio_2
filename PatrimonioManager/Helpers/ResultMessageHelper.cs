using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatrimonioManager.Helpers
{
    public static class ResultMessageHelper
    {
        public static string MarcaNotFoundMessage(int id)
        {
            return $"Não existe marca com Id '{id}' no Banco de Dados.";
        }

        public static string MarcaWithNameExistsMessage(string Nome)
        {
            return $"Marca '{Nome}' já existe no banco de dados.";
        }
    }
}