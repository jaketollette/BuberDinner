# BuberDinner API
- [BuberDinner API](#buberdinner-api)
  - [Authentication](#authentication)
    - [Register](#register)
      - [Request](#request)
      - [Responses](#responses)
        - [Success Response](#success-response)
        - [Error Responses](#error-responses)
          - [Duplicate Email](#duplicate-email)
          - [Invalid](#invalid)
    - [Login](#login)
      - [Request](#request-1)
      - [Responses](#responses-1)
        - [Success Response](#success-response-1)
        - [Error Response](#error-response)
          - [Invalid Credentials](#invalid-credentials)
          - [Invalid](#invalid-1)
  - [Menus](#menus)
    - [Create Menu](#create-menu)
      - [Request](#request-2)
      - [Response](#response)


## Authentication

### Register
```js
POST /auth/register
```

#### Request
```json
{
  "firstName": "Jake",
  "lastName": "Tollette",
  "email": "jaketollette@gmail.com",
  "password": "Password1!"
}
```

#### Responses
##### Success Response
```json
{
  "id": "814978ec-b7f3-4b60-ac02-4fdd5aebfe8e",
  "firstName": "Jake",
  "lastName": "Tollette",
  "email": "jaketollette@gmail.com",
  "token": "eyJhbGciOi...GNmpJanV7NSI"
}
```
##### Error Responses
###### Duplicate Email
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.10",
  "title": "Conflict",
  "status": 409,
  "detail": "Email already in use.",
  "traceId": "00-115d3541541ea76b09ea2263a195a11d-1853d95945decc3d-00",
  "errorCodes": [
    "User.DuplicateEmail"
  ]
}
```
###### Invalid
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "FirstName": [
      "'First Name' must not be empty."
    ]
  },
  "traceId": "00-b9461a9351e7e535b4d5dca4d84fd014-df1f880891a6d289-00"
}
```
### Login
```js
POST /auth/login
```

#### Request
```js
{
  "email": "jaketollette@gmail.com",
  "password": "Password1!"
}
```
#### Responses
##### Success Response
```json
{
  "id": "f7a4a612-0bb0-4f0e-87e6-87ee59750128",
  "firstName": "Jake",
  "lastName": "Tollette",
  "email": "jaketollette@gmail.com",
  "token": "eyJhbGciOiJIUz...21DpUPTcOeIt8"
}
```
##### Error Response
###### Invalid Credentials
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Auth.InvalidCredentials": [
      "Invalid credentials"
    ]
  },
  "traceId": "00-c6d2081d5d0c9258e88d01aa16f34c8a-6bc878d2dde87ed7-00"
}
```
###### Invalid
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Password": [
      "'Password' must not be empty."
    ]
  },
  "traceId": "00-654380168bada6aaaf15d8ccc83be0b9-657fa2d30f3e26b7-00"
}
```

## Menus

### Create Menu

```js
POST /hosts/{hostId}/menus
```
#### Request
```json
{
  "name": "Yummy Menu",
  "description": "A delicious menu",
  "sections": [
    {
      "name": "Appetizers",
      "description": "Start your meal off right",
      "items": [
        {
          "name": "Cheese Sticks",
          "description": "Fried cheese sticks"
        }
      ]
    }
  ]
}
```
#### Response
```json
{
  "id": "314d4d3e-51fa-49eb-8ece-6a7db283a3b7",
  "name": "Yummy Menu",
  "description": "A delicious menu",
  "averateRating": 0,
  "sections": [
    {
      "id": "d80d04d2-b6be-4af2-93c3-5a8fe172ad68",
      "name": "Appetizers",
      "description": "Start your meal off right",
      "items": [
        {
          "id": "77844346-f01c-47ed-8bff-fe9ae09a46a8",
          "name": "Cheese Sticks",
          "description": "Fried cheese sticks"
        }
      ]
    }
  ],
  "hostId": "asdfs",
  "dinnerIds": [
    "c25f3e39-26c5-4e2d-bc63-cccaae94db30"
  ],
  "menuReviewIds": [
    "ded4549d-5369-48de-9975-40c9ea407f2a"
  ],
  "createdDateTime": "2024-11-29T17:26:23.7763583Z",
  "updatedDateTime": "2024-11-29T17:26:23.7763589Z"
}
```