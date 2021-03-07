CREATE DATABASE todoitems;

CREATE TABLE todos (
id serial PRIMARY KEY,
name VARCHAR(255) NOT NULL,
isComplete BOOLEAN DEFAULT false,
projectId INT NOT NULL,
CONSTRAINT fk_project FOREIGN KEY (projectId) REFERENCES projects(id));

CREATE TABLE projects (
    id serial PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);
