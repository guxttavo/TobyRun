CREATE TABLE categoria(
    id INT GENERATED ALWAYS AS IDENTITY,
    nome VARCHAR(200),
    id_categoria_pai INT, 

    CONSTRAINT pk_categoria PRIMARY KEY(id)
);

CREATE TABLE bairro(
    id smallint GENERATED ALWAYS AS IDENTITY,
    nome VARCHAR(200) NOT NULL,

	CONSTRAINT pk_bairro PRIMARY KEY(id)
);

CREATE TABLE usuario(
    id INT GENERATED ALWAYS AS IDENTITY,
    nome VARCHAR(200) NOT NULL,
    cpf BIGINT NOT NULL,
    data_nascimento DATE NOT NULL,
    telefone BIGINT NOT NULL,
    email VARCHAR(200) NOT NULL,
    cep INT NOT NULL,
    senha VARCHAR(200) NOT NULL,
    admin BOOL NOT NULL,
    data_cadastro DATE,
        
    CONSTRAINT pk_usuario PRIMARY KEY(id)
);

CREATE TABLE denuncia(
    id INT GENERATED ALWAYS AS IDENTITY,
    data DATE NOT NULL,
    descricao VARCHAR(2000),
    id_usuario INT NOT NULL,
    id_categoria INT NOT NULL,
    id_bairro INT NOT NULL,

    CONSTRAINT pk_denuncia PRIMARY KEY(id),
    CONSTRAINT fk_usuario FOREIGN KEY(id_usuario) REFERENCES usuario(id),
    CONSTRAINT fk_categoria_denuncia FOREIGN KEY(id_categoria) REFERENCES categoria(id),
    CONSTRAINT fk_bairro FOREIGN KEY(id_bairro) REFERENCES bairro(id)
);

-- CREATE TABLE denuncia(
--     id INT GENERATED ALWAYS AS IDENTITY,
--     data DATE NOT NULL,
--     descricao VARCHAR(2000),
--     id_usuario INT NOT NULL,
--     id_bairro INT NOT NULL,
--     id_categoria INT NOT NULL,
--     id_subcategoria INT NOT NULL,

--     CONSTRAINT pk_denuncia PRIMARY KEY(id),
--     CONSTRAINT fk_usuario FOREIGN KEY(id_usuario) REFERENCES usuario(id),
--     CONSTRAINT fk_categoria_denuncia FOREIGN KEY(id_categoria) REFERENCES categoria(id),
--     CONSTRAINT fk_subcategoria_denuncia FOREIGN KEY(id_subcategoria) REFERENCES categoria(id),
--     CONSTRAINT fk_bairro FOREIGN KEY(id_bairro) REFERENCES bairro(id)
-- );

CREATE TABLE suporte(
    id INT GENERATED ALWAYS AS IDENTITY,
    assunto VARCHAR(300) NOT NULL,
    descricao VARCHAR(5000) NOT NULL,
    id_usuario INT NOT NULL,

    CONSTRAINT pk_suporte PRIMARY KEY(id),
    CONSTRAINT fk_usuario FOREIGN KEY(id_usuario) REFERENCES usuario(id)
);


-- CREATE TABLE urgencia(
--     id smallint GENERATED ALWAYS AS IDENTITY,
--     nome VARCHAR(200) NOT NULL,
-- 	CONSTRAINT pk_urgencia PRIMARY KEY(id)
-- );