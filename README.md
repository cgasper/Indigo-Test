The following **Packages** are required. 


|  **Package** | **Version** |
| ----------- | ----------- |
| Microsoft.AspNetCore.Authentication      | 6.0.14* |
| Microsoft.IdentityModel.Tokens   | 6.27.0 |
| Swashbuckle.AspNetCore | 6.5.0 |
|System.IdentityModel.Tokens.Jwt | 6.27.9 |


*At the time of making this latest versions of **Microsoft.AspNetCore.Authentication** only supports .NET Core 7 and above so it is crucial that the package version is not newer than **6.0.14**

If one wishes to use authentication the comment on line **13** inside **CovidController.cs** must be removed.
Authentication works using **Postman** software, by sending a Bearer token to the api of choice by using the **GET** option.

E. G. sending a GET request with the Bearer token to the https://localhost:[PORT]/api/region/lastweek will output the data from *api/region/lastweek*

Token is included inside token.txt, however, if the token has expired one must send a **POST** Body JSON of the included login credentials.

In the API/region/cases both the region and From - To date filters are required to be entered.