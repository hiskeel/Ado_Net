using System;
using System.Data.Entity;
using System.Linq;

namespace _9_Fix_model_First
{
    public class SoftServeDB : DbContext
    {
        // Контекст настроен для использования строки подключения "SoftServeDB" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "_9_Fix_model_First.SoftServeDB" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "SoftServeDB" 
        // в файле конфигурации приложения.
        public SoftServeDB()
            : base("name=SoftServeDB")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


}