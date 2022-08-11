namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public decimal ValorTotal { get; set; }
        public bool PodeHospedar { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
           
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
                PodeHospedar = true;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                System.Console.WriteLine($"A suite {Suite.TipoSuite} não suporta {hospedes.Count} hospedes.");
                Hospedes = new List<Pessoa>();
                PodeHospedar = false;
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = Suite.ValorDiaria;
            ValorTotal = Suite.ValorDiaria * DiasReservados;
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%

            if (DiasReservados >= 10)
            {
                valor = (valor - Decimal.Multiply(valor,0.1M))/DiasReservados;
                ValorTotal = valor * DiasReservados;
            }

            return valor;
        }

        public string RespostaValidacao(){

            string resposta;

            if (PodeHospedar)
            {
                resposta = $"Hóspedes: {ObterQuantidadeHospedes()} \r\nValor diária: {CalcularValorDiaria().ToString("C")}\r\nValor Total: {ValorTotal.ToString("C")}";
            } else
            {
                resposta = "Reserva não concluida.";
            }

            return resposta;
        }
    }
}