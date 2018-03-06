using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;

namespace DellChallange.Repository.Repositories
{
    public class ClassificationRepository : RepositoryBase<Classification>, IClassificationRepository
    {
        public ClassificationRepository(DellContext kondominiumContext) : base(kondominiumContext)
        {
        }

        public void Salvar(Classification usuario)
        {
            if (usuario.Id == 0)
            {
                Inserir(usuario);
            }
            else
            {
                Atualizar(usuario);
            }
        }
    }
}
