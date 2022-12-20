using UC12_CLAB.Classes;

Console.Clear();
Console.WriteLine(@$"
--------------------------------------------------------------------
|                            Bem vindo!                            |
|                      Sistema de cadastro de                      |
|                   Pessoas Físicas e Jurídicas                    |                                                 
--------------------------------------------------------------------
");
barraCarregar("Carregando", 50);

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
                PessoaFisica pf1 = new PessoaFisica();
                Endereco novoEndPF = new Endereco();
                PessoaFisica metodopf = new PessoaFisica();
                switch (opcaoPf)
                {
                    case "1":
                        Console.Clear();

                        Console.WriteLine($"Digite o nome da pessoa física:");
                        pf1.Nome = Console.ReadLine();

                        Console.WriteLine($"Digite o CPF (XXX.XXX.XXX.XX):");
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
                        novoEndPF.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número:");
                        novoEndPF.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento:");
                        novoEndPF.complemento = Console.ReadLine();

                        Console.WriteLine($"Endereço residencial? S/N");
                        string endComPF = Console.ReadLine();

                        if (endComPF == "S" && endComPF == "s")
                        {
                            novoEndPF.endComercial = true;
                        }
                        else
                        {
                            novoEndPF.endComercial = false;
                        }
                        pf1.Endereco = novoEndPF;
                        metodopf.Inserir(pf1);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        break;
                    case "2":
                        List<PessoaFisica> listaPf = metodopf.Ler();
                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaItem in listaPf)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                                Nome: {cadaItem.Nome}
                                CPF: {cadaItem.cpf}
                                Data de nascimento: {cadaItem.dataNascimento}
                                Logradouro: {cadaItem.Endereco.logradouro}
                                Número: {cadaItem.Endereco.numero}
                                Complemento: {cadaItem.Endereco.complemento}
                                Endereço residencial? {((cadaItem.Endereco.endComercial) ? "Sim" : "Não")}
                                Rendimento: {cadaItem.rendimento.ToString("C")}
                                Imposto devido: {metodopf.PagarImposto(cadaItem.rendimento).ToString("C")}
                                ");
                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Sem cadastros");
                            Thread.Sleep(2000);
                        }
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Por favor, selecione uma das opções do menu");
                        Thread.Sleep(2000);
                        break;
                }
            } while (opcaoPf != "0");
            break;
        case "2":
            string? opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
--------------------------------------------------------------------
|                 Escolha uma das opções a seguir:                 |
|__________________________________________________________________|
|                         1 - Cadastrar pessoa jurídica            |
|                         2 - Mostrar pessoa jurídica              |
|                                                                  |
|                         0 - Voltar                               |                                                 
--------------------------------------------------------------------
");
                opcaoPj = Console.ReadLine();
                PessoaJuridica pj1 = new PessoaJuridica();
                Endereco novoEndPJ = new Endereco();
                PessoaJuridica metodopj = new PessoaJuridica();
                switch (opcaoPj)
                {
                    case "1":
                        Console.Clear();

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
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        break;
                    case "2":
                        List<PessoaJuridica> listaPj = metodopj.Ler();
                        if (listaPj.Count > 0)
                        {
                            foreach (PessoaJuridica cadaItem in listaPj)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                                Nome: {cadaItem.Nome}
                                Razão social: {cadaItem.razaoSoc}
                                CNPJ: {cadaItem.cnpj}
                                Logradouro: {cadaItem.Endereco.logradouro}
                                Número: {cadaItem.Endereco.numero}
                                Complemento: {cadaItem.Endereco.complemento}
                                Endereço comercial? {((cadaItem.Endereco.endComercial) ? "Sim" : "Não")}
                                Rendimento: {cadaItem.rendimento.ToString("C")}
                                Imposto devido: {metodopj.PagarImposto(cadaItem.rendimento).ToString("C")}
                                ");
                                Console.WriteLine($"Aperte 'Enter' para continuar");
                                Console.ReadLine();
                            }
                            break;
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
                        Thread.Sleep(2000);
                        break;
                }
            } while (opcaoPj != "0");
            break;
        case "0":
            Console.WriteLine($"Obrigado por utilizar nosso sistema :D");
            barraCarregar("Finalizando", 100);
            Console.Clear();
            break;
        default:
            Console.Clear();
            Console.WriteLine($"Por favor, selecione uma das opções do menu");
            Thread.Sleep(2000);
            break;
    }
} while (opcao != "0");

































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