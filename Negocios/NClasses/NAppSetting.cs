using Datos.Classes;

namespace Negocios.NClasses
{
    public class NAppSetting
    {
        private readonly AppSetting setting = new AppSetting();

        public string GetConnectionString(string key)
        {
            return setting.GetConnectionString(key);
        }
        public void SaveConnectionString(string key, string value)
        {
            setting.SaveConnectionString(key, value);
        }
    }
}
