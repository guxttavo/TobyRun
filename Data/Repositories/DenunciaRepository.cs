using Core.Dto;
using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class DenunciaRepository : IDenunciaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DenunciaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Bairro> BuscarBairros()
        {
            // return _dbContext.Bairros
            // .AsSingleQuery()
            // .Select(x => new Bairro
            // {
            //     Id = x.Id,
            //     Nome = x.Nome
            // }).ToListAsync();
            return _dbContext.Bairros.ToList();


        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _dbContext.Categorias.ToList();

        }

        public async Task<IEnumerable<Categoria>> BuscarSubcategorias()
        {
            return await _dbContext.Categorias
                .Where(x => x.IdCategoriaPai != null && x.Id == x.IdCategoriaPai)
                .ToListAsync();
        }

        public async Task CadastrarDenuncia(Denuncia denuncia)
        {
            await _dbContext.AddAsync(denuncia);
            await _dbContext.SaveChangesAsync();
        }

        public Denuncia BuscarDenuncia(int id)
        {
            return _dbContext.Denuncias.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Denuncia>> BuscarDenuncias()
        {
            return await _dbContext.Denuncias
                                   .Include(x => x.Bairro)
                                   .Include(x => x.Categoria)
                                   .ToListAsync();
        }

        public bool FecharDenuncia(int id)
        {
            Denuncia denuncia = BuscarDenuncia(id);

            _dbContext.Denuncias.Remove(denuncia);
            _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Denuncia>> QtdDenunciasPorBairro()
        {
            return await _dbContext.Denuncias
                                   .Select(x => new Denuncia
                                   {
                                       Data = x.Data,
                                       Bairro = new Bairro
                                       {
                                           Nome = x.Bairro.Nome
                                       },
                                       Categoria = new Categoria
                                       {
                                           Nome = x.Categoria.Nome
                                       }
                                   })
                                   .ToListAsync();
        }

        public async Task<IEnumerable<Bairro>> QtdDenunciaPorBairro()
        {
            var bairros = await _dbContext.Bairros
                                  .ToListAsync();

            foreach (var bairro in bairros)
            {
                bairro.Denuncias = await _dbContext.Denuncias
                                            .Where(x => x.IdBairro == bairro.Id)
                                            .ToListAsync();
            }

            return bairros;
        }

        public async Task<IEnumerable<Categoria>> QtdDenunciaPorCategoria()
        {
            var categorias = await _dbContext.Categorias
                                  .ToListAsync();

            foreach (var categoria in categorias)
            {
                categoria.Denuncias = await _dbContext.Denuncias
                                            .Where(x => x.IdCategoria == categoria.Id)
                                            .ToListAsync();
            }

            return categorias;
        }

        public async Task<IEnumerable<Bairro>> QtdDenunciasPorCategoriaPorBairro()
        {
            return await _dbContext.Bairros
                                    .Select(bairro => new Bairro
                                    {
                                        Nome = bairro.Nome,
                                        Denuncias = bairro.Denuncias.Select(denuncia => new Denuncia
                                        {
                                            Data = denuncia.Data,
                                            IdBairro = denuncia.IdBairro,
                                            Categoria = new Categoria
                                            {
                                                Nome = denuncia.Categoria.Nome
                                            }
                                        })
                                    })
                                    .ToListAsync();

        }

        public Denuncia EditarDenuncia(Denuncia denuncia)
        {
            Denuncia denunciaDb = BuscarDenuncia(denuncia.Id);

            denunciaDb.IdCategoria = denuncia.IdCategoria;
            denunciaDb.IdBairro = denuncia.IdBairro;
            denunciaDb.Data = denuncia.Data.ToUniversalTime();
            denunciaDb.Descricao = denuncia.Descricao;

            _dbContext.Denuncias.Update(denunciaDb);
            _dbContext.SaveChanges();


            return denunciaDb;
        }

    }
}