namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public short DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(short diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            try
            {
                // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
                if (Suite.Capacidade >= hospedes.Count)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                    throw new Exception("Capacidade insuficiente para o número de hóspedes.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar a reserva: {ex.Message}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        public bool VerificadorDeDesconto()
        {
            bool descontoAplicado = false;
            if (DiasReservados >= 10)
            {
                descontoAplicado = true;
            }
            return descontoAplicado;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;
            return valor;
        }

        public decimal CalcularValorDiariaComDesconto()
        {
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            decimal valor = DiasReservados * Suite.ValorDiaria;
            Console.WriteLine($"Valor da reserva: {valor:C}");
            valor = valor - (valor * 0.1m);
            Console.WriteLine($"Valor final, com 10% de desconto: {valor:C}");
            return valor;
        }
    }
}