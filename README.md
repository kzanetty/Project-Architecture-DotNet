Project in .NET 7.0 with C#.
This project was created for educational purposes, serving as an illustrative example adhering to clean architecture principles in the context of .NET.

The project is organized into the following layers:

Domain layer:
No external dependencies or references.

Application layer:
Dependent on the Domain layer.

Infrastructure.Data layer:
Dependent on the Domain layer and relies on packages such as EntityFrameworkCore.Design, SqlServer, and Tools.

Infrastructure.IoC layer (Inversion of Control):
Dependencies on the Domain, Application, and Infrastructure.Data layers. Additionally, it includes a package reference for integrating AutoMapper via dependency injection.

WebApi layer:
Dependent on the Infrastructure.IoC layer and incorporates references to Swagger for API documentation.

Testing:
Tests are conducted within the Domain layer and the services within the Service layer.

---

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