using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace WebClient
{
    class Program
    {
        static void Main(string[] args)
        {           
            // Создание клиента   

            Int32 port = 80; // Порт сервера                
            TcpClient client = new TcpClient("127.0.0.1", port); // Соединение с сервером
            Byte[] data = new Byte[1024]; // Буфер для хранения ответа сервера                
            String responseData = String.Empty; // Строка для хранения ответа в ASCII

            // Формирование HTML сообщения для отправки серверу                
            string Str = "GET / HTTP/1.1\n"; // Стартовая строка HTML сообщения                
            Str = Str + "Host: 127.0.0.1\r\n\r\n"; // Заголовки HTML сообщения                
            data = Encoding.ASCII.GetBytes(Str); // Приведем строку к виду массива байт
            // Отправим его клиенту
            client.GetStream().Write(data, 0, data.Length);
            Console.WriteLine("Send: \n {0}", Str);

            // Чтение данных ответа
            data = new Byte[1024];
            Int32 readBytesCount;
            readBytesCount = client.GetStream().Read(data, 0, data.Length);
            // Преобразование ответа в ASCII
            responseData = responseData + System.Text.Encoding.ASCII.GetString(data, 0, readBytesCount);            
            // ВЫвод строки
            Console.WriteLine("Received: {0}", responseData);
            // Закрытие потока и соединения с сервером
            client.Close();     

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
