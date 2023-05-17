DROP TABLE IF EXISTS items;

CREATE TABLE items (
                       id int IDENTITY(1,1) PRIMARY KEY,
                       title VARCHAR(50) NOT NULL,
                       deadline date NOT NULL,
                       important bit NOT NULL
);