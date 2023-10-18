using AutoMapper;
using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Contexts;

namespace ProjetoEstacionamento.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VeiculoRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Cadastrar(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
