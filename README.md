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

* .NET Framework 4.5.1
* ASP.NET C# Web API 5.2.3
* Entity Framework 6.1.3
* Ninject 3.2.2.0
* AutoMapper 4.2.1
* MySql.Data 6.9.8
* MySQL Server 5.6.26 (Community Server)
* Microsoft Windows 10
* Ubuntu 16.04

### Instalação

Para executar este projeto é necessário que você tenha um ambiente de desenvolvimento devidamente configurado.

* Instale o Visual Studio ou Visual Studio 2013 ou superior para compilar o projeto
* Certifique-se de que o .NET Framework 4.5.1 esteja instalado
* Faça o clone da aplicação

  > git clone https://github.com/felippem/aspnet-webapi.git
  
* Instale o MySQL em localhost ou em algum servidor dedicado (VirtualBox ou na nuvem)

  ####Ubuntu: 
  > $ sudo apt-get install mysql-server

  > $ mysql -u root -p
  
  > mysql> CREATE USER 'USER_NAME'@'%' IDENTIFIED BY 'USER_PASSWORD';
  
  > mysql> GRANT ALL PRIVILEGES ON * . * TO 'USER_NAME'@'%';
  
  > mysql> FLUSH PRIVILEGES;
  
  Provavelmente você terá que liberar o acesso ao mysql para acesso remoto
  
  > mysql> \q

  Modifique a variável "base_address" com o número IP do servidor ou "0.0.0.0" para qualquer IP
  
  > $ sudo nano /etc/mysql/mysql.conf.d/mysqld.cnf
  
  > $ service mysql restart

* Em WebAPI.Infra.Repo/App.config, configure a chave "ConnectionString"
* Através do "Nuget Package Manager Console", execute o comando
  
  > Update-Database -StartUpProjectName WebAPI.Infra.Repo

* Em Web.UI/Web.config, configure a chave "ConnectionString"
* Execute o projeto para que a API seja fornecida através do IIS
* Teste as operações da API através de um client de sua preferência

###Recomendações

Configure o servidor MySQL no Ubuntu ou algo similar. Caso contrário, através do Windows também é possível.
Caso você teste a API através do Postman, nas pasta "doc" existe uma coleção de testes (criada através da versão 4.6.2 do Postman desktop).

### Contribuições

Contribua com códigos. Este projeto precisa de você para acrescentar conhecimento no dia-a-dia de outras pessoas.

Se preferir, me encontre no twitter <a href="//twitter.com/felippem" target="_blank">@felippem</a>.
