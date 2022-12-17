using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_bind.Models
{
    public static class UtilsExtension
    {

        #region " Enums "

        public static T GetEnumToName<T>(this string value, T def) => Utils.GetEnumToName<T>(value, def);

        public static string GetAttributeDescription<T>(this T source) => Utils.GetAttributeDescription<T>(source);

        public static Dictionary<int, string> EnumToDictionaryName<T>() => Utils.EnumToDictionaryName<T>();

        public static Dictionary<int, string> EnumToDictionaryDescription<T>() => Utils.EnumToDictionaryDescription<T>();


        #endregion

        #region " String "

        public static string GetQueryString<T>(this T obj, bool usingEncode = false, IEnumerable<string> propsExcluded = null) where T : class => Utils.GetQueryString(obj, usingEncode, propsExcluded);

        public static bool IsGuid(this string numero) => Utils.IsGuid(numero);

        /// <summary>
        /// Formatar uma string CNPJ
        /// </summary>
        /// <param name="CNPJ">string CNPJ sem formatacao</param>
        /// <returns>string CNPJ formatada</returns>
        /// <example>Recebe '99999999999999' Devolve '99.999.999/9999-99'</example>

        public static string FormatCNPJ(this string CNPJ) => Utils.FormatCNPJ(CNPJ);

        /// <summary>
        /// Formatar uma string CPF
        /// </summary>
        /// <param name="CPF">string CPF sem formatacao</param>
        /// <returns>string CPF formatada</returns>
        /// <example>Recebe '99999999999' Devolve '999.999.999-99'</example>

        public static string FormatCPF(this string CPF) => Utils.FormatCPF(CPF);

        public static bool IsValidEmail(this string email) => Utils.IsValidEmail(email);

        public static bool IsCnpj(this string cnpj) => Utils.IsCnpj(cnpj);

        public static bool IsCpf(this string cpf) => Utils.IsCpf(cpf);

        public static string FormatRG(this string texto) => Utils.FormatRG(texto);

        public static string FormatPhone(this string texto) => Utils.FormatPhone(texto);


        public static string OnlyNumbers(this string numeros) => Utils.OnlyNumbers(numeros);

        #endregion
    }
}
