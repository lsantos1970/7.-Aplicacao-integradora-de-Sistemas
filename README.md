Tarefa 7 - Atividade III: Aplicação integradora de Sistemas (Sistema de Apostas EuroMil)


O Sistema de Apostas Euromilhões é uma aplicação Windows Forms desenvolvida em .NET 8.0, permitindo apostas online num jogo similar ao Euromilhões. A aplicação integra dois serviços externos: CrediBankAPI (REST) para emissão de cheques digitais e EuroMilRegister (gRPC) para registo das apostas.

São definidas como especificações as seguintes funcionalidades:  

Para registar uma aposta no sistema, o utilizador da aplicação deve inserir:
- A chave em que pretende apostar, de acordo com as regras de formação das chaves do Euromilhões.
- A identificação da sua conta de crédito no sistema CredBank.

A aplicação para registar a aposta deve: 
- Contactar o sistema CredBank e pedir a emissão de um cheque digital no valor de 10 créditos.
- Contactar o sistema EuroMilRegister e colocar a aposta e o cheque digital;
- Informar o utilizador do sucesso ou fracasso da operação.
