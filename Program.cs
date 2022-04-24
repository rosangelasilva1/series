using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() !="X")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                    ListarSeries();
                    break;
                   case "2":
                    InserirSeries();
                    break;
                   case "3":
                     AtualizarSerie();
                    break;
                   case "4":
                     ExcluirSerie();
                    break;
                   case "5":
                     VisualizarSerie();
                    break;
                   case "6":
                     MostrarExcluidos();
                    break;                    
                   case "C":
                    Console.Clear();
                    break;

                   default:
                    throw new ArgumentOutOfRangeException();
                }

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

         private static string ObterOpcaoUsuario()
          {

            Console.WriteLine();
            Console.WriteLine("Séries!!");
            Console.WriteLine("Informe a Opção Desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar nova Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("6 - Mostrar EXcluídos");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;

        } 
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}


        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaId(indiceSerie);

			Console.WriteLine(serie);
		}


        private static void MostrarExcluidos()
		{
			Console.WriteLine("Listar Séries Excluídas");

            var listaExcluidos = repositorio.ListaExcluidos();

            if (listaExcluidos.Count != 0)
            {
                foreach (var serie in listaExcluidos)
                {
                Console.WriteLine("#ID {0}: - {1} - Excluído: {2}", serie.retornaId(), serie.retornaTitulo(), serie.retornaExcluido() ? "Sim" : "Não");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma serie excluída");
                return;
            }
        }
        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero : ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}



        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count != 0)
            {
                foreach (var serie in lista)
                {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
            else
            {
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }
        }


        private static void InserirSeries()
        {

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} {1}",i,Enum.GetName(typeof(Genero),i));
            }

            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());


            Console.Write("Digite Título da Série: ");
            string  entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano: ");
            int  entradaAno = int.Parse(Console.ReadLine());


            Console.Write("Digite a Descrição da Série: ");
            string  entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id:repositorio.ProximoId(),
                                genero: (Genero) entradaGenero,
                                titulo: entradaTitulo ,              
                                ano: entradaAno,
                                descricao: entradaDescricao); 
            
            repositorio.Insere(novaSerie);


     }

      
    }
}

