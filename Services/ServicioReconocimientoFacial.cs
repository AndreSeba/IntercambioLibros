using System;

namespace IntercambioLibros.Services
{
    public class ReconocimientoFacialService
    {
        public Task<int> ObtenerSimilitudAsync(string base64A, string base64B)
        {
            int distancia = CalcularDistanciaLevenshtein(base64A, base64B);
            int longitudMaxima = Math.Max(base64A.Length, base64B.Length);
            int similitud = 100 - (int)((double)distancia / longitudMaxima * 100);
            similitud = Math.Max(0, Math.Min(100, similitud));
            return Task.FromResult(similitud);
        }

        // Método para calcular la distancia de Levenshtein entre dos cadenas
        private int CalcularDistanciaLevenshtein(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return t.Length;
            if (string.IsNullOrEmpty(t)) return s.Length;

            var d = new int[s.Length + 1, t.Length + 1];

            for (int i = 0; i <= s.Length; i++)
                d[i, 0] = i;

            for (int j = 0; j <= t.Length; j++)
                d[0, j] = j;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    int costo = (s[i - 1] == t[j - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1,     // eliminación
                                 d[i, j - 1] + 1),    // inserción
                        d[i - 1, j - 1] + costo);     // sustitución
                }
            }

            return d[s.Length, t.Length];
        }
    }
}
