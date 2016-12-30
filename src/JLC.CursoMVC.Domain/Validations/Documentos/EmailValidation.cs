﻿
using System.Text.RegularExpressions;

namespace JLC.CursoMVC.Domain.Validations.Documentos
{
    public class EmailValidation
    {
        public static bool Validate(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9]*[a-z0-9])? )\Z", RegexOptions.IgnoreCase);
        }
    }
}
