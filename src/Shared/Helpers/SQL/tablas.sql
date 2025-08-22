CREATE TABLE tournaments (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(150) NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    Ubicacion VARCHAR(200) NOT NULL
);

CREATE TABLE teams (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Pais VARCHAR(100) NOT NULL,
    Ciudad VARCHAR(100),
    GolesAFavor INT DEFAULT 0,
    GolesEnContra INT DEFAULT 0
);

CREATE TABLE players (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Edad INT NOT NULL,
    Posicion VARCHAR(50),
    ValorMercado DECIMAL(18,2),
    Asistencias INT DEFAULT 0,
    Goles INT DEFAULT 0,
    TeamId INT,
    FOREIGN KEY (TeamId) REFERENCES teams(Id)
);


CREATE TABLE cuerposmedicos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50),
    especialidad VARCHAR(100)
);


CREATE TABLE cuerpostecnicos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50),
    rol VARCHAR(100)
);


CREATE TABLE inscripciones (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    TeamId INT NOT NULL,
    TournamentId INT NOT NULL,
    CuerpoMedicoId INT,
    CuerpoTecnicoId INT,
    FechaInscripcion DATETIME NOT NULL,
    CONSTRAINT fk_inscripciones_medico
        FOREIGN KEY (CuerpoMedicoId) REFERENCES cuerposmedicos(id)
        ON DELETE SET NULL ON UPDATE CASCADE,

    CONSTRAINT fk_inscripciones_tecnico
        FOREIGN KEY (CuerpoTecnicoId) REFERENCES cuerpostecnicos(id)
        ON DELETE SET NULL ON UPDATE CASCADE
);



CREATE TABLE Transferencias (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    PlayerId INT NOT NULL,
    TeamOrigenId INT NOT NULL,
    TeamDestinoId INT NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    Tipo VARCHAR(20) NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (PlayerId) REFERENCES players(Id),
    FOREIGN KEY (TeamOrigenId) REFERENCES teams(Id),
    FOREIGN KEY (TeamDestinoId) REFERENCES teams(Id)
);
