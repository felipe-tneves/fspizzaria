USE FSPIZZARIA;

INSERT INTO PIZZARIAS(NOME, ENDERECO, VEGANA, TELEFONE, ID_CATEGORIA)
VALUES ('Pizzaria Donatelo','Av. Barão de Limeira, 519', 1, '1199999999', 1),
('Fernandos Pizzasa','Av. Barão de Limeira, 518', 0, '1199999999', 3),
('Pizzaria Nova Era','Av. Barão de Limeira, 517', 1, '1199999999', 2),
('La Pizzeria','Av. Barão de Limeira, 516', 0, '1199999999', 1)

INSERT INTO CATEGORIAS(NOME, DESCRICAO)
VALUES('To durão','até R$30,00'),
('Só não posso gastar muito','de R$30,01 há R$50,00'),
('Dia de Pagamento','acima de R$50,00')

SELECT *FROM CATEGORIAS

INSERT INTO USUARIO(EMAIL,SENHA)
VALUES ('gandolf@a.a','132'),
('a@a.a','132'),
('b@b.b','132')