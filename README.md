
# Projeto Fuxo Caixa

Projeto para registrar débitos e créditos no caixa e obter o saldo atual.

## Decisões de Arquitetura 

Tendo em vista que seriam duas funcionalidas, (Serviço que faça o controle de lançamentos e Serviço do consolidado diário), optei por desenvolver duas APIs, ralizando a separação de responsabilidades, e criando camadas de domínio, aplicação e infraestrutura em ambos os projetos, visando uma arquitetura escalável com auta coesão e baixo acoplamento, além da implementação de testes de unidade para garantir um código seguro e testável.



## Funcionalidades

- Adiconar Lançamentos (Débito ou Crédito).
- Obter saldo total.
- Cada serviço foi desenvolvido em uma API.
## Tecnologias Utilizadas

- .NET 8 APIs
- REST
- SQL Server
- Entity Framework
- Migrations
- Docker
- Clean Code
- Unity Tests (XUniy, Moq)
- Injeçao de Dependência


## Rodando localmente e Testando

#### **Pré requisitos**

Ter o **Docker** instalado em sua máquina.

Para instalar acesse: https://www.docker.com/products/docker-desktop/

Ter o SDK do .NET instaldo em sua máquina.

Para instalar acesse: https://dotnet.microsoft.com/pt-br/download/dotnet/9.0


Clone o projeto

```bash
  git clone https://github.com/cadu12359/FluxoCaixa.git
```

Acesse o diretório do projeto

```bash
  cd FluxoCaixa
```

Dentro da pasta raiz do projeto, rode o comando do Docker Compose

```bash
  docker-compose up --build
```

Acesse a API de **Fluxo Caixa Lançamrentos** através do navegador pelo endereço

[http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)

- Para realizar o login, faça uma chamada no endpoint Login, com usuário **admin** e senha **1234**.
 
- Copie o token gerado pela requisição e cole no através do botão Autorize:

![Captura de tela 2025-02-16 110707](https://github.com/user-attachments/assets/f74af44c-ad7f-47d8-8127-fba5046509a5)

![Captura de tela 2025-02-16 111047](https://github.com/user-attachments/assets/31e0c6f9-494f-4111-8f29-82b137da3056)

- Realize lançamentos através dos endpoints **api/Lancamentos/Debito** e **api/Lancamentos/Credito**

Acesse a API de **Fluxo Caixa Consolidado** através do navegador pelo endereço

[http://localhost:8081/swagger/index.html](http://localhost:8081/swagger/index.html)

- Verifique o saldo em caixa através do endpoint **api/Consolidado** 

![consolidado](https://github.com/user-attachments/assets/d1f254e0-5a08-410a-9d1b-cf712071d886)

## Rodando Testes

Acesse a pasta do projeto FluxoCaixa, abra o terminal e rode o comando

```bash
  dotnet test
```

## Melhorias futuras

- Realizar a comunicação entre os serviços através de mensageria com RabbitMQ.

- Separação das camadas (atualmente em pastas) em projetos distintos, vizando a escalabilidade.

- Aticionar autenticação e autorização utilizando JWT.

- Adicionar projeto Front-end utilizando frameworks como Angular, React, Blazor.

