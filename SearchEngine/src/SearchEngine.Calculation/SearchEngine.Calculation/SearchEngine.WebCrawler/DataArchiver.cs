using MySearchEngine.Core.Models;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SearchEngine.Calculation.SearchEngine.WebCrawler
{
    public class DataArchiver
    {
        private string DirectoryPath;

        public DataArchiver(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        public void ArchiveData(List<Book> books)
        {
            try
            {
                var date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").Replace(':', '_');

                var path = $"{DirectoryPath}//ArchiveData//{date}.xml";

                XmlSerializer serialiser = new XmlSerializer(typeof(List<Book>));

                TextWriter filestream = new StreamWriter(path);

                serialiser.Serialize(filestream, books);

                filestream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public string ListStrAryToXML(List<string[]> lToSerialize)
        {
            using (var strWritr = new StringWriter(new StringBuilder()))
            {
                var serializer = new XmlSerializer(typeof(List<string[]>));
                serializer.Serialize(strWritr, lToSerialize);
                return strWritr.ToString();
            }
        }
    }
}