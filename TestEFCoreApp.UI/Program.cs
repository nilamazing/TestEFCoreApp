using TestEFCoreApp.Data;

namespace TestEFCoreApp.UI
{
    class Program
    {
        private static SamuraiContext _samuraiCtx=new SamuraiContext();
        private static void Main(string[] args)
        {
            Console.WriteLine("Commence testing EF Prelim");
            _samuraiCtx.Database.EnsureCreated();
            GetSamurais();
            AddSamurai();
            GetSamurais();
            Console.WriteLine("End testing EF Prelim");
        }

        private static void AddSamurai()
        {
            var samurais = _samuraiCtx.Samurais;
            samurais.Add(new Domain.Samurai()
            {
                Name = "Nilanjan Dutta"
            });

            _samuraiCtx.SaveChanges();
        }

        private static void GetSamurais()
        {
           var samurais = _samuraiCtx.Samurais.ToList();
            Console.WriteLine($"Number of Samurais={samurais.Count}");
        }
    }
}