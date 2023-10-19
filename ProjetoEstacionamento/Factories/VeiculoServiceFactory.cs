using ProjetoEstacionamento.Enums;
using ProjetoEstacionamento.Services;

namespace ProjetoEstacionamento.Factories
{
    public interface IVeiculoServiceFactory
    {
        public IVeiculoService Create(ETipoVeiculo tipoVeiculo);
    }
    public class VeiculoServiceFactory : IVeiculoServiceFactory
    {
        private readonly Func<IEnumerable<IVeiculoService>> _collectionService;

        public VeiculoServiceFactory(Func<IEnumerable<IVeiculoService>> collectionService)
        {
            _collectionService = collectionService;
        }

        public IVeiculoService Create(ETipoVeiculo tipoVeiculo)
        {
            var service = _collectionService().FirstOrDefault(c => c.TipoVeiculo == tipoVeiculo);

            return service ?? throw new Exception("Não encontramos esse tipo de veículo");
        }
    }
}
