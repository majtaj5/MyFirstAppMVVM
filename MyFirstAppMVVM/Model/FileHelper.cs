using System.IO;

namespace MyFirstAppMVVM.Model
{
    public static class FileHelper
    {
        private const string nameFile = "property.txt";
        public static void Save(this ModelMyFirstAppMVVM model)
        {
            string chain= model.Value.ToString();
            File.WriteAllText(nameFile, chain);
        }
           public static ModelMyFirstAppMVVM Read()
        {
            try
            {
                string chain = File.ReadAllText(nameFile);
                double value = double.Parse(chain);
                return new ModelMyFirstAppMVVM() { Value = value };
            }
            catch
            {
                return new ModelMyFirstAppMVVM() { Value = 0 };
            }

        }
            
    }
}
