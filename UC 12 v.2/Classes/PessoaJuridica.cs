
using UC12_CLAB.Interfaces;
using System.Text.RegularExpressions;
namespace UC12_CLAB.Classes;

public class PessoaJuridica : Pessoa, IPessoaJuridica
{
    public string? cnpj { get; set; }
    public string? razaoSoc { get; set; }
    public string caminho { get; private set; } = "Database/PessoaJuridica.csv";
    public override float PagarImposto(float rendimento)
    {
        if (rendimento <= 1500)
        {
            return (rendimento / 100) * 3;
        }
        else if (rendimento > 1500 && rendimento <= 3500)
        {
            return (rendimento / 100) * 5;
        }
        else if (rendimento > 3500 && rendimento <= 6000)
        {
            return (rendimento / 100) * 7;
        }
        else
        {
            return (rendimento / 100) * 9;
        }
        throw new NotImplementedException();
    }
    public bool ValidarCNPJ(string cnpj)
    {
        if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
        {
            if (cnpj.Length == 18)
            {
                if (cnpj.Substring(11, 4) == "0001")
                {
                    return true;
                }
            }
            else if (cnpj.Length == 14)
            {
                if (cnpj.Substring(8, 4) == "0001")
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void Inserir(PessoaJuridica pj)
    {
        VerificarPastaArquivo(caminho);
        string[] pjString = { $"{pj.Nome}, {pj.razaoSoc}, {pj.cnpj}, {pj.Endereco.logradouro}, {pj.Endereco.numero}, {pj.Endereco.complemento}, {pj.Endereco.endComercial}, {pj.rendimento}"};
        File.AppendAllLines(caminho, pjString);
    }
    public List<PessoaJuridica> Ler()
    {
        VerificarPastaArquivo(caminho);
        List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
        string[] linhas = File.ReadAllLines(caminho);
        foreach (string cadaLinha in linhas)
        {
            string[] atributos = cadaLinha.Split(",");
            PessoaJuridica cadaPj = new PessoaJuridica();
            Endereco cadaEnd = new Endereco();

            cadaPj.Nome = atributos[0];
            cadaPj.razaoSoc = atributos[1];
            cadaPj.cnpj = atributos[2];
            cadaEnd.logradouro = atributos[3];
            cadaEnd.numero = int.Parse(atributos[4]);
            cadaEnd.complemento = atributos[5];
            cadaEnd.endComercial = bool.Parse(atributos[6]);
            cadaPj.rendimento = float.Parse(atributos[7]);
            
            cadaPj.Endereco = cadaEnd;
            listaPj.Add(cadaPj);
        }
        return listaPj;
    }
}



