using DataArchiver.Models;
using System.Xml.Serialization;

namespace DataArchiver.UseCase
{
    public class ArchiveData : IArchiveData
    {
        private string DirectoryPath;

        public ArchiveData()
        {
            DirectoryPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);
        }

        public Task<ArchiveDataResponse> ArchiveDataUseCase(List<Book> books)
        {
            var archiveDartaReport = new ArchiveDataResponse() { Status = 2, ErrorMessage = "", Timestamp = DateTime.Now };

            try
            {
                var date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").Replace(':', '_');

                var path = $"{DirectoryPath}\\Archive";

                EvaluatePath(path);
                path = $"{path}\\{date}.xml";

                XmlSerializer serialiser = new XmlSerializer(typeof(List<Book>));

                TextWriter filestream = new StreamWriter(path);

                serialiser.Serialize(filestream, books);

                filestream.Close();

                archiveDartaReport.Status = 0;
                archiveDartaReport.Timestamp = DateTime.Now;

                return Task.FromResult(archiveDartaReport);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                archiveDartaReport.ErrorMessage = "Błąd";

                return Task.FromResult(archiveDartaReport);
            }
        }

        private void EvaluatePath(String path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(path);

                di.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
