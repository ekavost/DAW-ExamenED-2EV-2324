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
        public string _password;

        private bool _lowerCase;
        private bool _upperCase;
        private bool _numbers;
        private bool _length;

        /// <summary>
        /// Constructor que asigna el valor de propiedades
        /// </summary>
        public ComprobadorDePassword()
        {
            _lowerCase = _upperCase = _numbers = _length = false;
        }

        /// <summary>
        /// <para>Metodo que comprueba si la contraseña es valida </para>
        /// <para>y define el nivel de su fortaleza</para>>
        /// </summary>
        /// <param name="password"> String con el valor de contraseña introducida</param>
        /// <returns>Un entero de 1 a 4 según el nivel de fortaleza </returns>
        public int TestPassword(string password)
        {
            _password = password;

            if (_password == null || _password.Length <= 0)
            {
                return -1; // Si la contraseña es nula o vacía, devolvemos un código de error
            }


            if (_password.Length < 6)
            {
                return 0; // No tiene la longitud mínima, error
            }

            int force = CheckForce();

            return force;
        }

        private int CheckForce()
        {
            bool lowerCase = false;
            bool upperCase = false;
            bool numbers = false;
            bool length = false;

            if (_password.Length > 12) length = true;

            // Recorremos la cadena buscando minúsculas, mayúsculas y números
            //
            foreach (char c in _password)
            {
                if (char.IsLower(c))
                {
                    lowerCase = true;
                }
            }
            foreach (char c in _password)
            {
                if (char.IsUpper(c))
                {
                    upperCase = true;
                }
            }
            foreach (char c in _password)
            {
                if (char.IsDigit(c))
                {
                    numbers = true;
                }
            }

            // Calculamos el nivel de fortaleza
            // 4: muy fuerte
            // 3: fuerte
            // 2: normal
            // 1: débil
            int force = 0;
            if (lowerCase) force++;
            if (upperCase) force++;
            if (numbers) force++;
            if (length) force++;
            return force;
        }
    }
}
