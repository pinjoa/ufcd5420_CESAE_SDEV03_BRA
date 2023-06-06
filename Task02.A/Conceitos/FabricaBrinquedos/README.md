# CESAE ISI 5420 
 
## Aula02/Fábrica de Brinquedos 
 
Imagine que é o proprietário de uma fábrica de brinquedos e precisa de produzir diferentes tipos de brinquedos, como ursos de peluche, carros de controle remoto e bonecas. Cada tipo de brinquedo tem suas próprias características e requer um processo de fabricação específico.

Para lidar com essa complexidade, decide criar uma fábrica de brinquedos usando o padrão de desenho "Factory" (fábrica). Define uma classe abstrata chamada "Brinquedo" que descreve os métodos e propriedades comuns a todos os brinquedos, como "mover" e "fazer barulho".

Em seguida, cria subclasses específicas para cada tipo de brinquedo, como "UrsoPeluche", "CarroControleRemoto" e "Boneca". Cada uma dessas subclasses herda da classe abstrata "Brinquedo" e implementa os métodos específicos para aquele tipo de brinquedo, como "abrirAbraço" para o urso de peluche ou "acelerar" para o carro de controle remoto.

Agora, vem a parte interessante: cria uma classe chamada "FabricaBrinquedos" que possui um método especial chamado "criarBrinquedo". Esse método recebe um parâmetro que indica o tipo de brinquedo que você deseja fabricar, como "UrsoPeluche", "CarroControleRemoto" ou "Boneca".

Dentro do método "criarBrinquedo", utiliza uma estrutura condicional (como um switch case) para identificar o tipo de brinquedo solicitado. Com base nessa informação, instancia-se a classe específica correspondente, como "UrsoPeluche" para "Urso de Peluche", e retorna a instância do brinquedo criado.

Dessa forma, o padrão de desenho "Factory" permite que encapsule a lógica de criação de objetos numa classe separada (a fábrica), evitando que a lógica de criação se espalhe pelo código. Além disso, ele facilita a adição de novos tipos de brinquedos no futuro, basta criar uma nova classe e fazer a devida atualização na fábrica.

Com esta analogia da fábrica de brinquedos, mostra-se como o padrão de desenho "Factory" simplifica o processo de criação de objetos e promove a flexibilidade e a facilidade na manutenção do código.

