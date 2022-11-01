# Api

- [Auth]
  - [Register]
    - Register Request
    - Register Response
  - [Login]
    - Login Request
    - Login Response

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "email": "axel.labarre@etud.univ-paris8.fr",
    "studentNum": 20006281,
    "firstName": "Axel",
    "lastName": "Labarre",
    "password": "Toto93"
}
```

#### Register Response

```js
200 Ok
```

```json
{
    "id": "haeazdazoidjoizajdoazndoazn",
    "firstName": "Axel",
    "lastName": "Labarre",
    "email": "axel.labarre@etud.univ-paris8.fr",
    "studentNum": 20006281
}
```

Les 2 requetes doivent donc respecter un contrat.
