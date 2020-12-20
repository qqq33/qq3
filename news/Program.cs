
          using ConsoleApp888;
          using Newtonsoft.Json;
          using System;
          using System.IO;
          using System.Net;
            

namespace ConsoleApp888
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "916fa723b23241ca9c32c1745f719898";
            string response = "";

            Console.WriteLine("Показать новости России? Да/Нет \n");
            response = Console.ReadLine();
            Console.WriteLine();

            if (response.ToLower().Equals("да"))
            {
                string url = "http://newsapi.org/v2/top-headlines?country=ru&apiKey=" + key;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();


                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Root root = JsonConvert.DeserializeObject<Root>(result);
                    Console.WriteLine("Актуальные новости в России:\n");

                    foreach (Article article in root.Articles)
                    {

                        Console.Write("Источник: " + article.Source.Name + "\nЗаголовок: " + article.Title + "\nОписание: " + article.Description + "\nСсылка: " + article.Url);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Покеда");
            }
        }  
    }
}

    

