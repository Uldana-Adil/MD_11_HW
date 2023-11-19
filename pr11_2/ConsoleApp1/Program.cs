using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourierApp1
{
    class Program
    {
        static void Main()
        {
            try
            {
                var dbPath = "path_to_database.db";
                var db = new WaybillDatabase(dbPath);

                Console.WriteLine("Введите данные для создания КН:");
                Console.Write("Имя отправителя: ");
                var senderName = Console.ReadLine();

                Console.Write("Имя получателя: ");
                var recipientName = Console.ReadLine();

                var waybill = new CourierWaybill
                {
                    WaybillId = GenerateUniqueId(), 
                    CreationDate = DateTime.Now,
                    SenderName = senderName,
                    RecipientName = recipientName,
                    Status = WaybillStatus.Created
                };

                db.InsertWaybill(waybill);

                var fileManager = new WaybillFileManager();
                var filePath = "path_to_save_file.txt";
                fileManager.SaveWaybillToFile(waybill, filePath);

                Console.WriteLine("Курьерская накладная успешно создана!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

 
    }
}

