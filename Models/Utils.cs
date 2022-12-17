using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace data_bind.Models
{
    public class Utils
    {

        #region " Strings "



        public static string GetQueryString<T>(T obj, bool usingEncode = false,
                                              IEnumerable<string> propsExcluded = null) where T : class
        {

            var properties = obj.GetType().GetProperties();
            Type[] typesWriteQuery = { typeof(string),
                                       typeof(String),
                                       typeof(int),
                                       typeof(Int64),
                                       typeof(Int32),
                                       typeof(decimal),
                                       typeof(Decimal), typeof(bool), typeof(Boolean) };
            var propWriteQuery = new List<string>();
            foreach (var prop in properties)
            {
                if ((propsExcluded ?? new List<string>()).Contains(prop.Name)
                    || prop.GetValue(obj, null) == null
                    || prop.PropertyType == typeof(IList)
                    || !typesWriteQuery.Contains(prop.PropertyType)
                    )
                    continue;
                propWriteQuery.Add(prop.Name + "=" + (usingEncode == true ? HttpUtility.UrlEncode(prop.GetValue(obj, null).ToString()) : prop.GetValue(obj, null).ToString()));

            }
            return String.Join("&", propWriteQuery.ToArray());
        }

        public static string OnlyNumbers(string numbers) => String.Join("", System.Text.RegularExpressions.Regex.Split(string.IsNullOrEmpty(numbers) ? "" : numbers, @"[^\d]"));

        public static bool IsGuid(string numero)
        {

            var guidResult = Guid.Empty;
            return Guid.TryParse(numero, out guidResult);

        }

        /// <summary>
        /// Formatar uma string CNPJ
        /// </summary>
        /// <param name="CNPJ">string CNPJ sem formatacao</param>
        /// <returns>string CNPJ formatada</returns>
        /// <example>Recebe '99999999999999' Devolve '99.999.999/9999-99'</example>

        public static string FormatCNPJ(string CNPJ)
        {
            if (string.IsNullOrEmpty(CNPJ))
                return CNPJ;
            return Convert.ToUInt64(OnlyNumbers(CNPJ)).ToString(@"00\.000\.000\/0000\-00");
        }

        /// <summary>
        /// Formatar uma string CPF
        /// </summary>
        /// <param name="CPF">string CPF sem formatacao</param>
        /// <returns>string CPF formatada</returns>
        /// <example>Recebe '99999999999' Devolve '999.999.999-99'</example>
        /// 21371885893


        public static string FormatCPF(string CPF)
        {
            if (string.IsNullOrEmpty(CPF))
                return "";


            var cpfOnlyNumbers = CPF.OnlyNumbers().PadRight(11,'0').Substring(0,11);
            var cpfArray = cpfOnlyNumbers.ToCharArray();

            cpfOnlyNumbers = string.Empty;
            for (int i = 0; i < cpfArray.Length; i++)
            {
                if (i == 2 || i == 5)
                    cpfOnlyNumbers += cpfArray[i] + ".";
                else if (i == 8)
                    cpfOnlyNumbers += cpfArray[i] + "-";
                else cpfOnlyNumbers += cpfArray[i];
            }
            return cpfOnlyNumbers;
          
        }

        public static string FormatRG(string texto)
        {

            texto = texto.OnlyNumbers().PadRight(9,'0') ;
            return texto.Substring(0, 2) + "." + texto.Substring(2, 3) + "." + texto.Substring(5, 3) + "-" + texto.Substring(8, 1).ToUpper();

        } 

        public static bool IsCpf(string cpf)
        {

            cpf = OnlyNumbers(cpf);

            if (string.IsNullOrEmpty(cpf))
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsValidEmail(string email)
        {

            if (string.IsNullOrEmpty(email))
                return false;

            bool emailValido = false;
            //Expressão regular retirada de
            //https://msdn.microsoft.com/pt-br/library/01escwtf(v=vs.110).aspx
            string emailRegex = string.Format("{0}{1}",
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            try
            {
                emailValido = Regex.IsMatch(
                    email,
                    emailRegex);
            }
            catch (RegexMatchTimeoutException)
            {
                emailValido = false;
            }

            return emailValido;

        }
        public static bool IsCnpj(string cnpj)
        {
            cnpj = OnlyNumbers(cnpj);

            if (string.IsNullOrEmpty(cnpj))
                return false;


            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);

        }

        public static string GetQueryString<T>(T obj, bool encodeValue)
        {

            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + (encodeValue ? HttpUtility.UrlEncode(p.GetValue(obj, null).ToString()) : p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());

        }

        public static string FormatPhone(string texto)
        {
            texto = texto.OnlyNumbers().PadRight(12, '0');
            return texto.Substring(0, 2) + "+ (" + texto.Substring(2, 2) + ") " + texto.Substring(4,4) + "-" + texto.Substring(8, 4).ToUpper();
        }

        #endregion

        #region " Enums "

        public static T GetEnumToName<T>(string value, T defaultValue)
        {
            Enum.TryParse(typeof(T), value, true, out object res);
            if (res == null)
                return defaultValue;
            if (Enum.IsDefined(typeof(T), res))
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            return defaultValue;
        }

        public static string GetAttributeDescription<T>(T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            if (fi != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0) return attributes[0].Description;

                else return source.ToString();
            }

            return source.ToString();
        }

        public static Dictionary<int, string> EnumToDictionaryName<T>()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(" Tipo não é um enum");
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToDictionary(t => (int)(object)t, t => t.ToString());
        }

        public static Dictionary<int, string> EnumToDictionaryDescription<T>()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Tipo não é um enum");
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToDictionary(t => (int)(object)t, t => GetAttributeDescription(t));
        }


        #endregion

    }
}
