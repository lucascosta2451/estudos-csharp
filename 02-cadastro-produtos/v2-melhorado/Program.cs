// Sistema de cadastro de produto
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;


namespace Estoque
{
    

public class Produto
{
    private static int _contadorid = 0;
    public int id {get; private set;}
    public string nomeproduto {get; set;}
    public int quantidadeprodutos {get; set;}

    public Produto(string nome)
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
     public List<Produto> produtos = new List<Produto>();

    public static int LerInteiro(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada,out int numero))
                {
                    return numero;
                }
            }
        }

     public bool Remover(int id)
        {
            foreach (var produto in produtos)
            {
                if (produto.id == id)
                {
                        produtos.Remove(produto);
                        return true;
                }
            }

            return false;
        }

    public bool Editar(string termo)
        {
          bool ehNumero = int.TryParse(termo, out int idbuscado);

           foreach(var produto in produtos)
            {
                bool bateId = ehNumero && produto.id == idbuscado;
                bool bateNome = produto.nomeproduto == termo;

                if (bateId || bateNome)
                {
                    Console.WriteLine("novo nome:");
                    string ?novoNome = Console.ReadLine();

                    int novaQuantidade = LerInteiro("Nova quantidade:");

                    produto.quantidadeprodutos = novaQuantidade;

                    if (!string.IsNullOrEmpty(novoNome))
                    {
                    produto.nomeproduto = novoNome;
                    }

                    return true;
                    
                }
            } 

            return false;
        }

    public Produto? Buscar(string termo)
        {
            bool ehNumero = int.TryParse(termo, out int idbuscado);

            foreach(var produto in produtos)
            {
                if(ehNumero && produto.id == idbuscado)
                {
                    return produto;
                }
                if(produto.nomeproduto == termo)

                {
                    return produto;
                }
            }

            return null;
        }

    public void Adicionar(string nome, int quantidade)
        {
             produtos.Add(new Produto(nome){quantidadeprodutos = quantidade});
        }

     public static void Main()
        {
            GuardarProduto guardarProduto = new GuardarProduto();
           guardarProduto.produtos.Add(new Produto("treloso"){quantidadeprodutos = 100});
           guardarProduto.produtos.Add(new Produto("Pippos"){ quantidadeprodutos = 80});
           guardarProduto.produtos.Add(new Produto("Doritos"){quantidadeprodutos = 150}); 

             
            bool continuar = true;
            while (continuar)
            {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("olá jogador! escolha a opção que deseja: ");
            Console.WriteLine("1- adicionar Produto");
            Console.WriteLine("2- Listar Todos os Produtos");
            Console.WriteLine("3- Buscar por nome ou Id");
            Console.WriteLine("4- Editar Produto");
            Console.WriteLine("5- Remover um produto");
            Console.WriteLine("0- Sair");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            
           int opcao = LerInteiro("escolha a opção:");
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Nome do produto:");
                        string? nome = Console.ReadLine();
                        int quantidade = LerInteiro("Quantidade de produtos:");
                            if (!string.IsNullOrEmpty(nome))
                            {
                                guardarProduto.Adicionar(nome,quantidade);
                                Console.WriteLine("Produto Adicionado!");
                            }
                        
                        break;
                    
                    case 2:
                        foreach (var produto in guardarProduto.produtos)
                        {
                            Console.WriteLine(produto);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Digite o nome ou o Id:");
                        string? termo =  Console.ReadLine();

                        if (!string.IsNullOrEmpty(termo))
                            {
                                Produto? achado = guardarProduto.Buscar(termo);

                                if (achado != null)
                                {
                                    Console.WriteLine(achado);
                                }
                                else
                                {
                                    Console.WriteLine("produto não encontrado.");
                                }
                            }
                            break;
                    
                    case 4:
                        Console.WriteLine("Digite o nome ou Id do produto que deseja editar: ");
                        string? termoEditar = Console.ReadLine();

                        if (!string.IsNullOrEmpty(termoEditar) && guardarProduto.Editar(termoEditar))
                            {
                                Console.WriteLine("Produto alterado!");
                            }
                            else
                            {
                               Console.WriteLine("Produto não encontrado.");
                            }
                        
                        break;

                    case 5:
                        int idremover = LerInteiro("Digite o Id do produto que deseja Remover:");
                        if (guardarProduto.Remover(idremover))
                            {
                                Console.WriteLine("Produto removido!");
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                            break;

                    
                    case 0:
                        continuar = false;
                        break;
                        
                }
                if (continuar)
                {
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();  
                }
                
            }  
            }
            
        }     
}   



