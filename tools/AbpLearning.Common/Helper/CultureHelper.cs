namespace AbpLearning.Common.Helper
{
    using System.Globalization;

    public static class CultureHelper
    {
        public static CultureInfo[] Cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

        public static CultureInfo GetCultureInfo(string name)
        {
            try
            {
                return CultureInfo.GetCultureInfo(name);
            }
            catch (CultureNotFoundException)
            {
                return CultureInfo.CurrentCulture;
            }
        }
    }
}
