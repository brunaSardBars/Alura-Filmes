using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;        

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;       
            _context = context;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes.Any())
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }

            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            Filme filme = obterFilmePorId(id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                filmeDto.HoraDaConsulta = DateTime.Now;
                return filmeDto;
            }
            return null;
        }

        public UpdateFilmeDto AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = obterFilmePorId(id);

            if (filme != null)
            {
                filme = _mapper.Map(filmeDto, filme);
                _context.SaveChanges();
                return _mapper.Map<UpdateFilmeDto>(filme);
            }
            return null;
        }

        public Filme DeletaFilme(int id)
        {
            Filme filme = obterFilmePorId(id);

            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();                
            }

            return filme;
        }

        private Filme obterFilmePorId(int id)
        {
            return _context.Filmes.FirstOrDefault(f => f.Id == id);
        }
    }
}
