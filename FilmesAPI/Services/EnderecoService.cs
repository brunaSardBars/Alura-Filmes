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
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperaEnderecos()
        {
            List<Endereco> enderecos;

            enderecos = _context.Enderecos.ToList();

            if (enderecos.Any())
            {
                List<ReadEnderecoDto> readDto = _mapper.Map<List<ReadEnderecoDto>>(enderecos);
                return readDto;
            }

            return null;
        }

        public ReadEnderecoDto RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = ObterEnderecoPorId(id);

            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);                
                return enderecoDto;
            }
            return null;
        }
        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = ObterEnderecoPorId(id);

            if (endereco != null)
            {
                endereco = _mapper.Map(enderecoDto, endereco);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Endereco não encontrado");
        }

        public Result DeletaEndereco(int id)
        {
            Endereco endereco = ObterEnderecoPorId(id);

            if (endereco != null)
            {
                _context.Remove(endereco);
                _context.SaveChanges();
                return Result.Ok();
            }

            return Result.Fail("Endereco não encontrado");
        }


        private Endereco ObterEnderecoPorId(int id)
        {
            return _context.Enderecos.FirstOrDefault(f => f.Id == id);
        }
    }
}
