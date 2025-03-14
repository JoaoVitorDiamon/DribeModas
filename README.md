# PROJETO 5: Sistema Integrado de Gestão de Loja

## Sobre o Projeto

O **Sistema Integrado de Gestão de Loja (SIGL)** é uma solução abrangente projetada para facilitar o gerenciamento de uma loja, seja ela física ou online. Desenvolvido para oferecer eficiência e praticidade, o SIGL abrange uma variedade de funcionalidades essenciais para o gerenciamento de recursos e vendas.

## Funcionalidades

- **Cadastro de Produtos**: Registre detalhes essenciais dos produtos, incluindo nome, descrição, preço, estoque e fornecedor.
- **Gestão de Estoque**: Monitore o estoque de produtos em tempo real, recebendo alertas de reabastecimento quando necessário e gerenciando entradas e saídas de mercadorias.
- **Gestão de Vendas**: Registre vendas de forma eficiente, acompanhando detalhes como data, cliente, produtos vendidos e forma de pagamento.
- **Gestão de Clientes**: Mantenha um registro de clientes, incluindo informações de contato, histórico de compras e preferências, para oferecer um serviço personalizado e fidelizar clientes.
- **Relatórios de Vendas**: Acesse relatórios detalhados que fornecem insights valiosos sobre o desempenho de vendas, incluindo análises de produtos mais vendidos, tendências de vendas e desempenho de vendedores.
- **Gestão Financeira**: Registre despesas, receitas e lucros da loja, facilitando o controle financeiro e a tomada de decisões estratégicas.

## Tecnologias Utilizadas

O SIGL foi desenvolvido utilizando as seguintes tecnologias:

- **C# (WinForms)** - Aplicação desktop para gestão da loja.
- **MariaDB** - Banco de dados para armazenamento de produtos, clientes e transações.
- **Bunifu** - Biblioteca para melhorar a interface do usuário no WinForms.
- **PHP** - Desenvolvimento da interface web do sistema.

## Como Executar o Projeto

### Requisitos:
- Ter **MariaDB** instalado e configurado.
- Ter **.NET Framework** compatível com o projeto.
- Ter um servidor **Apache** ou similar para executar a aplicação PHP.

### Passos:
1. Clone este repositório:
   ```sh
   git clone https://github.com/seu-usuario/nome-do-repo.git
   ```
2. Configure o banco de dados **MariaDB** importando o arquivo SQL disponível no repositório.
3. Acesse a pasta do projeto e execute o sistema:
   - Para a aplicação desktop (WinForms):
     ```sh
     Abra o projeto no Visual Studio e execute.
     ```
   - Para o sistema web (PHP):
     ```sh
     Configure um servidor Apache e coloque os arquivos na pasta apropriada.
     ```
