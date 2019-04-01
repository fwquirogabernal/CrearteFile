namespace InventarioTemporal
{
    public static class Reloj
    {
        private static int hora = 1;

        public static int IncrementoDeTiempo() => hora++;

        public static void ActualizarHoraJSON(int h)
        {
            if(hora == 0) hora = h;
            if (hora != 0) hora += h;
        }
    }
}
