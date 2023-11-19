using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.LiteDB;
using System.IO;

namespace pr11_2
{
    namespace CourierApp
    {
        public enum WaybillStatus
        {
            Created,
            Shipped,
            Delivered
        }

        public struct CourierWaybill
        {
            public int WaybillId { get; set; }
            public DateTime CreationDate { get; set; }
            public string SenderName { get; set; }
            public string RecipientName { get; set; }
            public WaybillStatus Status { get; set; }
          
            public CourierWaybill(int id, DateTime creationDate, string sender, string recipient, WaybillStatus status)
            {
                WaybillId = id;
                CreationDate = creationDate;
                SenderName = sender;
                RecipientName = recipient;
                Status = status;
            }

        }
    }

namespace CourierApp
    {
        public class WaybillDatabase
        {
            private readonly LiteDatabase database;

            public WaybillDatabase(string dbPath)
            {
                database = new LiteDatabase(dbPath);
            }

            public void InsertWaybill(CourierWaybill waybill)
            {
                var waybillCollection = database.GetCollection<CourierWaybill>("waybills");
                waybillCollection.Insert(waybill);
            }

            public IEnumerable<CourierWaybill> GetAllWaybills()
            {
                var waybillCollection = database.GetCollection<CourierWaybill>("waybills");
                return waybillCollection.FindAll();
            }

        }
    }


namespace CourierApp
    {
        public class WaybillFileManager
        {
            public void SaveWaybillToFile(CourierWaybill waybill, string filePath)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine($"Номер КН: {waybill.WaybillId}");
                        writer.WriteLine($"Дата создания: {waybill.CreationDate}");
                        writer.WriteLine($"Имя отправителя: {waybill.SenderName}");
                        writer.WriteLine($"Имя получателя: {waybill.RecipientName}");
                        writer.WriteLine($"Статус: {waybill.Status}");
                      
                    }

                    Console.WriteLine($"Курьерская накладная сохранена в файл: {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при сохранении КН в файл: {ex.Message}");
                }
            }
        }
    }
}


