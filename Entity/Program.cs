using Entity.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("---------- Bonequinha Porcelana ---------");
                Console.WriteLine("[1] Marcas");
                Console.WriteLine("[2] Produtos");
                Console.WriteLine("[3] Vendas");

                int decisaoUsuarioMenu = int.Parse(Console.ReadLine());
                if (decisaoUsuarioMenu == 1)
                {
                    Marcas();
                }
                else if(decisaoUsuarioMenu == 2){
                    Produtos();
                } 
                else if(decisaoUsuarioMenu == 3)
                {
                    Vendas();
                }
            }


        }

        public static void Vendas()
        {
            using (var contexto = new LojaContext())
            {
                VendaDAO vendaDAO = new VendaDAO(contexto);
                produtoDAO produtoDAO = new produtoDAO(contexto);
                List<Produto> produtos = produtoDAO.Listar();
                List<Venda> vendas = vendaDAO.Listar();
                Console.WriteLine("Adicionar Venda [1]");
                Console.WriteLine("Remover Venda [2]");

                Console.WriteLine("Listar Vendas[3]");
                int decisaoUsuarioVenda = int.Parse(Console.ReadLine());
                if(decisaoUsuarioVenda == 1)
                {
                    Console.WriteLine("Digite a descrição da venda");
                    string descricaoVenda = Console.ReadLine();
                    Venda venda = new Venda();
                    venda.Descricao = descricaoVenda;
                    Console.WriteLine("Quantos produtos nessa venda?");
                    int quantidadeProdutos = int.Parse(Console.ReadLine());
                  
                    for (int i = 0; i < quantidadeProdutos; i++)
                    {
                        Console.WriteLine("Digite o Id do produto");
                        int IdProduto = int.Parse(Console.ReadLine());
                        foreach (Produto produto in produtos)
                        {
                            if(produto.Id == IdProduto)
                            {
                                Console.WriteLine("Digite a quantidade do produto");
                                int quantidade = int.Parse(Console.ReadLine());
                                venda.Valor = produto.Preco * quantidade;
                                produto.Quantidade -= quantidade;
                                contexto.SaveChanges();
                                VendaProduto vendaProdutoadd = new VendaProduto();
                                vendaProdutoadd.Produto = produto;
                                vendaProdutoadd.Venda = venda;
                              


                                contexto.VendaProduto.Add(vendaProdutoadd);
                                contexto.SaveChanges();
                            }
                        }
                        
                        
                    }

                }else if(decisaoUsuarioVenda == 3)
                {
                    List<VendaProduto> ListarVendas = contexto.VendaProduto.ToList();
                    List<Produto> produtosJoin = contexto.Produto.ToList();
                    List<Venda> vendasJoin = contexto.Venda.ToList();
                    VendaProduto resultJoin = new VendaProduto();
                     IEnumerable<VendaProduto> rs = from vp in ListarVendas
                                 join p in produtosJoin
                                 on vp.ProdutoId equals p.Id
                                 join v in vendasJoin
                                 on vp.VendaId equals v.Id
                                 select vp;
                    double valorTotalVenda = 0;
                    foreach (VendaProduto r in rs)
                    {

                        Console.WriteLine(r);
                        valorTotalVenda += r.Venda.Valor;
                      
                        
                        
                       
                    }
                    Console.WriteLine("VALOR TOTAL DA VENDA: " +valorTotalVenda);
                }

            }
        }
        public static void Produtos()
        {
            using (var contexto = new LojaContext())
            {
                produtoDAO produtoDAO = new produtoDAO(contexto);
                MarcaDAO marcaDAO = new MarcaDAO(contexto);
                List<Produto> listaProdutos = produtoDAO.Listar();
                List<Marca> listaMarcas = marcaDAO.Listar();
                Console.WriteLine("Adicionar Produto [1]");
                Console.WriteLine("Remover Produto [2]");
                Console.WriteLine("Pesquisar Produto[3]");
                Console.WriteLine("Listar marcas[4]");
                Console.WriteLine("Alterar valor produto [5]");
                int decisaoProdutoMenu = int.Parse(Console.ReadLine());
                if(decisaoProdutoMenu == 1)
                {
                    Console.WriteLine("Digite o nome do produto: ");
                    string nomeProduto = Console.ReadLine();
                    Console.WriteLine("Digite o preco: ");
                    double precoProduto = double.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a quantidade deste produto: ");
                    int quantidadeProduto = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o nome da marca: ");
                    string nomeMarcaProduto = Console.ReadLine();
                    bool marcaExiste = false;
                    Marca marcaProdutoAdd;
                    foreach (Marca marca in listaMarcas)
                    {
                        if(marca.Nome == nomeMarcaProduto)
                        {
                            marcaExiste = true;
                            marcaProdutoAdd = marca;
                            Produto produto = new Produto(nomeProduto, precoProduto,  quantidadeProduto);
                            produto.Marca = marca;
                            produtoDAO.Adicionar(produto);
                            Console.WriteLine("Produto adicionado com sucesso digite enter para prosseguir");
                            Console.ReadLine();

                        }
                    }
                    if (!marcaExiste)
                    {
                        Console.WriteLine("Essa marca não existe no banco de dados");
        
                    }
                  
                  


                }if(decisaoProdutoMenu == 2)
                {
                    foreach (Produto produto in listaProdutos)
                    {
                        Console.WriteLine(produto);

                    }
                    Console.WriteLine("Digite o ID do produto que deseja excluir: ");
                    int idProdutoExcluir = int.Parse(Console.ReadLine());
                    foreach (Produto produtoExcluir in listaProdutos)
                    {
                             if(produtoExcluir.Id == 1)
                        {
                            produtoDAO.Remover(produtoExcluir);
                        }
                    }
                }
                else if(decisaoProdutoMenu == 3)
                {
                    Console.WriteLine("Digite o nome do Produto para pesquisar");
                    string nomeProdutoPesquisa = Console.ReadLine();
                    bool ProdutoExiste = false;
                    foreach (Produto produto in listaProdutos)
                    {
                        if(produto.Nome == nomeProdutoPesquisa)
                        {
                            Console.WriteLine(produto);
                            ProdutoExiste = true;
                        }
                    }
                    if (!ProdutoExiste)
                    {
                        Console.WriteLine("Esse produto não existe");
                    }
                }
                else if(decisaoProdutoMenu == 4)
                {
                    foreach (Produto produto in listaProdutos)
                    {
                        Console.WriteLine(produto);
                    }
                }
                else if(decisaoProdutoMenu == 5)
                {
                    foreach (Produto produto in listaProdutos)
                    {
                        Console.WriteLine(produto);
                    }
                    Console.WriteLine("Digite o ID do produto que deseja mudar o preço");
                    int idProduto = int.Parse(Console.ReadLine());
                    foreach (Produto ProdutoAlterar in listaProdutos)
                    {
                        if(ProdutoAlterar.Id == idProduto)
                        {
                            produtoDAO.Alterar(ProdutoAlterar);
                        }
                        Console.WriteLine("Produto alterado com sucesso, digite enter para prosseguir");
                    }
                }
            }
        }
        public static void Marcas()
        {
            using (var contexto = new LojaContext())
            {
                MarcaDAO marcaDAO = new MarcaDAO(contexto);
                List<Marca> listaMarcas = marcaDAO.Listar();
                Console.WriteLine("Adicionar marca [1]");
                Console.WriteLine("Remover marca [2]");
                Console.WriteLine("Pesquisar marca[3]");
                Console.WriteLine("Listar marcas[4]");

                int decisaoUsuarioMenuMarcas = int.Parse(Console.ReadLine());
                if(decisaoUsuarioMenuMarcas == 1)
                {
                    Console.Write("Nome da marca: ");
                    string nomeMarca = Console.ReadLine();
                    Marca marca = new Marca(nomeMarca);
                    marcaDAO.Adicionar(marca);
                    Console.WriteLine("Marca adiciona com sucesso, pressione enter para voltar ao menu");
                    Console.ReadLine();

                }else if(decisaoUsuarioMenuMarcas == 2)
                {
                    foreach (Marca marca in listaMarcas)
                    {
                        Console.WriteLine(marca);
                    }
                    Console.WriteLine("Digite o ID que deseja excluir");
                    int IdExcluirMarca = int.Parse(Console.ReadLine());
                    foreach (Marca marca1 in listaMarcas)
                    {
                           if(marca1.Id == IdExcluirMarca)
                        {
                            marcaDAO.Remover(marca1);
                        }      
                    }

                    Console.WriteLine("Excluido com sucesso, pressione enter para voltar ao menu");
                }
                else if(decisaoUsuarioMenuMarcas == 3)
                {
                    Console.WriteLine("Digite o nome para pesquisa");
                    string nomePesquisa = Console.ReadLine();
                    bool existe = false;
                    foreach (Marca marca in listaMarcas)
                    {
                        if (marca.Nome == nomePesquisa)
                        {
                            Console.WriteLine(marca);
                            existe = true;
                        }
                    }
                    if (!existe)
                    {
                        Console.WriteLine("Essa marca não existe no banco da dados");
                    }
                }
                else if(decisaoUsuarioMenuMarcas == 4)
                {
                    foreach (Marca marca in listaMarcas)
                    {
                        Console.WriteLine(marca);
                    }
                }
                else
                {
                    Console.WriteLine("Você não digitou um numero valido");
                }
                

            }


        }
    }
}
