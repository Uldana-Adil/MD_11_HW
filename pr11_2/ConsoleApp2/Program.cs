using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierApp2
{
    class Program
    {
        static void Main()
        {
            try
            {
                var dbPath = "path_to_database.db";
                var db = new WaybillDatabase(dbPath);

                var waybills = db.GetAllWaybills().ToList();

                Console.WriteLine("Список всех КН:");
                foreach (var waybill in waybills)
                {
                    Console.WriteLine($"Номер КН: {waybill.WaybillId}");
                    Console.WriteLine($"Дата создания: {waybill.CreationDate}");
                    Console.WriteLine($"Имя отправителя: {waybill.SenderName}");
                    Console.WriteLine($"Имя получателя: {waybill.RecipientName}");
                    Console.WriteLine();
                }

                Console.WriteLine("Введите ID КН для получения подробной информации:");
                int waybillId;
                if (int.TryParse(Console.ReadLine(), out waybillId))
                {
                    var detailedWaybill = waybills.FirstOrDefault(w => w.WaybillId == waybillId);
                    if (detailedWaybill != null)
                    {
                        Console.WriteLine($"Подробная информация о КН {waybillId}:");
                       
                    }
                    else
                    {
                        Console.WriteLine("Курьерская накладная с указанным ID не найдена.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный формат ID КН.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

    }
}

