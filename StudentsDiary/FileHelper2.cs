using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public class FileHelper2<T> where T : new()//typ Generic
    {


        //private string _filePath;
        private string _filePath2;


        public FileHelper2(string filePath2)//kontruktor
        {
            _filePath2 = filePath2;
        }
        public void SerializeToFile(T classes)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var streamWriter = new StreamWriter(_filePath2))
            {
                serializer.Serialize(streamWriter, classes);//przekazujemy obiekty
                streamWriter.Close(); //zamykamy strumień
            }
        }

        public T DeserializeFromFile()
        {
            if (!File.Exists(_filePath2))
                return new T();

            var serializer = new XmlSerializer(typeof(T));

            using (var streamReader = new StreamReader(_filePath2))
            {
                var classes = (T)serializer.Deserialize(streamReader);//ta metoda zwraca object dlatego musimy rzutować na listę studentów
                streamReader.Close();
                //stream.Dispose() zawsze zostanie wykonane dzięki metodzie using
                return classes;
            }
        }

    }



}

