using System.IO;
using System.Net.NetworkInformation;
using System.Xml.Xsl;

namespace Lab15_1
{
    public class FileReader
    {
        private static string path1 = "..\\..\\task1.txt";
        private static string path2 = "..\\..\\task1_2.txt";
        public static Company[] Read()
        {
            var reader = new StreamReader(path1);
            string info = reader.ReadToEnd();
            string[] infoArray = info.Split('\n');
            Company[] result = new Company[infoArray.Length];
            int count = 0;
            foreach (var elem in infoArray)
            {
                if (elem == "")
                    break;
                result[count] = new Company(elem);
                count++;
            }
            return result;
        }
        public static UniversityUnit[] ReadUniversityUnits()
        {
            var reader = new StreamReader(path2);
            string info = reader.ReadToEnd();
            string[] infoArray = info.Split('\n');
            UniversityUnit[] result = new UniversityUnit[infoArray.Length];
            int count = 0;
            foreach (var elem in infoArray)
            {
                if (elem == "")
                    break;
                result[count] = new UniversityUnit(elem);
                count++;
            }
            return result;
        }
    }
}