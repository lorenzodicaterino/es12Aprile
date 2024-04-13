```sql
CREATE TABLE Squadra(
squadraID INT PRIMARY KEY IDENTITY(1,1),
codice_squadra VARCHAR(250) DEFAULT NEWID() ,
nome VARCHAR(250) NOT NULL UNIQUE,
crediti INT DEFAULT 10,
);

CREATE TABLE Personaggio(
personaggioID INT PRIMARY KEY IDENTITY(1,1),
codice_personaggio VARCHAR(250) DEFAULT NEWID() ,
nome VARCHAR(250) NOT NULL,
costo INT NOT NULL CHECK(costo >=1 AND costo <=4),
categoria INT NOT NULL CHECK (categoria IN (50,100,150)),
foto VARCHAR(250) NOT NULL,
squadraRIF INT,
FOREIGN KEY (squadraRIF) REFERENCES Squadra(squadraID) ON DELETE SET NULL
);
```
