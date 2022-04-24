
using System;
using System.Collections.Generic;
using System.Linq;
using Series.interfaces;

namespace Series
{
  public class SerieRepositorio : IRepositorio<Serie>
  {
   
   private List<Serie> listaSerie = new List<Serie>();
    public void Atualiza(int id, Serie objeto)
    {
      listaSerie[id]= objeto;
    }

    public void Exclui(int id)
    {
      listaSerie[id].Excluir();
    }

    public void Insere(Serie objeto)
    {
        listaSerie.Add(objeto);
    }

    public List<Serie> Lista()
    {
      return listaSerie;
    }


    public List<Serie> ListaExcluidos()
    {

      List<Serie> lstExcluidos = new List<Serie>();
      
      lstExcluidos =  listaSerie.Where(e => e.retornaExcluido() ==true).ToList();
      
      return lstExcluidos;
    }
    public int ProximoId()
    {
      return listaSerie.Count;
    }

    public Serie RetornaId(int id)
    {
      return listaSerie[id];
    }
  }
}