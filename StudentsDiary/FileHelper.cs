using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public class FileHelper<T> where T:new()//typ Generic
    {
        private string _filePath;

        public FileHelper(string filePath)//kontruktor
        {
            _filePath = filePath;
        }
        public void SerializeToFile(T students)
        {
            var serializer = new XmlSerializer(typeof(T)); 
            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, students);//przekazujemy obiekty
                streamWriter.Close(); //zamykamy strumień
            }
        }

        public T DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new T();

            var serializer = new XmlSerializer(typeof(T));

            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (T)serializer.Deserialize(streamReader);//ta metoda zwraca object dlatego musimy rzutować na listę studentów
                streamReader.Close();
                //stream.Dispose() zawsze zostanie wykonane dzięki metodzie using
                return students;
            }
        }








    }
}
