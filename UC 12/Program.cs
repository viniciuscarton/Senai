using UC12_CLAB.Classes;

Console.WriteLine(@$"
--------------------------------------------------------------------
|                            Bem vindo!                            |
|                      Sistema de cadastro de                      |
|                   Pessoas Físicas e Jurídicas                    |                                                 
--------------------------------------------------------------------
");

static void barraCarregar(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write($"{texto}");
    for (var contador = 0; contador < 28; contador++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }
    Console.ResetColor();
}

barraCarregar("Carregando", 50);
List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
--------------------------------------------------------------------
|                 Escolha uma das opções a seguir:                 |
|__________________________________________________________________|
|                         1 - Pessoa física                        |
|                         2 - Pessoa jurídica                      |
|                                                                  |
|                         0 - Sair                                 |                                                 
--------------------------------------------------------------------
");

    opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            PessoaFisica metodopf = new PessoaFisica();
            string? opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
--------------------------------------------------------------------
|                 Escolha uma das opções a seguir:                 |
|__________________________________________________________________|
|                         1 - Cadastrar pessoa física              |
|                         2 - Mostrar pessoa física                |
|                                                                  |
|                         0 - Voltar                               |                                                 
--------------------------------------------------------------------
");
                opcaoPf = Console.ReadLine();
                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica pf1 = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa física:");
                        pf1.Nome = Console.ReadLine();

                        Console.WriteLine($"Digite o CPF:");
                        pf1.cpf = Console.ReadLine();

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento (DD/MM/AAAA):");
                            string dataN = Console.ReadLine();
                            dataValida = metodopf.ValidarDataNascimento(dataN);
                            if (dataValida)
                            {
                                pf1.dataNascimento = dataN;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Data de nascimento inválida");
                                Console.ResetColor();
                            }
                        } while (dataValida == false);

                        Console.WriteLine($"Digite o rendimento mensal:");
                        pf1.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro:");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número:");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento:");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Endereço residencial? S/N");
                        string endCom = Console.ReadLine();
                        if (endCom == "S" && endCom == "s")
                        {
                            novoEnd.endComercial = true;
                        }
                        else
                        {
                            novoEnd.endComercial = false;
                        }
                        pf1.Endereco = novoEnd;

                        using (StreamWriter sw = new StreamWriter($"{pf1.Nome}.txt"))
                        {
                            sw.WriteLine($"{pf1.Nome}");
                            sw.WriteLine($"{pf1.cpf}");
                        }

                        listaPf.Add(pf1);


                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;
                    case "2":
                        Console.Clear();

                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                                Pessoa física
                                Nome: {cadaPessoa.Nome}
                                CPF: {cadaPessoa.cpf}
                                Data de nascimento: {cadaPessoa.dataNascimento}
                                Endereço: {cadaPessoa.Endereco.logradouro}, {cadaPessoa.Endereco.numero}. {cadaPessoa.Endereco.complemento}
                                Rendimento: {cadaPessoa.rendimento.ToString("C")}
                                Imposto devido: {metodopf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                ");
                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();

                            };
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Sem cadastros");
                            Thread.Sleep(3000);
                        }

                        /*using (StreamReader sr = new StreamReader($"Mariana.txt"))
                        {
                            string linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                Console.WriteLine($"{linha}");
                            }
                        }*/
                        Console.WriteLine($"Aperte 'Enter' para continuar");
                        Console.ReadLine();

                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Por favor, selecione uma das opções do menu");
                        Thread.Sleep(1000);
                        break;
                }
            } while (opcaoPf != "0");
            break;



        case "2":
            PessoaJuridica metodopj = new PessoaJuridica();
            string? opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
--------------------------------------------------------------------
|                 Escolha uma das opções a seguir:                 |
|__________________________________________________________________|
|                         1 - Cadastrar pessoa jurídica            |
|                         2 - Mostrar pessoas jurídicas            |
|                                                                  |
|                         0 - Voltar                               |                                                 
--------------------------------------------------------------------
");
                opcaoPj = Console.ReadLine();
                switch (opcaoPj)
                {
                    case "1":
                        PessoaJuridica pj1 = new PessoaJuridica();
                        Endereco novoEndPJ = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa jurídica:");
                        pj1.Nome = Console.ReadLine();

                        Console.WriteLine($"Digite a razão social:");
                        pj1.razaoSoc = Console.ReadLine();

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o CNPJ (XX. XXX. XXX/0001-XX):");
                            string Cnpj = Console.ReadLine();
                            cnpjValido = metodopj.ValidarCNPJ(Cnpj);
                            if (cnpjValido)
                            {
                                pj1.cnpj = Cnpj;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"CNPJ inválido");
                                Console.ResetColor();
                            }
                        } while (cnpjValido == false);

                        Console.WriteLine($"Digite o rendimento mensal:");
                        pj1.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro:");
                        novoEndPJ.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número:");
                        novoEndPJ.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento:");
                        novoEndPJ.complemento = Console.ReadLine();

                        Console.WriteLine($"Endereço comercial? S/N");
                        string endComPJ = Console.ReadLine();
                        if (endComPJ == "S" && endComPJ == "s")
                        {
                            novoEndPJ.endComercial = true;
                        }
                        else
                        {
                            novoEndPJ.endComercial = false;
                        }
                        pj1.Endereco = novoEndPJ;
                        metodopj.Inserir(pj1);
                        List<PessoaJuridica> lPj = metodopj.Ler();
                        foreach (PessoaJuridica cadaItem in lPj)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
                                Pessoa jurídica
                                Nome: {pj1.Nome}
                                CNPJ: {pj1.cnpj}
                                Razão social: {pj1.razaoSoc}
                                Endereço: {pj1.Endereco.logradouro}, {pj1.Endereco.numero}. {pj1.Endereco.complemento}
                                Rendimento: {pj1.rendimento.ToString("C")}
                                Imposto devido: {metodopj.PagarImposto(pj1.rendimento).ToString("C")}
                                ");
                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                            break;
                        }

                        //listaPj.Add(pj1);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;
                    case "2":
                        Console.Clear();
                        if (listaPj.Count > 0)
                        {
                            foreach (PessoaJuridica cadaPessoaJ in listaPj)
                            {

                            };
                        }
                        else
                        {
                            Console.WriteLine($"Sem cadastros");
                            Thread.Sleep(3000);
                        }

                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Por favor, selecione uma das opções do menu");
                        Thread.Sleep(1000);
                        break;
                }
            } while (opcaoPj != "0");
            break;
        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema :D");
            barraCarregar("Finalizando", 10);
            break;
        default:
            break;
    }
} while (opcao != "0");