USE projeto_if;

INSERT INTO TipoUsuario(Descricao)
VALUES              ('Administrador'),
                    ('Funcionario'),
                    ('Especialista');

INSERT INTO Setor(Descricao)
VALUES              ('Administração'),
                    ('Limpeza'),
                    ('Manutenção'),
                    ('Suporte');
                    
INSERT INTO Usuario(IdTipoUsuario, IdSetor, Nome, Email, Senha, Telefone)
VALUES
                    (1, 1, 'Jucelino', 'jucelino.adm@gmail.com' , 'adm123' , '(11) 90000-0000'),
                    (2, 1, 'Caique' , 'caique@gmail.com', 'caique123', '(11) 91111-1111'),
                    (2, 1, 'Danilo', 'danilo@gmail.com', 'danilo123', '(11) 92222-2222'),
                    (3, 2, 'Luiz', 'luiz@gmail.com', 'luiz123', '(11) 93333-3333'),
                    (3, 3, 'Jessica', 'jessica@gmail.com', 'jessica123', '(11) 94444-4444'),
                    (3, 4, 'Raul' , 'raul@gmail.com', 'raul123', '(11) 95555-5555');
                    
INSERT INTO Material(Nome, Descricao, Tipo, Quantidade)
VALUES               ('Esfregão', 'Usado para limpar o chão', 'Limpeza' , '5'),
                     ('Pano', 'Usado secar as coisas ou enxugar o chão / limpar ', 'Limpeza', '5'),
                     ('Removedor', 'Usar remover manchas', 'Limpeza', '3'),
                     ('Chave de fenda', 'Usado para arrumar objetos', 'Manutenção', '4'),
                     ('Furadeira', 'Objeto perigoso', 'Manutenção', '3'),
                     ('Trena', 'Ferramenta de medida', 'Manutenção', '3'),
                     ('Computador', 'Usado para auxiliar maquinas da empresa', 'Suporte', '4');

INSERT INTO Prioridade(Descricao)
VALUES				('Baixa'),
					('Media'),
                    ('Alta');
                    
INSERT INTO StatusChamado(Descricao)
VALUES				('Aberto'),
					('Andamento'),
                    ('Concluido');

INSERT INTO Chamado(IdPrioridade, IdStatus, IdAutor, IdResponsavel, Descricao, Lugar, DataAbertura, DataDeFinalicao)
VALUES
                    (1, 3, 2, 4, 'Limpar chão da sala', 'Sala 1', '2021-10-21', '2021-10-22'),
                    (1, 2, 2, 4, 'Limpar mancha da parede', 'Sala 2', '2021-10-23', '2021-10-24'),
                    (2, 1, 3, 4, 'Limpar mesas', 'Sala 3', '2021-10-25', '2021-10-26'),
                    (3, 2, 2, 5, 'Arrumar Ar-condicionado', 'Sala 4', '2021-10-26', '2021-10-27'),
                    (2, 3, 3, 6, 'Instalar Software', 'Sala 5', '2021-10-27', '2021-10-28');
                    
INSERT INTO RegistroMateriais(IdMaterial, IdChamado, Quantidade)
VALUES				(1, 1, '1'),
					(3, 2, '1'),
                    (2, 3, '2'),
                    (4, 4, '1'),
                    (7, 5, '1');