﻿using CursoOnline.Web.Models;
using CursoOnline.Web.Models.Enums;

namespace CursoOnline.DominioTest._Builder
{
	internal class CursoBuilder
	{
		private string _nome = "informatica básica";
		private double _cargaHoraria = 20f;
		private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
		private double _valor = 950f;
		private string _descricao = "Uma descrição";
		private int _id = 223;

		public static CursoBuilder Novo() 
		{
			return new CursoBuilder();
		}

		public CursoBuilder ComNome(string nome)
		{
			_nome = nome;
			return this;
		}

		public CursoBuilder ComDescricao(string descricao)
		{
			_descricao = descricao;
			return this;
		}

		public CursoBuilder ComCargaHoraria(double cargaHoraria)
		{
			_cargaHoraria = cargaHoraria;
			return this;
		}

		public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
		{
			_publicoAlvo = publicoAlvo; 
			return this;
		}

		public CursoBuilder ComValor(double valor)
		{
			_valor = valor;
			return this;
		}

		public CursoBuilder ComId(int id)
		{
			_id = id;
			return this;
		}

		public Curso Build()
		{
			return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
		}
	}
}
