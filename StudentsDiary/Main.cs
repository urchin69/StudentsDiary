using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public partial class Main : Form
    {
        // private string _filePath = $@"{Environment.CurrentDirectory}\students.txt"; //lub  bardziej poprawna wersja:
        private string _filePath =  Path.Combine(Environment.CurrentDirectory, "students.txt"); //dzięki takiemu zapisowi ścieżka jest sklejana z argumentów
        //przy łączeniu ścieżek używaj metody Combine, sciezka poddana jest validacji
        public Main()//konstruktor
        {
            InitializeComponent();

            // var students = new List<Student>();
            // students.Add(new Student { FirstName = "Jan" });
            // students.Add(new Student { FirstName = "Marek" });
            // students.Add(new Student { FirstName = "Małgosia" });

            //SerializeToFile(students);//zpisuje liste studentów d pliku ".txt" w formacie XML, students -to lista studentów

            var students = DeserializeFromFile();
            //foreach   (var item in students)
            //{
            //    MessageBox.Show(item.FirstName);  
            //}    lub jak poniżej
            foreach (var student in students)
            {
                MessageBox.Show(student.FirstName);
            }





        }
        //public void SerializeToFile(List<Student> students)
        //{
        //    var serializer = new XmlSerializer(typeof(List<Student>)); //aby zrobić serializację do XML potrzebujemy obektu klasy XML serialiser ,
        //    //jako argument przekzuje się typ który chcemy serializować, chcemy zapisywać listę obieltów klasy students
        //     //użyjemy operatora typeOf który zwróci typ z(List<Student> students)

        //    StreamWriter streamWriter = null;

        //    try
        //    {

        //        streamWriter = new StreamWriter(_filePath);//u góry _filePath =  Path.Combine
        //        serializer.Serialize(streamWriter, students);//przekaujemy obiekty
        //        streamWriter.Close(); //zamykamy strumień
        //        //streamWriter.Dispose();//usuwanie z pamięci metodą Dispose, może być tak że metoda Serialise rzuci wyjątek i kod poniżej się nie wykona, obiekt strem nie zostanie wyczyszczony z pamięci, musimy zapewnić aby metoda Dispose zawsze została wykonana używamy do tego try finally
        //    }
        //    finally
        //    {
        //        streamWriter.Dispose();
        //    }


        //}

        //drugi sposó z using
        public void SerializeToFile(List<Student> students)
        {
            var serializer = new XmlSerializer(typeof(List<Student>)); 
            using (var streamWriter = new StreamWriter(_filePath))//jezeli w using jest deklaracja jakiegoś obiektu to zawsze ,
                                                                  //w każdym przypadku na koniec po wykonaniu różnych operacji
                                                                  //zostanie na tym obiekcie wywołana metoda Dispose()
            {
                serializer.Serialize(streamWriter, students);//przekaujemy obiekty
                streamWriter.Close(); //zamykamy strumień
            }
        }

        //metoda do zwracania studentów
        public List<Student> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();
            {

            }
            var serializer = new XmlSerializer(typeof(List<Student>));

            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (List<Student>)serializer.Deserialize(streamReader);//ta metoda zwraca object dlatego musimy rzutować na listę studentów
                streamReader.Close();
                //stream.Dispose() zawsze zostanie wykonane dzię metodzie using
                return students;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
