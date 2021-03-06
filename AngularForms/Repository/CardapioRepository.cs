﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrasaoHamburgueria.Model;
using BrasaoHamburgueria.Web.Context;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BrasaoHamburgueria.Web.Repository
{
    public class CardapioRepository
    {
        private BrasaoContext _contexto;

        public CardapioRepository()
        {
            _contexto = new BrasaoContext();
        }

        public DadosItemCardapioViewModel GetDadosItemCardapio(int codItemCardapio)
        {
            return _contexto.ItensCardapio
                    .Where(i => i.CodItemCardapio == codItemCardapio)
                    .Include(i => i.ObservacoesPermitidas)
                    .Include(i => i.ObservacoesPermitidas.Select(o => o.ObservacaoProducao))
                    .Include(i => i.ExtrasPermitidos)
                    .Include(i => i.ExtrasPermitidos.Select(e => e.OpcaoExtra))
                    .ToList()
                    .Select(i =>
                    new DadosItemCardapioViewModel
                    {
                        CodItemCardapio = i.CodItemCardapio,
                        Observacoes = (i.ObservacoesPermitidas != null ?
                               i.ObservacoesPermitidas.Select(o => new ObservacaoProducaoViewModel { CodObservacao = o.ObservacaoProducao.CodObservacao, DescricaoObservacao = o.ObservacaoProducao.DescricaoObservacao }).ToList() : null),
                        Extras = (i.ExtrasPermitidos != null ?
                                i.ExtrasPermitidos.Select(e => new OpcaoExtraViewModel { CodOpcaoExtra = e.OpcaoExtra.CodOpcaoExtra, DescricaoOpcaoExtra = e.OpcaoExtra.DescricaoOpcaoExtra, Preco = e.OpcaoExtra.Preco }).ToList() : null)
                    }).FirstOrDefault();
        }

        public List<ClasseItemCardapioViewModel> GetCardapio()
        {

            var retorno = _contexto.Classes
                .Include(c => c.Itens)
                .Include(c => c.Itens.Select(i => i.Classe))
                .Include(c => c.Itens.Select(i => i.Complemento))
                //.Include(c => c.Itens.Select(i => i.ObservacoesPermitidas))
                //.Include(c => c.Itens.Select(i => i.ObservacoesPermitidas.Select(o => o.ObservacaoProducao)))
                //.Include(c => c.Itens.Select(i => i.ExtrasPermitidos))
                //.Include(c => c.Itens.Select(i => i.ExtrasPermitidos.Select(e => e.OpcaoExtra)))
                .ToList()
                .Where(c => c.Itens.Where(a => a.Ativo).Count() > 0)
                .Select(c =>
                new ClasseItemCardapioViewModel
                {
                    CodClasse = c.CodClasse,
                    DescricaoClasse = c.DescricaoClasse,
                    Itens = c.Itens.Select(i =>
                        new ItemCardapioViewModel
                        {
                            CodItemCardapio = i.CodItemCardapio,
                            Nome = i.Nome,
                            Preco = i.Preco,
                            Ativo = i.Ativo,
                            /*ObservacoesPermitidas = (i.ObservacoesPermitidas != null ?
                                i.ObservacoesPermitidas.Select(o => new ObservacaoProducaoViewModel { CodObservacao = o.ObservacaoProducao.CodObservacao, DescricaoObservacao = o.ObservacaoProducao.DescricaoObservacao }).ToList() : null),
                            ExtrasPermitidos = (i.ExtrasPermitidos != null ?
                                i.ExtrasPermitidos.Select(e => new OpcaoExtraViewModel { CodOpcaoExtra = e.OpcaoExtra.CodOpcaoExtra, DescricaoOpcaoExtra = e.OpcaoExtra.DescricaoOpcaoExtra, Preco = e.OpcaoExtra.Preco }).ToList() : null),*/
                            Complemento = (i.Complemento != null ?
                                new ComplementoItemCardapioViewModel
                                {
                                    DescricaoLonga = i.Complemento.DescricaoLonga,
                                    Imagem = i.Complemento.Imagem
                                } : null)
                        }).ToList()
                }).ToList();

            foreach(var classe in retorno)
            {
                classe.Itens = classe.Itens.Where(i => i.Ativo).ToList();
            }

            return retorno;
        }
    }
}