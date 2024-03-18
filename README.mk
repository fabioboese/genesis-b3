# CDB
O projeto foi segregado em algumas camadas, sendo elas:
- Domínio: contendo as classes visíveis a todo o projeto e, inclusive, a classe Cdb, responsável por calcular o retorno do Cdb em um determinado período.
- Repositório: contendo a interface e a implementação das classes responsáveis por obter do repositório os dados necessários para o cálculo do retorno do Cdb.
- Serviço: contendo a interface e a implementação das classes responsáveis por calcular o retorno do Cdb.
- Testes: contendo os testes unitários das classes que implementam alguma regra de negócio como os juros compostos e a regra de tributação.
- WebApi: a webapi contém o ponto de entrada para o cálculo do retorno do Cdb através de um método POST que recebe um JSON com os dados necessários para o cálculo.
- Frontend: contém os campos necessários para o usuário informar os valores para o cálculo do retorno do Cdb.

Para executar a aplicação, basta abrí-la no Visual Studio e pressionar F5 pois a mesma já está configurada para executar a webapi e o frontend.
Os testes estão com cobertura de 100% na camada Application que contém as lógicas de cálculo dos juros compostos e imposto.
Muitas classes no projeto foram criadas com a finalidade de demonstrar como seria a aplicação de conceitos SOLID, embora pela simplicidade da solicitação, não fossem necessárias.

