using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprobadorDePasswordApp
{
    using System;
    using System.Text.RegularExpressions;

    public class ComprobadorDePassword
    {
        private string password;
        //private bool _lowerCase;
        //private bool _upperCase;
        //private bool _numbers;
        //private bool _length;

        private const int MIN_LENGTH = 6;
        private const int SAFE_LENGTH = 12;

        //public ComprobadorDePassword()
        //{
        //    _lowerCase = _upperCase = _numbers = _length = false;
        //}

        public string Password { get => password; set => password = value; }

        /// <summary>
        /// <para>Metodo que comprueba si la contraseña es valida </para>
        /// <para>y define el nivel de su fortaleza</para>>
        /// </summary>
        /// <param name="password"> String con el valor de contraseña introducida</param>
        /// <returns>Un entero de 1 a 4 según el nivel de fortaleza </returns>
        public int TestPassword(string password)
        {
            Password = password;

            if (Password == null || Password.Length <= 0)
            {
                return -1; 
            }

            else if (Password.Length < MIN_LENGTH)
            {
                return 0; 
            }

            else
            {
                return CheckForce();
            }
        }

        /// <summary>
        /// Método que comprueba el nivel de fortaleza de la contraseña introducida
        /// </summary>
        /// <returns>El nivel de fortaleza de la contraseña de 1 (menos fuerte) a 4 (más fuerte)</returns>
        private int CheckForce()
        {
            bool lowerCase = false;
            bool upperCase = false;
            bool numbers = false;
            bool length = false;

            if (Password.Length > SAFE_LENGTH) length = true;

            foreach (char c in Password)
            {
                if (char.IsLower(c))
                {
                    lowerCase = true;
                }
            }
            foreach (char c in Password)
            {
                if (char.IsUpper(c))
                {
                    upperCase = true;
                }
            }
            foreach (char c in Password)
            {
                if (char.IsDigit(c))
                {
                    numbers = true;
                }
            }

            int force = 0;
            if (lowerCase) force++;
            if (upperCase) force++;
            if (numbers) force++;
            if (length) force++;
            return force;
        }
    }
}
