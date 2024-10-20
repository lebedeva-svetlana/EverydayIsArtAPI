# EverydayIsArtAPI
 
[![.NET Version](https://img.shields.io/badge/Version-.NET_Core_8.0-blue.svg)]([https://shields.io/](https://dotnet.microsoft.com/)) [![License](https://img.shields.io/badge/License-GPL_3.0-green.svg)]([https://shields.io/](https://github.com/lebedeva-svetlana/NameGeneratorLib/blob/main/LICENSE.md)) [![UI Language](https://img.shields.io/badge/UI_Language-EN-yellow.svg)]([https://shields.io/])

## Overview
EverydayIsArtAPI provides access to museum exhibits.

## Endpoints

### Random exhibit

- `GET /all` returns exhibit from all organizations.
- `GET /tretyakov` returns exhibit from the State Tretyakov Gallery.
- `GET /vam` returns exhibit from Victoria and Albert Museum.
- `GET /metmuseum` returns exhibit from the Metropolitan Museum of Art.

#### Example

##### Request

`*/metmuseum`

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
