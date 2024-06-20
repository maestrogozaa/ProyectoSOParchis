DROP DATABASE IF EXISTS M4_BBDDParchis;

CREATE DATABASE M4_BBDDParchis;
USE M4_BBDDParchis;

CREATE TABLE Partida(
	ID_Partida INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATE,
	N_Jugadores INT,
	Jugador1 VARCHAR(50),
	Jugador2 VARCHAR(50),
	Jugador3 VARCHAR(50),
	Jugador4 VARCHAR(50)
)ENGINE = InnoDB;

CREATE TABLE Usuario(
    	ID_Usuario INT AUTO_INCREMENT PRIMARY KEY,
    	Nombre_Usuario VARCHAR(50),
    	Correo VARCHAR(100),
    	Passwd VARCHAR(50),
    	Victorias INT	
)ENGINE = InnoDB;

CREATE TABLE Participacion (
	IDJ INTEGER NOT NULL,
	IDP INTEGER NOT NULL,
	Posicion INTEGER NOT NULL,
	FOREIGN KEY (IDJ) REFERENCES Usuario(ID_Usuario),
	FOREIGN KEY (IDP) REFERENCES Partida(ID_Partida)
)ENGINE = InnoDB;

INSERT INTO Usuario (Nombre_Usuario, Correo, Passwd, Victorias)
VALUES ('Miguel Angel', 'miguelangel@gmail.com', 'Miguel Angel', 0);

INSERT INTO Usuario (Nombre_Usuario, Correo, Passwd, Victorias)
VALUES ('Albert', 'Albert@gmail.com', 'Albert', 0);

INSERT INTO Usuario (Nombre_Usuario, Correo, Passwd, Victorias)
VALUES ('Marti', 'Marti@gmail.com', 'Marti', 0);

INSERT INTO Partida (fecha, N_Jugadores, Jugador1, Jugador2, Jugador3, Jugador4)
VALUES ('2024-05-01', 2, 'Miguel Angel', 'Albert', NULL, NULL);

INSERT INTO Partida (fecha, N_Jugadores, Jugador1, Jugador2, Jugador3, Jugador4)
VALUES ('2024-05-02', 3, 'Marti', 'Miguel Angel', 'Albert', NULL);

INSERT INTO Partida (fecha, N_Jugadores, Jugador1, Jugador2, Jugador3, Jugador4)
VALUES ('2024-05-03', 1, 'Albert', NULL, NULL, NULL);

INSERT INTO Partida (fecha, N_Jugadores, Jugador1, Jugador2, Jugador3, Jugador4)
VALUES ('2024-05-03', 1, 'Marti', NULL, NULL, NULL);

INSERT INTO Partida (fecha, N_Jugadores, Jugador1, Jugador2, Jugador3, Jugador4)
VALUES ('2024-05-04', 2, 'Albert', 'Marti', NULL, NULL);

INSERT INTO Partida (fecha, N_Jugadores, Jugador1, Jugador2, Jugador3, Jugador4)
VALUES ('2024-05-05', 2, 'Marti', 'Miguel Angel', NULL, NULL);
