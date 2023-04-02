create database DB_QCUIDADO
default character set utf8
default collate utf8_general_ci;


use DB_QCUIDADO;

/* CRIAÇÃO DAS TABELAS */


create table FUNCIONARIO
(
FUNCIONARIO_ID int primary key auto_increment,
NOME_FUNCIONARIO varchar(100) not null,
EMAIL_FUNCIONARIO varchar(50) not null, 
SENHA_FUNCIONARIO char(8) not null, 
DATA_NASCIMENTO date not null, 
SEXO char(1) not null, 
CELULAR_FUNCIONARIO varchar(20) not null, 
CPF char(14), 
LOGRADOURO varchar(100) not null,
CEP char(8) not null, 
NUMERO_LOGRADOURO char(5),
BAIRRO varchar(50) not null,
CIDADE varchar(50) not null, 
ESTADO char(2) not null,
NV_ACESSO enum('1','2') not null
)default charset utf8; 


create table CLIENTE
(
CLIENTE_ID int primary key auto_increment,
NOME_CLIENTE varchar(100) not null,
EMAIL_CLIENTE varchar(50) not null, 
SENHA_CLIENTE char(8) not null, 
DATA_NASCIMENTO date,
SEXO char(1) not null,
CELULAR_CLIENTE varchar(20) not null,
CELULAR_FAMILIA varchar(20) not null, 
CPF char(14)not null, 
LOGRADOURO varchar(100) not null,
CEP char(8) not null, 
NUMERO_LOGRADOURO char(5),
BAIRRO varchar(50) not null,
CIDADE varchar(50) not null, 
ESTADO char(2),
INFOS_ADICIONAIS varchar(255),
DS_STATUS varchar(50)
)default charset utf8;

create table PAGAMENTO
(
PAGAMENTO_ID int primary key auto_increment,
DESC_PAGAMENTO varchar(20)
)default charset utf8;

INSERT INTO PAGAMENTO(DESC_PAGAMENTO) VALUES('PIX');
INSERT INTO PAGAMENTO(DESC_PAGAMENTO) VALUES('CARTÃO');

create table EMPRESA 
(
EMPRESA_ID int primary key auto_increment, 
NOME_EMPRESA varchar(100) not null, 
CNPJ char(18) not null,
LOGRADOURO varchar(100) not null,
CEP char(8) not null, 
NUMERO_LOGRADOURO char(5),
BAIRRO varchar(50) not null,
CIDADE varchar(50) not null, 
ESTADO char(2),
TELEFONE_EMPRESA varchar(20)
)default charset utf8; 

create table PRESTADOR
(
PRESTADOR_ID int primary key auto_increment, 
NOME_PRESTADOR varchar(100) not null,
EMAIL_PRESTADOR varchar(50) not null, 
DATA_NASCIMENTO date, 
SEXO char(1) not null,
CELULAR_PRESTADOR varchar(20) not null, 
CPF char(14) not null, 
LOGRADOURO varchar(100) not null,
CEP char(8) not null, 
NUMERO_LOGRADOURO char(5),
BAIRRO varchar(50) not null,
CIDADE varchar(50) not null, 
ESTADO char(2),
EMPRESA_ID int, 
foreign key(EMPRESA_ID) references EMPRESA(EMPRESA_ID) on delete cascade
)default charset utf8;


create table AGENDASERVICO
(
AGENDASERVICO_ID int primary key auto_increment, 
TIPO_SERVICO varchar(255) not null,
DESC_SERVICO varchar(255) not null,
LOCAL_INICIO varchar(255) not null,
LOCAL_DESTINO varchar(255),
VALOR_SERVICO decimal(10,2),
DATA_SERVICO date, 
HORARIO time,
HORARIO_TERMINO time, 
STATUSSERVICO varchar(50),
FUNCIONARIO_ID int,
CLIENTE_ID int, 
PRESTADOR_ID int,
PAGAMENTO_ID int,
foreign key(FUNCIONARIO_ID) references FUNCIONARIO(FUNCIONARIO_ID),
foreign key(CLIENTE_ID) references CLIENTE(CLIENTE_ID) on delete cascade,
foreign key(PRESTADOR_ID) references PRESTADOR(PRESTADOR_ID) on delete cascade,
foreign key(PAGAMENTO_ID) references PAGAMENTO(PAGAMENTO_ID)
)default charset utf8;

drop table AGENDASERVICO;

drop procedure if exists sp_InsFuncionario;
DELIMITER && 
create procedure sp_InsFuncionario
(
NOME_FUNCIONARIO VARCHAR(100),
EMAIL_FUNCIONARIO varchar(50),
SENHA_FUNCIONARIO CHAR(8),
DATA_NASCIMENTO DATE,
SEXO CHAR(1),
CELULAR_FUNCIONARIO VARCHAR(20),
CPF CHAR(14),
LOGRADOURO VARCHAR(100),
CEP CHAR(8),
NUMERO_LOGRADOURO CHAR(5),
BAIRRO VARCHAR(50),
CIDADE VARCHAR(50),
ESTADO CHAR(2),
NV_ACESSO enum('1','2')
)
begin
insert into FUNCIONARIO(NOME_FUNCIONARIO, EMAIL_FUNCIONARIO, SENHA_FUNCIONARIO, DATA_NASCIMENTO, SEXO, CELULAR_FUNCIONARIO, CPF, LOGRADOURO, CEP,
NUMERO_LOGRADOURO, BAIRRO, CIDADE, ESTADO, NV_ACESSO) values(NOME_FUNCIONARIO, EMAIL_FUNCIONARIO, SENHA_FUNCIONARIO, DATA_NASCIMENTO, SEXO, 
CELULAR_FUNCIONARIO, CPF, LOGRADOURO, CEP, NUMERO_LOGRADOURO, BAIRRO, CIDADE, ESTADO, NV_ACESSO);
end &&
DELIMITER ;

-- INSERT NECESSÁRIO PARA O LOGIN
call sp_InsFuncionario('Admin2','Admin@gmail.com','Admin123','2022-09-23','F','976448267','52732962856','Av. Padre Guerino',
'06288030','12345','Vila Menck','Osasco', 'SP','1'); 

drop procedure if exists sp_InsCliente;
DELIMITER && 
create procedure sp_InsCliente
(
NOME_CLIENTE VARCHAR(100),
EMAIL_CLIENTE VARCHAR(50),
SENHA_CLIENTE CHAR(8), 
DATA_NASCIMENTO DATE, 
SEXO CHAR(1),
CELULAR_CLIENTE VARCHAR(20),
CELULAR_FAMILIA VARCHAR(20),
CPF CHAR(14),
LOGRADOURO VARCHAR(100), 
CEP CHAR(8), 
NUMERO_LOGRADOURO CHAR(5),
BAIRRO VARCHAR(50),
CIDADE VARCHAR(50),
ESTADO CHAR(2),
INFOS_ADICIONAIS VARCHAR(255)
)
begin
declare DS_STATUS varchar(50);
set DS_STATUS = 'ATIVO'; 
insert into CLIENTE(NOME_CLIENTE, EMAIL_CLIENTE, SENHA_CLIENTE, DATA_NASCIMENTO, SEXO, CELULAR_CLIENTE, CELULAR_FAMILIA, CPF, LOGRADOURO, CEP,
NUMERO_LOGRADOURO, BAIRRO, CIDADE, ESTADO, INFOS_ADICIONAIS, DS_STATUS) values(NOME_CLIENTE, EMAIL_CLIENTE, SENHA_CLIENTE, 
DATA_NASCIMENTO, SEXO, CELULAR_CLIENTE, CELULAR_FAMILIA, CPF, LOGRADOURO, CEP, NUMERO_LOGRADOURO, BAIRRO, CIDADE, ESTADO, INFOS_ADICIONAIS, DS_STATUS);
end && 
DELIMITER ; 



drop procedure if exists sp_InsEmpresa;
DELIMITER && 
create procedure sp_InsEmpresa
(
NOME_EMPRESA varchar(100), 
CNPJ char(18), 
LOGRADOURO varchar(100),
CEP char(8),
NUMERO_LOGRADOURO char(5),
BAIRRO varchar(50),
CIDADE varchar(50),
ESTADO char(2),
TELEFONE_EMPRESA varchar(20)
)
begin
insert into EMPRESA(NOME_EMPRESA, CNPJ, LOGRADOURO, CEP, NUMERO_LOGRADOURO, BAIRRO, CIDADE, ESTADO, TELEFONE_EMPRESA) values
(NOME_EMPRESA, CNPJ, LOGRADOURO, CEP, NUMERO_LOGRADOURO, BAIRRO, CIDADE, ESTADO, TELEFONE_EMPRESA);
end && 
DELIMITER ; 




drop procedure if exists sp_InsPrestador;
DELIMITER &&
create procedure sp_InsPrestador
(
NOME_PRESTADOR Varchar(100),
EMAIL_PRESTADOR Varchar(50),
DATA_NASCIMENTO DATE,
SEXO CHAR(1),
CELULAR_PRESTADOR VARCHAR(20),
CPF CHAR(14),
LOGRADOURO VARCHAR(100),
CEP CHAR(8),
NUMERO_LOGRADOURO CHAR(5),
BAIRRO VARCHAR(50),
CIDADE VARCHAR(50),
ESTADO CHAR(2),
EMPRESA_ID INT
)
BEGIN
INSERT INTO
PRESTADOR(NOME_PRESTADOR, EMAIL_PRESTADOR, DATA_NASCIMENTO, SEXO, CELULAR_PRESTADOR, CPF, LOGRADOURO, CEP,
NUMERO_LOGRADOURO, BAIRRO, CIDADE, ESTADO, EMPRESA_ID) VALUES (NOME_PRESTADOR, EMAIL_PRESTADOR, DATA_NASCIMENTO, SEXO, CELULAR_PRESTADOR, CPF, LOGRADOURO, CEP,
NUMERO_LOGRADOURO, BAIRRO, CIDADE, ESTADO, EMPRESA_ID);
End &&
DELIMITER ;

drop procedure if exists sp_InsAgendaservico;
DELIMITER && 
create procedure sp_InsAgendaservico
(
TIPO_SERVICO VARCHAR(255),
DESC_SERVICO VARCHAR(255),
LOCAL_INICIO VARCHAR(255),
LOCAL_DESTINO VARCHAR(255),
VALOR_SERVICO DECIMAL(10,2), 
DATA_SERVICO DATE, 
HORARIO TIME, 
HORARIO_TERMINO TIME, 
CLIENTE_ID INT,
PAGAMENTO_ID INT
)
begin
DECLARE STATUSSERVICO VARCHAR(50);
SET STATUSSERVICO = 'EM ANÁLISE';
INSERT INTO AGENDASERVICO(TIPO_SERVICO, DESC_SERVICO, LOCAL_INICIO, LOCAL_DESTINO, VALOR_SERVICO, DATA_SERVICO, HORARIO, HORARIO_TERMINO, CLIENTE_ID, PAGAMENTO_ID, STATUSSERVICO) VALUES
(TIPO_SERVICO, DESC_SERVICO, LOCAL_INICIO, LOCAL_DESTINO, VALOR_SERVICO, DATA_SERVICO, HORARIO, HORARIO_TERMINO, CLIENTE_ID, PAGAMENTO_ID, STATUSSERVICO);
END && 
DELIMITER ; 



drop procedure if exists sp_MostraFuncionario;
delimiter &&
create procedure sp_MostraFuncionario()
begin 
select * from FUNCIONARIO order by NOME_FUNCIONARIO asc;
end &&
delimiter ;



drop procedure if exists sp_MostraEmpresa;
delimiter && 
create procedure sp_MostraEmpresa()
begin 
select * from EMPRESA order by NOME_EMPRESA asc;
end && 
delimiter ; 



drop procedure if exists sp_MostraCliente;
delimiter &&
create procedure sp_MostraCliente()
begin
select * from CLIENTE order by NOME_CLIENTE asc;
end &&
delimiter ; 




drop procedure if exists sp_ConsultaPerfil;
delimiter $$
create procedure sp_ConsultaPerfil( in CodCli int)
begin
    select CLIENTE_ID,NOME_CLIENTE, EMAIL_CLIENTE, SENHA_CLIENTE, DATA_NASCIMENTO, SEXO, CELULAR_CLIENTE, CELULAR_FAMILIA, CPF, 
    LOGRADOURO,CEP, NUMERO_LOGRADOURO, BAIRRO,CIDADE,ESTADO, INFOS_ADICIONAIS, DS_STATUS from CLIENTE
    where CLIENTE_ID = CodCli; 
end $$ 
delimiter ;



drop view if exists vw_ConsultaPrestador; 
create view vw_ConsultaPrestador as 
select 
PE.PRESTADOR_ID,
PE.NOME_PRESTADOR,
PE.EMAIL_PRESTADOR,
PE.DATA_NASCIMENTO,
PE.SEXO, 
PE.CELULAR_PRESTADOR,
PE.CPF,
PE.LOGRADOURO,
PE.CEP,
PE.NUMERO_LOGRADOURO,
PE.BAIRRO,
PE.CIDADE,
PE.ESTADO,
PE.EMPRESA_ID,
EM.NOME_EMPRESA
from PRESTADOR as PE left join EMPRESA AS EM on EM.EMPRESA_ID = PE.EMPRESA_ID;

drop procedure if exists sp_MostraPrestador;
delimiter && 
create procedure sp_MostraPrestador()
begin
select * from vw_ConsultaPrestador order by NOME_PRESTADOR asc;
end && 
delimiter ; 






drop procedure if exists sp_MostraAgenda;
delimiter &&
create procedure sp_MostraAgenda()
begin
select * from AGENDASERVICO where STATUSSERVICO = 'EM ANÁLISE';
end &&
delimiter ; 

call sp_MostraAgenda;

drop procedure if exists sp_MostraAgendaConfirmado;
delimiter &&
create procedure sp_MostraAgendaConfirmado()
begin
select * from AGENDASERVICO where STATUSSERVICO = 'APROVADO';
end &&
delimiter ; 

call sp_MostraAgendaConfirmado();

drop procedure if exists sp_ExcFuncionario;
DELIMITER &&
create procedure sp_ExcFuncionario
(
EFUNCIONARIO_ID int
)
begin
delete from FUNCIONARIO where FUNCIONARIO_ID = EFUNCIONARIO_ID;
end &&
DELIMITER ;



drop procedure if exists sp_ExcEmpresa; 
DELIMITER &&
Create procedure sp_ExcEmpresa
(
EEMPRESA_ID INT
)
BEGIN
DELETE FROM EMPRESA WHERE EMPRESA_ID =  EEMPRESA_ID;
END &&
DELIMITER ;


drop procedure if exists sp_ExcPrestador;
DELIMITER &&
Create procedure sp_ExcPrestador
(
EPRESTADOR_ID INT
)
BEGIN
DELETE FROM PRESTADOR WHERE PRESTADOR_ID =  EPRESTADOR_ID;
END &&
DELIMITER ;

drop procedure if exists sp_AltFuncionario;
DELIMITER && 
create procedure sp_AltFuncionario
(
ALT_FUNCIONARIO_ID int,
NOME_FUNCIONARIO VARCHAR(100),
EMAIL_FUNCIONARIO varchar(50),
SENHA_FUNCIONARIO CHAR(8),
DATA_NASCIMENTO DATE,
SEXO CHAR(1),
CELULAR_FUNCIONARIO VARCHAR(20),
CPF CHAR(14),
LOGRADOURO VARCHAR(50),
CEP CHAR(8),
NUMERO_LOGRADOURO CHAR(5),
BAIRRO VARCHAR(50),
CIDADE VARCHAR(50),
ESTADO CHAR(2),
NV_ACESSO enum('1','2')
)
begin
update FUNCIONARIO set NOME_FUNCIONARIO = NOME_FUNCIONARIO, EMAIL_FUNCIONARIO = EMAIL_FUNCIONARIO, 
SENHA_FUNCIONARIO = SENHA_FUNCIONARIO, DATA_NASCIMENTO = DATA_NASCIMENTO, SEXO = SEXO, CELULAR_FUNCIONARIO = CELULAR_FUNCIONARIO,
CPF = CPF, LOGRADOURO = LOGRADOURO, CEP = CEP, NUMERO_LOGRADOURO = NUMERO_LOGRADOURO, BAIRRO = BAIRRO, CIDADE = CIDADE, 
ESTADO = ESTADO, NV_ACESSO = NV_ACESSO where FUNCIONARIO_ID = ALT_FUNCIONARIO_ID;
end && 
DELIMITER ; 


drop procedure if exists sp_AltCliente;
DELIMITER && 
create procedure sp_AltCliente
(
ALT_CLIENTE_ID int,
NOME_CLIENTE VARCHAR(100),
EMAIL_CLIENTE varchar(50),
SENHA_CLIENTE CHAR(8),
DATA_NASCIMENTO DATE,
SEXO CHAR(1),
CELULAR_CLIENTE VARCHAR(20),
CELULAR_FAMILIA VARCHAR(20),
CPF CHAR(14),
LOGRADOURO VARCHAR(50),
CEP CHAR(8),
NUMERO_LOGRADOURO CHAR(5),
BAIRRO VARCHAR(50),
CIDADE VARCHAR(50),
ESTADO CHAR(2),
INFOS_ADICIONAIS VARCHAR(255)
)
begin
declare DS_STATUS varchar(50);
set DS_STATUS = 'ATIVO'; 
update CLIENTE set NOME_CLIENTE = NOME_CLIENTE, EMAIL_CLIENTE = EMAIL_CLIENTE, 
SENHA_CLIENTE = SENHA_CLIENTE, DATA_NASCIMENTO = DATA_NASCIMENTO, SEXO = SEXO, CELULAR_CLIENTE = CELULAR_CLIENTE, CELULAR_FAMILIA = CELULAR_FAMILIA,
CPF = CPF, LOGRADOURO = LOGRADOURO, CEP = CEP, NUMERO_LOGRADOURO = NUMERO_LOGRADOURO, BAIRRO = BAIRRO, CIDADE = CIDADE, 
ESTADO = ESTADO, INFOS_ADICIONAIS = INFOS_ADICIONAIS, DS_STATUS = DS_STATUS where CLIENTE_ID = ALT_CLIENTE_ID;
end && 
DELIMITER ; 




drop procedure if exists sp_AltEmpresa;
DELIMITER &&
Create procedure sp_AltEmpresa
(
ALTEMPRESA_ID int,
NOME_EMPRESA Varchar(100),
CNPJ char(18),
LOGRADOURO VARCHAR(100),
CEP CHAR(8),
NUMERO_LOGRADOURO CHAR(5),
BAIRRO VARCHAR(50),
CIDADE VARCHAR(50),
ESTADO CHAR(2),
TELEFONE_EMPRESA VARCHAR(20)
)
BEGIN
UPDATE EMPRESA SET NOME_EMPRESA = NOME_EMPRESA, CNPJ = CNPJ, LOGRADOURO = LOGRADOURO, CEP = CEP, NUMERO_LOGRADOURO =
NUMERO_LOGRADOURO, BAIRRO = BAIRRO, CIDADE = CIDADE, ESTADO = ESTADO, TELEFONE_EMPRESA = TELEFONE_EMPRESA WHERE EMPRESA_ID = ALTEMPRESA_ID;
END &&
DELIMITER ;


drop procedure if exists sp_AltPrestador;
DELIMITER &&
Create procedure sp_AltPrestador
(
ALTPRESTADOR_ID int,
NOME_PRESTADOR Varchar(100),
EMAIL_PRESTADOR Varchar(50),
DATA_NASCIMENTO DATE,
SEXO CHAR(1),
CELULAR_PRESTADOR VARCHAR(20),
CPF CHAR(14),
LOGRADOURO Varchar(100),
CEP CHAR(8),
NUMERO_LOGRADOURO CHAR(5),
BAIRRO VARCHAR(50),
CIDADE VARCHAR(50),
ESTADO CHAR(2),
EMPRESA_ID INT
)
BEGIN
UPDATE PRESTADOR SET NOME_PRESTADOR = NOME_PRESTADOR, EMAIL_PRESTADOR = EMAIL_PRESTADOR, DATA_NASCIMENTO =
DATA_NASCIMENTO, SEXO = SEXO, CELULAR_PRESTADOR = CELULAR_PRESTADOR, CPF = CPF, LOGRADOURO = LOGRADOURO, CEP = CEP,
NUMERO_LOGRADOURO = NUMERO_LOGRADOURO, BAIRRO = BAIRRO, CIDADE = CIDADE, ESTADO = ESTADO, EMPRESA_ID = EMPRESA_ID
WHERE PRESTADOR_ID = ALTPRESTADOR_ID;
END &&
DELIMITER ;

drop procedure if exists sp_AltServicoAdmin;
DELIMITER && 
create procedure sp_AltServicoAdmin
(
ALTAGENDASERVICO_ID int,
STATUSSERVICO VARCHAR(50),
PRESTADOR_ID INT
)
begin
update AGENDASERVICO set STATUSSERVICO = STATUSSERVICO, PRESTADOR_ID = PRESTADOR_ID WHERE AGENDASERVICO_ID = ALTAGENDASERVICO_ID;
END && 
DELIMITER ; 


drop procedure if exists sp_AtivarConta; 
DELIMITER && 
create procedure sp_AtivarConta
(
 CodUsuario int
)
BEGIN 
declare DS_STATUS VARCHAR(50);  
set DS_STATUS = 'ATIVO';  
update CLIENTE
set DS_STATUS = DS_STATUS where CLIENTE_ID = CodUsuario; 
end &&
DELIMITER ;

drop procedure if exists sp_DesativarConta; 
DELIMITER && 
create procedure sp_DesativarConta
(
 CodUsuario int
)
BEGIN 
declare DS_STATUS VARCHAR(50);  
set DS_STATUS = 'INATIVO';  
update CLIENTE
set DS_STATUS = DS_STATUS where CLIENTE_ID = CodUsuario; 
end &&
DELIMITER ;

drop procedure if exists sp_Dashboard;
delimiter &&
create procedure sp_Dashboard()
begin 
Select (Select sum(VALOR_SERVICO) from AGENDASERVICO) as Caixa,
(Select count(FUNCIONARIO_ID) from FUNCIONARIO) as Funcionarios,
(Select count(CLIENTE_ID) from CLIENTE) as Clientes,
(Select count(PRESTADOR_ID) from PRESTADOR) as Prestadores,
(Select count(EMPRESA_ID) from EMPRESA) as Empresas,
(Select count(AGENDASERVICO_ID) from AGENDASERVICO) as Servicos;
end &&
delimiter ;



SELECT * FROM EMPRESA; 
SELECT * FROM PRESTADOR;
SELECT * FROM AGENDASERVICO;
SELECT * FROM FUNCIONARIO;
SELECT * FROM CLIENTE;