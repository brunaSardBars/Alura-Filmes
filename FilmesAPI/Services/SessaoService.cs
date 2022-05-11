using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public List<ReadSessaoDto> RecuperaSessoes()
        {
            List<Sessao> sessoes;
            sessoes = _context.Sessoes.ToList();

            if (sessoes.Any())
                return _mapper.Map<List<ReadSessaoDto>>(sessoes);

            return null;

        }

        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            Sessao sessao = obterSessaoPorId(id);

            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return sessaoDto;
            }
            return null;
        }
        public Result AtualizaSessao(int id, UpdateSessaoDto sessaoDto)
        {
            Sessao sessao = obterSessaoPorId(id);

            if (sessao != null)
            {
                sessao = _mapper.Map(sessaoDto, sessao);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Sessão não encontrada");
        }
        public Result DeletaSessao(int id)
        {
            Sessao sessao = obterSessaoPorId(id);

            if (sessao != null)
            {
                _context.Remove(sessao);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Sessão não encontrada");
        }

        private Sessao obterSessaoPorId(int id)
        {
            return _context.Sessoes.FirstOrDefault(f => f.Id == id);
        }

    }
}
