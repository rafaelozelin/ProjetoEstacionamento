using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Contexts;

namespace ProjetoEstacionamento.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VagaRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Cadastrar(List<Vaga> vagas)
        {
            _context.Vagas.AddRange(vagas);
            await _context.SaveChangesAsync(); 
        }

        public async Task<List<Vaga>> Consultar()
        {
            var vagas = await _context.Vagas
                .Include(v => v.Veiculos)
                .ToListAsync();

            return vagas;
        }
    }
}
