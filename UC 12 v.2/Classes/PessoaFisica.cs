using UC12_CLAB.Interfaces;
namespace UC12_CLAB.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf { get; set; }
        public string? dataNascimento { get; set; }
        public string caminho { get; private set; } = "Database/PessoaFisica.csv";
        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                return (rendimento / 100) * 2;
            }
            else if (rendimento > 3500 && rendimento <= 6000)
            {
                return (rendimento / 100) * 3.5f;
            }
            else
            {
                return (rendimento / 100) * 5;
            }
            throw new NotImplementedException();
        }
        internal object ValidarDataNascimento(DateTime? dataNascimento)
        {
            throw new NotImplementedException();
        }
        /*
            public bool ValidarDataNascimento(DateTime dataNasc)
            {
                DateTime dataAtual;
                dataAtual = DateTime.Now;
                double anos;
                anos = (dataAtual - dataNasc).TotalDays/365;
                if (anos >= 18){
                    return true;
                }
                    return false;
            }
            */
        public bool ValidarDataNascimento(string dataNasc)
        {
            DateTime dataConv;
            if (DateTime.TryParse(dataNasc, out dataConv))
            {
                //Console.WriteLine($"{dataConv}");   
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConv).TotalDays / 365;
                if (anos >= 18)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Inserir(PessoaFisica pf)
        {
            VerificarPastaArquivo(caminho);
            string[] pjString = { $"{pf.Nome}, {pf.dataNascimento}, {pf.cpf}, {pf.Endereco.logradouro}, {pf.Endereco.numero}, {pf.Endereco.complemento}, {pf.Endereco.endComercial}, {pf.rendimento}" };
            File.AppendAllLines(caminho, pjString);
        }
        public List<PessoaFisica> Ler()
        {
            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            string[] linhas = File.ReadAllLines(caminho);
            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");
                PessoaFisica cadaPf = new PessoaFisica();
                Endereco cadaEnd = new Endereco();

                cadaPf.Nome = atributos[0];
                cadaPf.dataNascimento = atributos[1];
                cadaPf.cpf = atributos[2];
                cadaEnd.logradouro = atributos[3];
                cadaEnd.numero = int.Parse(atributos[4]);
                cadaEnd.complemento = atributos[5];
                cadaEnd.endComercial = bool.Parse(atributos[6]);
                cadaPf.rendimento = float.Parse(atributos[7]);

                cadaPf.Endereco = cadaEnd;
                listaPf.Add(cadaPf);
            }
            return listaPf;
        }
    }
}