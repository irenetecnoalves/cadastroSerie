using System;

namespace Cadastro.Serie
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
          string opcaoUsuario = ObterPorUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            { 
            switch(opcaoUsuario)
                {
                    case "1":
                        ListaSerie();
                        break;


                    case "2":
                        InserirSerie();
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


                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                   
                }
                opcaoUsuario =ObterPorUsuario();
            }
            Console.WriteLine("Obrigado por ultilizar nosso APP");
            Console.ReadLine();
           
        }
          private static void ExcluirSerie()
        {
           Console.WriteLine("Digite o id para excluir Serie");
           int indiceSerie = int.Parse(Console.ReadLine());
           repositorio.Exclui(indiceSerie);
        }

          private static void  VisualizarSerie()
        {
           Console.WriteLine("Digite o id para excluir Serie");
           int indiceSerie = int.Parse(Console.ReadLine());
           var serie = repositorio.RetornaPorId(indiceSerie);
           Console.WriteLine(serie);

           
        }
       
       


          private static void AtualizarSerie()
        {
           Console.WriteLine("Digite o id da Serie");
           int indiceSerie = int.Parse(Console.ReadLine());

           foreach(int i in Enum.GetValues(typeof(Genero)))
           {
               Console.WriteLine("[0}.{1}", i,Enum.GetName(typeof(Genero), i));
           }
           Console.Write("Digite o gênero entre as opções acima: ");
           int entradaGenero = int.Parse(Console.ReadLine());

           Console.Write("Digite o Titulo da Série: ");
           string entradaTitulo =Console.ReadLine();

           Console.Write("Digite o ano da Serie");
           int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descirção da Serie");
           string  entradaDescricao = Console.ReadLine();

           Serie atualizaSerie = new Serie(Id: indiceSerie,genero:(Genero)entradaGenero,titulo:entradaTitulo,
           ano:entradaAno,descricao:entradaDescricao);

           repositorio.Atualiza(indiceSerie, atualizaSerie);

        }
        



        


        private static void ListaSerie()
        {
            Console.WriteLine("Listar Series:");
            var lista = repositorio.Lista();
            if(lista.Count ==0)
            {
                Console.WriteLine("Nenhuma Serie Cadastrada.");
                return;
            }
            foreach (var Serie in lista)
            {
                var excluido = Serie.retornaExcluido();
                Console.WriteLine("# ID {0} : . {1} - {2}", Serie.retornaId(), Serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static void InserirSerie()
        {
           Console.WriteLine("Inserir nova Serie");

           foreach(int i in Enum.GetValues(typeof(Genero)))
           {
               Console.WriteLine("[0}.{1}", i,Enum.GetName(typeof(Genero), i));
           }
           Console.Write("Digite o gênero entre as opções acima: ");
           int entradaGenero = int.Parse(Console.ReadLine());

           Console.Write("Digite o Titulo da Série: ");
           string entradaTitulo =Console.ReadLine();

           Console.Write("Digite o ano da Serie");
           int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descirção da Serie");
           string  entradaDescricao = Console.ReadLine();

           Serie novaSerie = new Serie(Id: repositorio.ProximoId(),genero:(Genero)entradaGenero,titulo:entradaTitulo,
           ano:entradaAno,descricao:entradaDescricao);

           repositorio.Insere(novaSerie);



        }
        




        private static string ObterPorUsuario()
            {

                Console.WriteLine();
                Console.WriteLine("Escolha as melhores Series:");
                Console.WriteLine();
                Console.WriteLine("Informe a opção desejada :");
                Console.WriteLine();
                Console.WriteLine("1- Listar Series");
                Console.WriteLine("2- Inserir Nova Serie");
                Console.WriteLine("3- Atualizar Serie");
                Console.WriteLine("4- Excluir Serie");
                Console.WriteLine("5- Visualizar Serie");
                Console.WriteLine("C- Limapar a Tela");
                Console.WriteLine("S- Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;








            }
        
    }
}
