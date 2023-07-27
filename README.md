# Orion Mensageria

API Para POST e GET de mensagens no RabbitMQ. Foi construida apenas para fins de testes e práticas.

[![Version](https://img.shields.io/badge/Conventional%20Commits-1.0.0-blue.svg)](https://conventionalcommits.org)
[![Travis](https://img.shields.io/travis/gotbahn/browsers-support-badges.svg)](https://github.com/MayconLSilva/OrionMensageria)
<a href="https://github.com/MayconLSilva/OrionMensageria">
    <img src="https://img.shields.io/github/issues-pr/FN-FAL113/github-readme-steam-status"/> 
</a>
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
## 🛠️ Técnologias utilizadas:
* Net.7.0
* RabbitMQ
* Docker

![Lang](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![FyL](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![FyL](https://img.shields.io/badge/rabbitmq-%23FF6600.svg?&style=for-the-badge&logo=rabbitmq&logoColor=white)
![FyL](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

## 🛠️ Pré-requisitos
Certifique-se de ter as seguintes ferramentas e/ou técnologias instaladas em sua máquina:
* [Docker Desktop](https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe?_gl=1*msh36l*_ga*MTQ0Mzc3NjU2Ny4xNjI1MzMzMjE5*_ga_XJWPQMJYHQ*MTY4NzM2NTc2Ni43LjEuMTY4NzM2NTc2Ni42MC4wLjA.)
* [.NET 7 SDK](https://download.visualstudio.microsoft.com/download/pr/2ab1aa68-3e14-401a-b106-833d66fa992b/060457e640f4095acf4723c4593314b6/dotnet-sdk-7.0.304-win-x64.exe)

## NuGets necessários
* Microsoft.AspNetCore.OpenApi
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Tools
* Newtonsoft.Json
* NuGet.CommandLine
* RabbitMQ.Client
* Swashbuckle.AspNetCore

## ▶️ Como executar o projeto localmente
1. Baixe e instale o container do RabbitMQ, você pode utilizar o seguinte comando abaixo.
> docker run -it --rm --name containerrabbit -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management
2. Clone este repositório para sua máquina local:
> https://github.com/MayconLSilva/OrionMensageria.git
3. Navegue até o diretório do projeto:
> cd seu-repositorio
4. Execute o projeto usando o comando dotnet:
> dotnet run
5. Abra seu navegador e acesse a URL para visualizar a aplicação.
> https://localhost:suaPorta
![image](https://github.com/MayconLSilva/OrionMensageria/assets/24304710/72f05881-f6b7-41a2-a0fe-42af296619c8)

6. Você também pode acessar o container do Rabbit e verificar as mensagem por ele, basta:
> Utilizar o seguinte endereço: http://localhost:15672
> Username guest Password guest

![image](https://github.com/MayconLSilva/OrionMensageria/assets/24304710/b3276d05-e026-479d-adc4-01b443512950)

> Após acessar o container do RabbitMQ, basta navegar até a aba Queues

![image](https://github.com/MayconLSilva/OrionMensageria/assets/24304710/907d831a-d884-4084-9f1c-e5b88a4414d6)

> Você pode clicar sobre o nome da fila e rolar a página até encontrar "Get messages" e validar as msgs.

![image](https://github.com/MayconLSilva/OrionMensageria/assets/24304710/a70ec60b-d5d9-43d2-a567-87f0710af22b)


## Contribuição:
Contribuições são bem-vindas! Se você encontrou um BUG, melhoria, tem alguma ideia para incluir no projeto ou deseja adicionar novos recursos, fique a vontade para abrir uma issue ou enviar um pull request.
