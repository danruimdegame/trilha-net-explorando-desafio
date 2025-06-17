using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();

Suite suite = new Suite();

Reserva reserva = new Reserva();

string logo = @"
   *        )            )    (         )            )                   (                  )     )          (         
 (  `    ( /(         ( /(    )\ )   ( /(         ( /(      (     (      )\ )    (       ( /(  ( /(          )\ )      
 )\))(   )\())    (   )\())  (()/(   )\())    (   )\())     )\    )\    (()/(    )\      )\()) )\())     (  (()/( (    
((_)()\ ((_)\     )\ ((_)\    /(_)) ((_)\     )\ ((_)\    (((_)((((_)(   /(_))((((_)(   ((_)\ ((_)\      )\  /(_)))\   
(_()((_)  ((_)   ((_)  ((_)  (_))_    ((_)   ((_)  ((_)   )\___ )\ _ )\ (_))   )\ _ )\   _((_)  ((_)  _ ((_)(_)) ((_)  
|  \/  | / _ \  _ | | / _ \   |   \  / _ \  _ | | / _ \  ((/ __|(_)_\(_)/ __|  (_)_\(_) | || | / _ \ | | | |/ __|| __| 
| |\/| || (_) || || || (_) |  | |) || (_) || || || (_) |  | (__  / _ \  \__ \   / _ \   | __ || (_) || |_| |\__ \| _|  
|_|  |_| \___/  \__/  \___/   |___/  \___/  \__/  \___/    \___|/_/ \_\ |___/  /_/ \_\  |_||_| \___/  \___/ |___/|___| 
                                                                                                                       
";
bool exibirMenu = true;
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine(logo);
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar hóspede");
    Console.WriteLine("2 - Cadastrar suíte");
    Console.WriteLine("3 - Realizar reserva");
    Console.WriteLine("4 - Exibir quantidade de hóspedes e valor da diária");
    Console.WriteLine("5 - Sair");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Digite o nome do hóspede:");
            hospedes.Add(new Pessoa(nome: Console.ReadLine()));
            break;

        case "2":
            Console.WriteLine("Digite o tipo da suíte:");
            suite.TipoSuite = Console.ReadLine();
            Console.WriteLine("Digite a capacidade da suíte:");
            suite.Capacidade = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Digite o valor da diária:");
            suite.ValorDiaria = Convert.ToDecimal(Console.ReadLine());
            break;

        case "3":
            Console.WriteLine("Digite a quantidade de dias reservados:");
            reserva.DiasReservados = Convert.ToInt16(Console.ReadLine());
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);
            break;

        case "4":
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            reserva.VerificadorDeDesconto();
            if (reserva.VerificadorDeDesconto())
            {
                reserva.CalcularValorDiariaComDesconto();
            }
            else
            {
                Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");  
            }
            break;

        case "5":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
    Console.WriteLine("Pressione uma tecla para continuar...");
    Console.ReadKey();
}


// Exibe a quantidade de hóspedes e o valor da diária
