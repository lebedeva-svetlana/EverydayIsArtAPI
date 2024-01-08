# EverydayIsArtAPI

EverydayIsArtAPI provides access to museum exhibits.

## Endpoints

### User login

`POST /user/login` returns JWT token.

#### Example

##### Request body

```json
{
  "username": "ExampleName",
  "password": "Example1234!"
}
```

##### Response body

```
"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InRlc3RAbWFpbC5jb20iLCJqdGkiOiJlOWRjMjQyNy1hM2Y2LTQyM2EtYjQ5MS0wMGJmNWE4ZTM2ODkiLCJleHAiOjE3MDQ3MjM2MzQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcwMTUiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUxNzMifQ.ix-fNxo5AfjlbZCRjCNGQq6kmaYpef2W3spbddcML2U"
```

### User registration

`POST /user/register` creates new user and returns JWT token.

#### Example

##### Request body

```json
{
  "username": "ExampleName",
  "email": "example@mail.com",
  "password": "Example1234!"
}
```

##### Response body

```
"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InRlc3RAbWFpbC5jb20iLCJqdGkiOiJlOWRjMjQyNy1hM2Y2LTQyM2EtYjQ5MS0wMGJmNWE4ZTM2ODkiLCJleHAiOjE3MDQ3MjM2MzQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcwMTUiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUxNzMifQ.ix-fNxo5AfjlbZCRjCNGQq6kmaYpef2W3spbddcML2U"
```

### Random exhibit

- `GET /random/all` returns exhibit from all organizations.
- `GET /random/tretyakov` returns exhibit from the State Tretyakov Gallery.
- `GET /random/vam` returns exhibit from Victoria and Albert Museum.
- `GET /random/metmuseum` returns exhibit from the Metropolitan Museum of Art.

#### Example

##### Request

`*/random/metmuseum`

##### Response body

```json
{
  "title": "The Gopis Plead with Krishna to Return Their Clothing: Folio from \"Isarda\" Bhagavata Purana",
  "date": "Ca. 1560–65",
  "author": [
    "Master of the \"Isarda\" Bhagavata Purana"
  ],
  "description": [
    {
      "parts": [
        "North India (Delhi-Agra area)"
      ]
    },
    {
      "parts": [
        "Dimensions: Image: 7 3/8 × 10 1/8 in. (18.7 × 25.7 cm)",
        "Materials: Opaque watercolor and ink on paper",
        "Accession number: 1972.260"
      ]
    },
    {
      "parts": [
        "Gift of The H. Rubin Foundation Inc., 1972"
      ]
    }
  ],
  "imageUrl": "https://images.metmuseum.org/CRDImages/as/original/DP153157.jpg",
  "sourceUrl": "https://www.metmuseum.org/art/collection/search/37962",
  "sourceUrlText": "© The Metropolitan Museum of Art"
}
```

## Credits

Third-party libraries:

- [Html Agility Pack](https://github.com/desandro/masonry](https://github.com/zzzprojects/html-agility-pack)https://github.com/zzzprojects/html-agility-pack) licensed with MIT.
- [Serilog](https://github.com/serilog/serilog-sinks-file) licensed with Apache-2.0 license.

## Terms of use

- [The State Tretyakov Gallery](https://www.tretyakovgallery.ru/about/copirith/)
- [Victoria and Albert Museum](https://www.vam.ac.uk/info/va-websites-terms-conditions)
- [The Metropolitan Museum of Art](https://www.metmuseum.org/policies/terms-and-conditions)
