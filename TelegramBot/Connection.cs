using System.Data.SQLite;

namespace TelegramBot
{
    class Connection
    {
        static readonly SQLiteConnection SqlString = new SQLiteConnection("Data Source=.\\telegramDB.db"); // Debug Klasörümüzdeki database Dosyamızın  adını yazdık veritabanıadi.s3db gibi
        public static SQLiteConnection baglanti = new SQLiteConnection(SqlString);

        public static void sqlconnection()
        {
            baglanti.Open();
        }
        public static bool IsOpen()
        {
            if (baglanti == null)
                return false;
            else
                return true;
        }
    }
}
