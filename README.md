# Incident Search App

## Description

Cette application web permet de faire des recherche d'incidents dans une base contenant 100 000 entrées.  
Elle propose des filtres sur les champs : title, description, severity et owner (nom, prénom, e-mail).  

**Stack technique :**

- Backend : .NET 8 WebAPI + Entity Framework Core  
- Frontend : Blazor Server  
- Base de données : PostgreSQL  
- Conteneurisation : Docker Compose  


## Structure du projet

/backend -> Projet .NET WebAPI
/frontend -> Projet Blazor Server
/optimizations -> Documentation des optimisations appliquées
/docker-compose.yml -> Configuration Docker pour PostgreSQL
/01-ddl.sql -> Création des tables + index
/02-data.sql -> Insertion des données (100k incidents)
README.md -> Ce fichier


## Lancer l’application

### Docker

Pour lancer PostgreSQL avec les données :

docker-compose up

# Backend 
Ouvrir le projet backend dans Visual Studio.

dans le terminal lancer les variables d'env suivantes : 
setx DB_USER user
setx DB_PASSWORD password
setx DB_NAME incidents

Lancer l’API WebAPI.

L’API expose le endpoint :

GET /incidents


# Frontend

Ouvrir le projet frontend dans Visual Studio.

Lancer Blazor Server.
