﻿using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper.Contrib.Extensions;
using APIEstados.Models;

namespace APIEstados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private IConfiguration _config;

        public EstadosController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet("todos")]
        public IEnumerable<Estado> GetEstados()
        {
            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("DadosGeograficos")))
            {
                return conexao.GetAll<Estado>();
            }
        }

        [HttpGet("detalhes/{siglaEstado}")]
        public Estado GetDetalhesEstado(string siglaEstado)
        {
            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("DadosGeograficos")))
            {
                return conexao.Get<Estado>(siglaEstado);
            }
        }
    }
}