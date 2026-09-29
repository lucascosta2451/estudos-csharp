// Sistema de cadastro de produto
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;


namespace Estoque
{
    

public class AdicionarProduto
{
    private static int _contadorid = 0;
    public int id {get; private set;}
    public string nomeproduto {get; set;}
    public int quantidadeprodutos {get; set;}

    public AdicionarProduto(string nome)
        {
                _contadorid++;
                id = _contadorid;
                nomeproduto = nome;

        }

    public override string ToString()
        {
            return $"id = {id}, nome = {nomeproduto}, quantidade = {quantidadeprodutos}";
        }

}

public class GuardarProduto
{
     public List<AdicionarProduto> produtos = new List<AdicionarProduto>();



     public static void Main()
        {
            GuardarProduto guardarProduto = new GuardarProduto();
           guardarProduto.produtos.Add(new AdicionarProduto("treloso"){quantidadeprodutos = 100});
           guardarProduto.produtos.Add(new AdicionarProduto("Pippos"){ quantidadeprodutos = 80});
           guardarProduto.produtos.Add(new AdicionarProduto("Doritos"){quantidadeprodutos = 150}); 

             
            bool continuar = true;
            while (continuar)
            {
            Console.WriteLine("olá jogador! escolha a opção que deseja: ");
            Console.WriteLine("1- adicionar Produto");
            Console.WriteLine("2- Listar Todos os Produtos");
            Console.WriteLine("3- Buscar por nome");
            Console.WriteLine("4- Buscar por id");
            Console.WriteLine("5- Editar Produto");
            Console.WriteLine("6- Remover um produto");
            Console.WriteLine("0- Sair");
            
            string ?opcao = Console.ReadLine();
          
              if(int.TryParse(opcao, out int opcaon))
            {
                switch (opcaon)
                {
                    case 1:
                        Console.WriteLine("Nome do produto:");
                        string ?nomeprodutodig = Console.ReadLine();
                        Console.WriteLine("Quantidade de produtos:");
                        string ?quantidadedeprodutosdig = Console.ReadLine();
                        if(int.TryParse(quantidadedeprodutosdig, out int quantidadedeprodutosdign))
                        if(!string.IsNullOrEmpty(nomeprodutodig))
                        guardarProduto.produtos.Add(new AdicionarProduto(nomeprodutodig){quantidadeprodutos = quantidadedeprodutosdign});
                        break;
                    
                    case 2:
                        foreach (var produto in guardarProduto.produtos)
                        {
                            Console.WriteLine(produto);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Digite o nome:");
                        string ?buscanome = Console.ReadLine();
                        foreach (var produto in guardarProduto.produtos)
                            {
                               if (produto.nomeproduto == buscanome)
                                Console.WriteLine(produto);
                            }
                            break;
                        
                    case 4:
                        Console.WriteLine("Digite o Id:");
                        string ?buscaid = Console.ReadLine();
                        if(int.TryParse(buscaid, out int buscaidi))
                        foreach (var produto in guardarProduto.produtos)
                            {
                               if (produto.id == buscaidi)
                                Console.WriteLine(produto);
                            }
                            break;
                    
                    case 5:
                        Console.WriteLine("Digite o Id do produto que deseja editar");
                        string ?editarid= Console.ReadLine();
                        if(int.TryParse(editarid, out int editaridi))
                            {
                            foreach( var produto in guardarProduto.produtos)
                                {
                                    if(produto.id == editaridi)
                                    {
                                        Console.WriteLine("novo nome:");
                                        string ?novoNome = Console.ReadLine();

                                        Console.WriteLine("Nova quantidade:");
                                        string ?novaQuantidade = Console.ReadLine();

                                        if (!string.IsNullOrEmpty(novoNome))
                                        {
                                            produto.nomeproduto = novoNome;
                                        }
                                        if(int.TryParse(novaQuantidade, out int novaQuantidadei))
                                        {
                                            produto.quantidadeprodutos = novaQuantidadei;
                                        }

                                    }
                    

                                }
                            }
                        break;

                    case 6:
                        Console.WriteLine("Digite o Id do produto que deseja remover: ");
                        string ?idlocal= Console.ReadLine();
                        if(int.TryParse(idlocal, out int idlocali))
                            {
                            foreach( var produto in guardarProduto.produtos)
                                {
                                    if(produto.id == idlocali)
                                    {
                                    guardarProduto.produtos.Remove(produto);   
                                    break; 
                                    }
                    

                                }
                            }
                            break;

                    
                    case 0:
                        continuar = false;
                        break;
                        
                }
            }  
            }
            
        }     
}   


}


