using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SplittingTheBill
{
    class Program
    {

        static void Main(string[] args)
        {
                String FilePathRead = Console.ReadLine();
                ReadFromFile(FilePathRead);
        }

        public static void ReadFromFile(String filePath)
        {

            StreamWriter sw = File.CreateText(filePath+".out");
            FileStream reader = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(reader);

            String data = "";
            List<float> list = new List<float>();


            while ((data = sr.ReadLine()) != null)
            {
                list.Add(float.Parse(data));
            }

            float[] arr = list.ToArray();
            int num = 0;
            float x = arr.Length;

            while (num < (arr.Length - 1))
            {

                float trips = arr[num];
                float b = 0;
                List<float> list2 = new List<float>();
                List<float> list3 = new List<float>();
                
                for (int j = 0; j < trips; j++)
                {
                    num++;
                    float purchases = arr[num];
                    float a = 0;

                    for (int k = 0; k < purchases; k++)
                    {
                        list2.Add(arr[num + 1]);
                        a = a + arr[num + 1];
                        num++;

                    }
                    
                    b += a;
                    list3.Add(a);
                }
                float avg = b / trips;
                for (int l = 0; l <list3.Count(); l++)
                {
                    if (avg<list3[l])
                    {
                        float m = list3[l]-avg;
                        sw.WriteLine("("+Math.Round(m,2)+")");
                    }
                    else if (avg > list3[l])
                    {
                        float m = avg - list3[l];
                        sw.WriteLine(Math.Round(m, 2));
                    }
                }
                sw.WriteLine("");

                list2.Clear();

                num++;

            }

            sw.Flush();
        }
    }
    
}
