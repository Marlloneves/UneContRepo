Aplicação de Gestão Financeira
Esta aplicação ASP.NET MVC (.NET 8.0) foi desenvolvida para o setor financeiro, permitindo gerenciar notas fiscais, gráficos de inadimplência e receitas anuais.

Recursos e Metodologias Utilizadas
Front-end: HTML, BOOTSTRAP, RAZOR, JS e JQUERY
Metodologias: DDD (Domain-Driven Design), Clean Code
Padrões: Padrões de Repositórios, IUnitOfWork
Banco de Dados: SQL Server Express com EF Core - Code First
Containerização: Docker com Dockerfile e docker-compose
Migração Automática: Migrações iniciais configuradas para facilitar o deployment


1 - Como Começar
1.1 - Pré-requisitos:
	1.1 - Docker Desktop (para deployment via container no Windows)
	1.2 - Visual Studio 2022 (para desenvolvimento local) ou Visual Studio Code.

2 - Instruções de Configuração:
2.1 - Usando Visual Studio
	2.1 - Clonar o Repositório:
	2.2 - git clone https://github.com/Marlloneves/UneContRepo.git

3 - Abrir e Construir no Visual Studio:
	3.1 - Abra a solução no Visual Studio 2022.
	3.2 - Certifique-se de que o Docker Desktop está instalado e em execução.

4 - Iniciar a Aplicação:
	4.1 -Utilize o suporte integrado ao Docker do Visual Studio para iniciar a aplicação.

5 - Usando Visual Studio Code
   5.1 - Abra o VS Code na pasta do projeto
   5.2 - Abra o terminal e digite o comando: docker-compose up --build
   5.3 - Abra o Docker-Desktop e veja as portas disponibilizadas e acesse. Ex: https://localhost:34848/

6 - Observações
	6.1 - Requisito HTTPS: Ao usar o Docker Desktop, assegure-se de utilizar HTTPS com a porta apropriada. Ex: https://localhost:{porta disponibilizad}


Escalabilidade: A aplicação foi projetada para ser limpa, escalável e pronta para expansões futuras de serviço.