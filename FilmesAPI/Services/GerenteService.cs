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
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<ReadGerenteDto> RecuperaGerentes()
        {
            List<Gerente> gerentes;

            gerentes = _context.Gerentes.ToList();

            if (gerentes.Any())
            {
                List<ReadGerenteDto> readDto = _mapper.Map<List<ReadGerenteDto>>(gerentes);
                return readDto;
            }

            return null;
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            Gerente gerente = ObterGerentePorId(id);

            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);                
                return gerenteDto;
            }
            return null;
        }
        public Result AtualizaGerente(int id, UpdateGerenteDto gerenteDto)
        {
            Gerente gerente = ObterGerentePorId(id);

            if (gerente != null)
            {
                gerente = _mapper.Map(gerenteDto, gerente);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Gerente não encontrado");
        }

        public Result DeletaGerente(int id)
        {
            Gerente gerente = ObterGerentePorId(id);

            if (gerente != null)
            {
                _context.Remove(gerente);
                _context.SaveChanges();
                return Result.Ok();
            }

            return Result.Fail("Gerente não encontrado");
        }


        private Gerente ObterGerentePorId(int id)
        {
            return _context.Gerentes.FirstOrDefault(f => f.Id == id);
        }
    }
}
