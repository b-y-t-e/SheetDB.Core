namespace SheetDB.Tests
{
    using Implementation;
    using NUnit.Framework;
    using System.IO;
    using System.Linq;

    public class ManagmentTests
    {
        [Test, Order(0)]
        public void Setup()
        {
            try
            {
                var managment = new Managment(
                    clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                    privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
                );

                managment.GetDatabase("Teste").Delete();
            }
            catch { }
        }

        [Test, Order(1)]
        public void Create_database()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.CreateDatabase("Teste");
        }

        [Test, Order(2)]
        public void Get_database()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.GetDatabase("Teste");
        }

        [Test, Order(3)]
        public void Get_all_database()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.GetAllDatabases().ToList();
        }

        [Test, Order(9999999)]
        public void Delete_database()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.GetDatabase("Teste").Delete();
        }

        [Test, Order(4)]
        public void Create_table()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.GetDatabase("Teste").CreateTable<Pessoa>("Teste");
        }

        [Test, Order(5)]
        public void Get_table()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.GetDatabase("Teste").GetTable<Pessoa>("Teste");
        }

        [Test, Order(6)]
        public void Add_Permission()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.GetDatabase("Teste").AddPermission("andrzej.bol@gmail.com", Enum.Role.reader, Enum.Type.user);
        }

        [Test, Order(7)]
        public void Get_Permission()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.GetDatabase("Teste").GetPermission("andrzej.bol@gmail.com");
        }

        [Test, Order(99996)]
        public void Delete_Permission()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.GetDatabase("Teste").GetPermission("andrzej.bol@gmail.com").Delete();
        }

        [Test, Order(8)]
        public void Update_Permission()
        {
            var managment = new Managment(
                clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
                privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
            );

            managment.GetDatabase("Teste").GetPermission("andrzej.bol@gmail.com").Update(Enum.Role.writer);
        }

        [Test, Order(99999)]
        public void Delete_table()
        {
            var managment = new Managment(
               clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
               privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
           );

            managment.GetDatabase("Teste").GetTable<Pessoa>("Teste2").Delete();
        }

        [Test, Order(99997)]
        public void Delete_Record()
        {
            var managment = new Managment(
               clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
               privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
           );

            managment.GetDatabase("Teste").GetTable<Pessoa>("Teste").Add(new Pessoa() { Id = 1, Nome = "c" }).Delete();
        }

        [Test, Order(99998)]
        public void Rename_table()
        {
            var managment = new Managment(
               clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
               privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
           );

            managment.GetDatabase("Teste").GetTable<Pessoa>("Teste").Rename("Teste2");
        }

        [Test, Order(10)]
        public void Add_Record()
        {
            var managment = new Managment(
               clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
               privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
           );

            managment.GetDatabase("Teste").
                GetTable<Pessoa>("Teste").
                Add(new Pessoa() { Id = 1, Nome = "a" });
        }

        [Test, Order(11)]
        public void Update_Record()
        {
            var managment = new Managment(
               clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
               privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
           );

            managment.GetDatabase("Teste").GetTable<Pessoa>("Teste").Add(new Pessoa() { Id = 1, Nome = "c" }).Update(new Pessoa() { Id = 2, Nome = "d" });
        }

        [Test, Order(12)]
        public void Get_by_index()
        {
            var managment = new Managment(
               clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
               privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
           );

            managment.GetDatabase("Teste").GetTable<Pessoa>("Teste").GetByIndex(1);
        }

        [Test, Order(13)]
        public void Getall()
        {
            var managment = new Managment(
               clientEmail: "driveclient@drivedb-xxxxx.iam.gserviceaccount.com",
               privateKey: File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\key.p12")
           );

            managment.GetDatabase("Teste").GetTable<Pessoa>("Teste").GetAll();
        }
    }
}
