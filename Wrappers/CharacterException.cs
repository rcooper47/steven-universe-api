using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace steven_api.Wrappers
{
    public class CharacterException : Exception
    {
            public CharacterException() : base()
    {
    }
    public CharacterException(string message) : base(message)
    {
    }
    public CharacterException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
    }
}