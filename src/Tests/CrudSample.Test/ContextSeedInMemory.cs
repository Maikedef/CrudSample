using CrudSample.Infrastructure.Data;
using CrudSample.Domain.Entities.Empresas;
namespace CrudSample.Test
{
    public class ContextSeedInMemory
    {
        public static void Seed(CrudSampleDbContext dbContext)
        {
            dbContext.Empresas.Add(new Empresa(
                "Company 123 teste",
                "25.501.456/0001-15",
                "62 9 9999-7777",
                new Endereco
                    (
                        "Rua 26c Quadra25",
                        "01",
                        "Hilda",
                        "Aparecida de Goiânia",
                        "Goiás"
                    )
            ));

            dbContext.Empresas.Add(new Empresa(
                "Polo emp teste",
                "25.501.456/0001-15",
                "62 9 9999-7777",
                new Endereco
                        (
                            "Rua 10 Quadra 69",
                            "01",
                            "Cardoso",
                            "Aparecida de Goiânia",
                            "Goiás"
                        )
                ));

            dbContext.SaveChanges();
        }
    }
}
