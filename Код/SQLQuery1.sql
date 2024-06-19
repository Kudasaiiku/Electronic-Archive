USE Archive;

CREATE TABLE Users (
  Логин VARCHAR(255),
  Пароль VARCHAR(255),
  Роль VARCHAR(255)
);

CREATE TABLE Cards (
  ДН VARCHAR(255) PRIMARY KEY,
  Название VARCHAR(255),
  Подразделение INT,
  Вид_документа VARCHAR(255),
  Знак_заказчика VARCHAR(255),
  Номер_решения VARCHAR(255),
  A0 INT,
  A1 INT,
  A2 INT,
  A3 INT,
  A4 INT,
  Другое VARCHAR(255),
  Количество INT,
  Подлинник VARCHAR(255),
  Дубликат VARCHAR(255),
  ИН_подлинник INT,
  ИН_дубликат INT,
  Дата_подлинник VARCHAR(255),
  Дата_дубликат VARCHAR(255),
  Литера VARCHAR(255)
);

CREATE TABLE Copies (
  ID_copies INT IDENTITY(1,1) PRIMARY KEY,
  ДН VARCHAR(255),
  Дата VARCHAR(255),
  Основание VARCHAR(255),
  Поступило INT,
  Списано INT,
  FOREIGN KEY (ДН) REFERENCES Cards(ДН)
);

CREATE TABLE Exploitation (
  ID_expl INT IDENTITY(1,1) PRIMARY KEY,
  ДН VARCHAR(255),
  Обозначение VARCHAR(255),
  FOREIGN KEY (ДН) REFERENCES Cards(ДН)
);

CREATE TABLE Changes (
  ID_changes INT IDENTITY(1,1) PRIMARY KEY,
  ДН VARCHAR(255),
  Номер_извещения FLOAT,
  Дата VARCHAR(255),
  FOREIGN KEY (ДН) REFERENCES Cards(ДН)
);
