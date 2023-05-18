DROP TABLE IF EXISTS items;

CREATE TABLE items (
                       id int IDENTITY(1,1) PRIMARY KEY,
                       title VARCHAR(50) NOT NULL,
                       deadline date NOT NULL,
                       important bit NOT NULL,
                       done bit NOT NULL
);

INSERT INTO items (title, deadline, important, done) 
VALUES ('The very first title', '2023-05-23', 1, 0);

INSERT INTO items (title, deadline, important, done)
VALUES ('Some random task', '2023-05-30', 0, 1);

INSERT INTO items (title, deadline, important, done)
VALUES ('Hello there', '2023-05-29', 1, 1);

INSERT INTO items (title, deadline, important, done)
VALUES ('Marking feature is great', '2023-05-22', 0, 1);