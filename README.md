# API-AspNetCore-InMemory

Aplicação desenvolvida para a atividade Introdução à APIs com C# da matéria Tecnologias para Análise e Desenvolvimento de Sistemas - G1/T1 - 4ºP/40H - 2024/2.  

API InMemory é utilizada quando não se tem acesso ao banco de dados, o InMemory pode ser usado de forma temporária para moldar a API agilizando o processo de desenvolvimento, facilitando testes individuais ou em projetos conceituais. 


## Requisitos  

Ser baseado no objeto Usuario com os seguintes atributos:   
- Nome;
- Código;
- Preço;
- Descrição;
- QuantidadeEmEstoque;
- Avaliação;
- Categoria.

Possuir rotas para:  

- Criação de dados com Post;
- Leitura de todos os dados do banco com Get;
- Leitura de dados por código do produto com Get;
- Leitura de dados por categoria com Get;
- Atualização de informações com Put ou Patch; e
- Exclusão de elementos com Delete. 


# Tecnologias utilizadas  

Foi utilizando do EntityFrameworkCore.InMemory para alocar os dados coletados pela api em memória. 

Para esta aplicação foram utilizados os seguintes pacotes:  

-  **Microsoft.EntityFrameworkCore.InMemory**  
