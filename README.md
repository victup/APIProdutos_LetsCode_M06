# API Produtos

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

