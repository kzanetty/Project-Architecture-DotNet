Projeto em .NET 7.0 com C#.
Este projeto foi criado com fins educacionais, servindo como um exemplo ilustrativo que segue os princípios da arquitetura limpa em aplicações .NET.
O projeto implementa a divisão de camadas na arquitetura Onion e o padrão CQRS.

Utilização do OpenApi, AutoMapper, SqlServer, XUnit, FluentAssertions, mediator.
O projeto está organizado nas seguintes camadas:

Camada de Domínio:
Sem dependências ou referências externas.

Camada de Aplicação:
Dependência com a Camada de Domínio. Utilização de pacotes como AutoMapper e Mediatr.

Camada de Infraestrutura de Dados:
Dependência com a Camada de Domínio e utiliza pacotes como EntityFrameworkCore.Design, SqlServer e Tools.

Camada de IoC de Infraestrutura (Inversão de Controle):
Dependências com as camadas de Domínio, Aplicação e Infra.Data. Além disso, inclui uma referência a pacotes para a integração do AutoMapper via injeção de dependência e também uma referência para o Mediatr.

Camada WebApi:
Dependência com a Camada Infra.IoC e incorpora referências ao Swagger para documentação da API.

Testes:
Realiza testes unitários na camada de domínio e nas services que se encontram na camada de aplicação.

Pendencias:

- Tratamento de erros com notifications
- Parametrizar os retornos, o que deve ser void e o que não deve ser
- Corrigir status retornados
- Modificar DTS de entrada para Requests
- Adicionar FluentValidation
- Adicionar Bogus nos testes unitarios
- Adicionar testes unitarios nas services
- Modificar regra de negócios de Update
- ID no momento da criação está se comportando de forma inesperada
- Adicição de autenticação e autorização com JWT token
- Padronizar os Mappings


Arrumar

- No endpoint GetCategoryById
true {
    HTTP 200 (OK) - E o produtoDTO
} else {
    HTTP 404 (Not Found) - E uma mensagem descritiva
}

- Validar se na entidade o Name não ultrapassa o limite de caracteres
- Na entidade product, validar que a image seja null
- Verificar regra de product. Um produto pode existir sem uma categoria? validar melhor na entidade


- DB
    - No package manage console
        - Selecionar camada de infra.data
            - Comandos:
                - add-migration <nameDaMigration>
                - update-database
            - Para adicionar seeddata inicial
                - add-migration SeedData
                - update-database