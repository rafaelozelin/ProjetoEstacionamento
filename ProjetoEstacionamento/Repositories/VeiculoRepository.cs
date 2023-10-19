using Microsoft.EntityFrameworkCore;
using ProjetoEstacionamento.Contexts;
using ProjetoEstacionamento.Entities;

namespace ProjetoEstacionamento.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly DataContext _context;

        public VeiculoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CadastrarVeiculoAsync(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<Veiculo> GetById(int id)
        {
            var veiculo = await _context.Veiculos
                .SingleOrDefaultAsync(c => c.Id == id);

            return veiculo;
        }

        public async Task<List<Veiculo>> GetByEntrada(DateTime entrada)
        {
            var veiculos = await _context.Veiculos
                .Where(c => c.Entrada == entrada).ToListAsync();

            return veiculos;
        }

        public async Task AtulizarVeiculoAsync(Veiculo veiculo)
        {
            _context.Entry(veiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        } 
    }
}
