using SenaiChamados.Domain;
using SenaiChamados.Interfaces;
using SenaiChamados.Interfaces.Application;
using SenaiChamados.Models;
using System.Collections.Generic;

namespace SenaiChamados.Application
{
    public class SetorApplication : GenericApplication<SetorModel, SetorDTO>, ISetorApplication
    {
        public SetorApplication(IGenericRepository<SetorDTO> repositorio) : base(repositorio) { }

        protected override SetorDTO BuildDTO(SetorModel model) => new()
        {
            Id = model.Id,
            Descricao = model.Descricao
        };

        protected override SetorModel BuildModel(SetorDTO dto) => new()
        {
            Id = dto.Id,
            Descricao = dto.Descricao
        };
    }
}
