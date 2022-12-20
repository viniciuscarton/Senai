using UC12_CLAB.Interfaces;
namespace UC12_CLAB.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf { get; set; }
        public string? dataNascimento { get; set; }
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
    }
}