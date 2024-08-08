using CadastroFuncionario.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroFuncionario.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {  
        }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
