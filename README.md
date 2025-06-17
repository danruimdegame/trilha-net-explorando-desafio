# DIO - Trilha .NET - Explorando a linguagem C#
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de explorando a linguagem C#, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema de hospedagem, que será usado para realizar uma reserva em um hotel. Você precisará usar a classe Pessoa, que representa o hóspede, a classe Suíte, e a classe Reserva, que fará um relacionamento entre ambos.

O seu programa deverá cálcular corretamente os valores dos métodos da classe Reserva, que precisará trazer a quantidade de hóspedes e o valor da diária, concedendo um desconto de 10% para caso a reserva seja para um período maior que 10 dias.

## Regras e validações
1. Não deve ser possível realizar uma reserva de uma suíte com capacidade menor do que a quantidade de hóspedes. Exemplo: Se é uma suíte capaz de hospedar 2 pessoas, então ao passar 3 hóspedes deverá retornar uma exception.
2. O método ObterQuantidadeHospedes da classe Reserva deverá retornar a quantidade total de hóspedes, enquanto que o método CalcularValorDiaria deverá retornar o valor da diária (Dias reservados x valor da diária).
3. Caso seja feita uma reserva igual ou maior que 10 dias, deverá ser concedido um desconto de 10% no valor da diária.


![Diagrama de classe estacionamento](diagrama_classe_hotel.png)

## Solução
Foi implementada uma rotina de validação de capacidade de hospedagem, que compara o número de hóspedes informados com a capacidade total permitida. Em caso de violação da regra, uma exceção é lançada explicitamente via comando throw, com tratamento posterior através de blocos try/catch, garantindo uma apresentação controlada e legível da falha ao usuário.

A classe Reserva expõe uma propriedade pública Hospedes, responsável por retornar a quantidade atual de hóspedes registrados na instância no método ObterQuantidadeHospedes.

Foi adicionada uma regra condicional de desconto por permanência estendida: para reservas iguais ou superiores a 10 dias, aplica-se automaticamente um desconto de 10% sobre o total. Para isso, foram criados dois métodos distintos — um para validação do critério e outro para o cálculo e exibição dos valores bruto e com desconto aplicado.

## 📄 Program.cs — Visão Geral do Código
Este é o arquivo principal da aplicação de hospedagem. Ele controla a execução do sistema via terminal, com um menu simples que permite cadastrar hóspedes, suítes, associar reservas e calcular valores com base em regras definidas.

#### 🧩 Funcionalidades
Cadastro de Hóspedes Lê o nome digitado no console, cria um objeto do tipo Pessoa e o adiciona à lista de hóspedes.

Cadastro de Suíte Solicita ao usuário o tipo da suíte, a capacidade máxima e o valor da diária. Esses dados são atribuídos à instância Suite.

Reserva Permite informar a quantidade de dias da reserva e vincula a suíte e os hóspedes à instância da classe Reserva.

Consulta Exibe a quantidade de hóspedes e o valor total da diária. Se a reserva tiver 10 ou mais dias, aplica automaticamente um desconto de 10% e mostra os valores com e sem desconto.

Encerramento do Programa O usuário pode encerrar a execução ao selecionar a opção correspondente no menu.

#### 💭 Detalhes Técnicos
A codificação de saída (Console.OutputEncoding) é definida como UTF-8, garantindo que caracteres especiais sejam exibidos corretamente.

O laço principal (while) mantém o menu em execução até o usuário escolher sair.

O switch gerencia as ações com base na opção selecionada.

Há um bloco de texto em ASCII art exibido sempre que o menu é carregado — apenas decorativo.

## 📄 Reserva.cs — Classe de Lógica de Reserva
A classe Reserva representa o processo de reserva de uma suíte para um grupo de hóspedes em um determinado número de dias.

#### ⚙️ Propriedades
Hospedes — Lista de objetos Pessoa que serão hospedados.

Suite — Instância da suíte reservada.

DiasReservados — Número de dias para os quais a reserva foi feita.

#### 🧩 Métodos e Regras Aplicadas
CadastrarHospedes(List<Pessoa> hospedes) Verifica se a quantidade de hóspedes é compatível com a capacidade da suíte. Se for, salva a lista; se não for, lança uma exceção com uma mensagem amigável, tratada por um try/catch.

CadastrarSuite(Suite suite) Associa uma suíte à reserva.

ObterQuantidadeHospedes() Retorna a quantidade total de hóspedes cadastrados.

VerificadorDeDesconto() Retorna true se a reserva tiver 10 dias ou mais (caso em que o cliente tem direito a desconto), ou false caso contrário.

CalcularValorDiaria() Calcula o valor total da reserva com base na diária e quantidade de dias, sem aplicar desconto.

CalcularValorDiariaComDesconto() Aplica 10% de desconto caso a reserva tenha 10 dias ou mais. Mostra os valores antes e depois do desconto no console, e retorna o valor final.

## 📄 Suite.cs — Modelo de Suíte
Essa classe representa as características de uma suíte que pode ser reservada no sistema de hospedagem.

#### 🧱 Propriedades
TipoSuite — Representa o tipo da suíte (ex: “Premium”, “Standard”, etc.).

Capacidade — Define o número máximo de hóspedes que a suíte comporta.

ValorDiaria — Valor monetário cobrado por dia de hospedagem.

#### 🛠️ Construtores
Construtor padrão Permite criar a instância da suíte sem definir valores iniciais.

Construtor com parâmetros Recebe tipoSuite, capacidade e valorDiaria, e já inicializa o objeto com essas informações. Útil para instanciar a suíte de forma rápida e completa.