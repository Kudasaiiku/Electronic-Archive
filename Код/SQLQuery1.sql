USE Archive;

CREATE TABLE Users (
  ����� VARCHAR(255),
  ������ VARCHAR(255),
  ���� VARCHAR(255)
);

CREATE TABLE Cards (
  �� VARCHAR(255) PRIMARY KEY,
  �������� VARCHAR(255),
  ������������� INT,
  ���_��������� VARCHAR(255),
  ����_��������� VARCHAR(255),
  �����_������� VARCHAR(255),
  A0 INT,
  A1 INT,
  A2 INT,
  A3 INT,
  A4 INT,
  ������ VARCHAR(255),
  ���������� INT,
  ��������� VARCHAR(255),
  �������� VARCHAR(255),
  ��_��������� INT,
  ��_�������� INT,
  ����_��������� VARCHAR(255),
  ����_�������� VARCHAR(255),
  ������ VARCHAR(255)
);

CREATE TABLE Copies (
  ID_copies INT IDENTITY(1,1) PRIMARY KEY,
  �� VARCHAR(255),
  ���� VARCHAR(255),
  ��������� VARCHAR(255),
  ��������� INT,
  ������� INT,
  FOREIGN KEY (��) REFERENCES Cards(��)
);

CREATE TABLE Exploitation (
  ID_expl INT IDENTITY(1,1) PRIMARY KEY,
  �� VARCHAR(255),
  ����������� VARCHAR(255),
  FOREIGN KEY (��) REFERENCES Cards(��)
);

CREATE TABLE Changes (
  ID_changes INT IDENTITY(1,1) PRIMARY KEY,
  �� VARCHAR(255),
  �����_��������� FLOAT,
  ���� VARCHAR(255),
  FOREIGN KEY (��) REFERENCES Cards(��)
);
