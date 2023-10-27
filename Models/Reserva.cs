using System.Runtime.Serialization;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if(hospedes == null || hospedes.Count()<=0){
                throw new ReservaException("Sem hospedes na lista de reserva.");
            }
            if (hospedes.Count<=this.Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new ReservaException($"A capacidade de reserva da suite foi excedida em {hospedes.Count - this.Suite.Capacidade} pessoas. O número de hospedes deve ser menor ou igual à capacidade da suite.");
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
            return this.Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = this.DiasReservados * this.Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (this.DiasReservados>=10)
            {
                valor = decimal.Multiply(valor, new decimal(0.9));
            }

            return valor;
        }
    }
    public class ReservaException : Exception
    {
        public ReservaException(string message) : base(message)
        {
            this.Print();
            Console.WriteLine(message);
        }

        public ReservaException(string message, Exception innerException) : base(message, innerException)
        {
            this.Print();
            Console.WriteLine(message);
            Console.WriteLine(innerException.StackTrace);
        }

        protected ReservaException()
        {
            this.Print();
        }

        private void Print()
        {
            Console.WriteLine($"Houve uma exceção ao realizar a reserva em : {this.StackTrace}");
        }

    }
}