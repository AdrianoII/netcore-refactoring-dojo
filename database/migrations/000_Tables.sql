CREATE TABLE Item(
    Id SERIAL PRIMARY KEY,
    Nome TEXT NOT NULL,
    PrazoValidade DATE,
    Qualidade SMALLINT NOT NULL,
    Categoria SMALLINT NOT NULL
);
