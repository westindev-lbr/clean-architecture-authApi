# DOC API AUTHENTIFICATION

Projet Securité 
Axel Labarre L3 - Université de Paris 8

## S'enregistrer

```http
POST {{host}}api/auth/register
```

```curl
curl -X POST -H 'Content-Type: application/json' -d '{"email": "axel.labarre@etud.univ-paris8.fr",
    "studentNum": 20006281,
    "firstName": "Axel",
    "lastName": "Labarre",
    "password": "toto93"}' https://localhost:7206/api/auth/register
```

## Se connecter

```http
POST {{host}}api/auth/login
```

```curl
curl -X POST -H 'Content-Type: application/json' -d '{"email": "test@test.fr", "password": "password"}' https://localhost:7206/api/auth/login
```

## Liste des étudiants

```http
GET {{host}}api/user/all
Authorization: Bearer xxxxxxxx
```
xxxxxxxx -> *votre token*
Afin de pouvoir accéder à la liste des étudiants il faut que l'api vérifie votre token lors de la requête http.
Il faut donc que votre token soit présent dans le header.Authorization HTTP

```curl
curl -i https://localhost:7206/api/user/all -H "Authorization: Bearer xxxxxxxx..."
```

### How to use :

* Install .NET 6
> https://dotnet.microsoft.com/en-us/download/dotnet/6.0

```shell
dotnet build
```

```shell
dotnet run --project alabarre.Api
```
