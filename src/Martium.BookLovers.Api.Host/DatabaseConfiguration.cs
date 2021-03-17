using System.IO;
using System.Reflection;

namespace Martium.BookLovers.Api.Host
{
    public class DatabaseConfiguration
    {
        private static readonly string DatabaseName = "BookLovers";

        public static string DatabaseFolder => $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\..\\..\\..\\..\\Database";
        public static string DatabaseFile => $"{DatabaseFolder}\\{DatabaseName}.db";
        public static string ConnectionString => $"Data Source={DatabaseFile};Version=3;UseUTF16Encoding=True;foreign keys=true;";
    }
}
