# CESAE ISI 5420 
 
## Aula02/Tesouro
 
Imagine que é um guarda de um tesouro valioso num castelo. A responsabilidade é proteger esse tesouro e garantir que apenas uma pessoa tenha acesso a ele de cada vez. Esse é o papel do padrão de desenho "Singleton".

O tesouro é representado por uma classe chamada "Tesouro". Agora, vamos implementar o padrão de desenho "Singleton" para garantir que apenas uma instância do tesouro exista.

Primeiro, define a classe "Tesouro" com um construtor privado, o que impede a criação de instâncias diretas da classe fora dela mesma. Em seguida, cria uma propriedade estática chamada "Instancia" que armazenará a única instância do tesouro.

Agora, precisa garantir que somente uma instância do tesouro seja criada. No momento em que a propriedade "Instancia" for acedida, verifica-se se ela já está preenchida. Se estiver vazia, cria-se uma nova instância do tesouro e a armazena-se na propriedade "Instancia". Se já estiver preenchida, retorna-se simplesmente a instância existente.

Dessa forma, qualquer parte do código que precise aceder o tesouro pode obter a instância única através da propriedade "Instancia". Isso garante que apenas uma pessoa tenha acesso ao tesouro de cada vez, evitando criação de múltiplas instâncias e promovendo a partilha do recurso.

