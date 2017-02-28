# ASP.NET Web API com MySQL

O objetivo deste repositório é aplicar conceitos do DDD (Domain Driven Design), Design Patterns, O.O (Orientação a Objetos), entre outras coisas bacanas.

Além disso, o projeto conta com alguns padrões e tecnologias como: DI (Dependency Injection), IoC (Inversion of Control), UoW (Unit of Work), EF (EntityFramework Code First) e até integração com o Twilio.

### Tecnologias envolvidas

* .NET Framework 4.5.1
* ASP.NET C# Web API 5.2.3
* Entity Framework 6.1.3
* SimpleInjector 3.3.2
* AutoMapper 4.2.1
* MySql.Data 6.9.8
* MySQL Server 5.6.26 (Community Server)
* Microsoft Windows 10
* Ubuntu 16.04
* Twilio

### Instalação

Para executar este projeto é necessário que você tenha um ambiente de desenvolvimento devidamente configurado.

* Instale o Visual Studio ou Visual Studio 2013 ou superior para compilar o projeto
* Certifique-se de que o .NET Framework 4.5.1 esteja instalado
* Faça o clone da aplicação

  > git clone https://github.com/felippem/aspnet-webapi.git
  
* Instale o MySQL em localhost ou em algum servidor dedicado (VirtualBox ou na nuvem)

  ####Ubuntu (opcional): 
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
* Crie uma conta no Twilio e configure as chaves correspondentes em Web.UI/Web.config
* Execute o projeto para que a API seja fornecida através do IIS
* Teste as operações da API através de um client de sua preferência

### Contribuições

Contribua com códigos. Este projeto precisa de você para acrescentar conhecimento no dia-a-dia de outras pessoas.

Se preferir, me encontre no twitter <a href="//twitter.com/felippem" target="_blank">@felippem</a>.
