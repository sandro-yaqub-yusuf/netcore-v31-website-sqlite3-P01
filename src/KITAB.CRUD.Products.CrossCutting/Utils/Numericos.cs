namespace KITAB.CRUD.Products.CrossCutting.Utils
{
    public class Numericos
    {
        public static string ApenasNumeros(string valor)
        {
            string _onlyNumber = "";

            foreach (char s in valor)
            {
                if (char.IsDigit(s)) _onlyNumber += s;
            }

            return _onlyNumber.Trim();
        }

    }
}
