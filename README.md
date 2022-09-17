# API Produtos

Ps. Esta API pode ser consumida através do projeto do link abaixo, dentre os meus repositórios. 

> APIProdutoConsumo: https://github.com/victup/APIProdutoConsumo_LetsCode_M06

O guia para consumir, está descrito no Readme do repo APIProdutoConsumo 

## Sobre a API Produtos

![image](https://user-images.githubusercontent.com/38474570/188255600-17c50a29-ccc1-4d4f-8490-821506b93fa9.png)

Esta API efetua um CRUD de produtos.

## Replicando no ambiente

Para executar, além de clonar este repositório, é necessário substituir alguns valores no arquivo com nome <b> appsettings.json </b> dentro de APIProdutos, que contém o seguinte conteúdo. 

> { <br>
  "ConnectionStrings": { <br>
    "DefaultConnection": "Server= enderecoDaBasedeDados.com.br; Database=BaseExemplo; User Id=NomeUsuario; Password=SenhaUsuario; Encrypt=False" <br>
  }, <br>
  "Logging": { <br>
    "LogLevel": { <br>
      "Default": "Information", <br>
      "Microsoft.AspNetCore": "Warning" <br>
    } <br>
  }, <br>
  "AllowedHosts": "*" <br>
}

É necessário substituir os valores na linha do DefaultConnection para efetuar uma conexão. Por segurança, não foram colocados dados reais de uma base de dados.
* enderecoDaBasedeDados.com.br é o endereço do banco de dados; 
* BaseExemplo é o nome da base de dados;
* NomeUsuario é o nome do usuário com permissão de acesso na base de dados;
* SenhaUsuario é a senha do usuário que possui acesso à base de dados;
* Encrypt pode ser mantido como false.

## Autenticação e Autorização
  É necessário gerar um Token na API de Clientes, e inserir antes de executar qualquer método da API de Eventos. 
  
  Baixe a APIClientes para gerar o Token, leia o título <b> Geração de Token </b> na APIClientes
  > Repositório : https://github.com/victup/APIClientes_LetsCode_M06
  
  ![image](https://user-images.githubusercontent.com/38474570/190838931-f920e14b-9c07-47a5-a611-d1fd2a11e236.png)

Preencha com o token e clique em Authorize

  ![image](https://user-images.githubusercontent.com/38474570/190838939-f63e3b99-f7c5-4b96-a75f-0f1ec5b5d3df.png)
  
  Pronto, agora dependendo de sua permissão com base no token gerado na APIClientes você poderá utilizar os métodos da EventAPI

