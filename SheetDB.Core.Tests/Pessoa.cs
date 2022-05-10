using SheetDB.Implementation;

namespace SheetDB.Tests
{
    public class Pessoa
    {
        [SheetId]
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Age { get; set; }

        public string Surname { get; set; } = "test";
    }
}
