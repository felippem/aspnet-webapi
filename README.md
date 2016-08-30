# ASP.NET Web API com MySQL

O objetivo deste repositório é aplicar conceitos básicos de arquitetura de software, baseado na programação orientada à objetos, suportando uma API sob a plataforma .NET conectada ao MYSQL.

Atualmente o projeto está dividido da seguinte maneira:

1. Application
2. Domain (Entities, Interfaces e Services)
3. Infra (IoC e Repository)
4. Unit Test
5. User Interface (ASP.NET Web API)

Além das camadas, o projeto conta com os conceitos de DI, Unit of Work e Entity Code First, através dos frameworks: Ninject, Migrations e Entity Framework.
Os domains ainda estão bastante anêmicos, porém é um questão de evolução. Por essas e outras, você precisa contribuir com este projeto.

### Tecnologias envolvidas

1. .NET Framework 4.5.1
2. ASP.NET C# Web API 5.2.3
3. Entity Framework 6.1.3
4. Ninject 3.2.2.0
5. AutoMapper 4.2.1
6. MySql.Data 6.9.8
7. MySQL Server 5.6.26 (Community Server)

### Instalação

Para executar este projeto é necessário que você tenha um ambiente de desenvolvimento devidamente configurado.

* Instale o Visual Studio ou Visual Studio 2013 ou superior para compilar o projeto
* Certifique-se de que o .NET Framework 4.5.1 esteja instalado
* Instale o MySQL em localhost ou em algum servidor dedicado (VirtualBox ou na nuvem)
* Em WebAPI.Infra.Repo/App.config, configure a chave "ConnectionString"
* Através do "Nuget Package Manager Console", execute o comando:

> Update-Database -StartUpProjectName WebAPI.Infra.Repo

* Em Web.UI/Web.config, configure a chave "ConnectionString"
* Execute o projeto para que a API seja fornecida através do IIS
* Teste as operações da API através de um client de sua preferência.

###Recomendações

Configure o servidor MySQL no Ubuntu ou algo similar. Caso contrário, através do Windows também é possível.
Caso você teste a API através do Postman, nas pasta "doc" existe uma coleção de testes (criada para a versão 4.6.2 do Postman). 

### Contribuições

Contribua com este projeto e acrescente conhecimento no dia-a-dia de outras pessoas. Envie pull request sempre que desejar.

Se preferir, me encontre no twitter <a href="//twitter.com/felippem" target="_blank">@felippem</a>.
