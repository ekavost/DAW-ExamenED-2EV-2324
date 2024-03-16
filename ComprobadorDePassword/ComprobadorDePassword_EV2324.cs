using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprobadorDePasswordApp
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class ComprobadorDePassword
    {
        public const string ERROR_EMPTY_PASSWORD = "La contraseña no puede estar vacía";
        public const string ERROR_SHORT_PASSWORD = "Contraseña demasiado corta";

        private const int MIN_LENGTH = 6;
        private const int SAFE_LENGTH = 12;

        private string _password;
       

        public string Password { 
            get => _password; 
            set
            {
                _password = value;

                if (value == null || value.Length <= 0)
                {
                    throw new Exception(ERROR_EMPTY_PASSWORD);
                }

                else if (value.Length < MIN_LENGTH)
                {
                    throw new Exception(ERROR_SHORT_PASSWORD);
                }
            }
        }

        /// <summary>
        /// <para>Metodo que comprueba si la contraseña es valida </para>
        /// <para>y define el nivel de su fortaleza</para>>
        /// </summary>
        /// <param name="password"> String con el valor de contraseña introducida</param>
        /// <returns>Un entero de 1 a 4 según el nivel de fortaleza </returns>
        public int TestPassword(string password)
        {
            Password = password;
       
            bool lowerCase = false;
            bool upperCase = false;
            bool numbers = false;
            bool length = false;
            int force = 0;

            if (Password.Length > SAFE_LENGTH) length = true;

            foreach (char c in Password)
            {
                if (char.IsLower(c))
                {
                    lowerCase = true;
                }
                if (char.IsUpper(c))
                {
                    upperCase = true;
                }
                if (char.IsDigit(c))
                {
                    numbers = true;
                }
            }

            if (lowerCase) force++;
            if (upperCase) force++;
            if (numbers) force++;
            if (length) force++;
            return force;
        }
    }
}
