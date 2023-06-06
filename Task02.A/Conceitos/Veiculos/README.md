# CESAE ISI 5420 
 
## Aula02/Veiculos
 
Imagine que está a construir uma cidade e precisa de diferentes tipos de veículos para circular nela, como carros, camiões e motos. Esses veículos partilham algumas características comuns, como rodas, motor e capacidade de se movimentar, mas cada tipo de veículo também possui características específicas.

Aqui é onde entra a classe abstrata. Pode-se criar uma classe abstrata chamada "Veículo", que define as características e comportamentos comuns a todos os veículos, como o número de rodas e a capacidade de movimentação. Essa classe abstrata serve como um modelo genérico para os veículos da cidade.

No entanto, a classe abstrata "Veículo" não pode ser instanciada diretamente, assim como não pode ter um veículo genérico sem um tipo específico. Ela serve apenas como um ponto de partida para criar os tipos específicos de veículos, como "Carro", "Camião" e "Moto".

Cada um desses tipos específicos de veículos herda da classe abstrata "Veículo" e adiciona as suas próprias características únicas. Por exemplo, a classe "Carro" pode adicionar a característica de ter quatro portas, enquanto a classe "Moto" pode adicionar a característica de ter apenas duas rodas.

Dessa forma, ao usar uma classe abstrata, está-se a definir um modelo genérico que permite criar subclasses mais especializadas, garantindo a reutilização de código e uma estrutura organizada.

Esta analogia ajuda a entender o conceito de classe abstrata de forma mais visual e prática.

