The following **Packages** are required. 

|  **Package** | **Version** |
| ----------- | ----------- |
| Microsoft.AspNetCore.Authentication      | 6.0.14* |
| Microsoft.IdentityModel.Tokens   | 6.27.0 |
| Swashbuckle.AspNetCore | 6.5.0 |
|System.IdentityModel.Tokens.Jwt | 6.27.9 |

<br />

**At the time of making this latest versions of **Microsoft.AspNetCore.Authentication** only supports .NET Core 7 and above so it is crucial that the package version is not newer than **6.0.14***

---
<br />

## Authenticator Instructions

<br />

In order to enable authentication the comment on line 13 inside **CovidController.cs** must be removed.

Authentication requires a Bearer token in order to get it one must send a **POST** request
1. Open Postman software
2. Create a new request and in said request select POST and write https://localhost:[PORT]/login as the destination
3. Inside the tab Body one must write the username and password in JSON format 
4. Click Send
5. Inside the body a token will be generated

<br />

In order to get a response back one must send a **GET** request

1. Inside Postman select the option Get
2. Write the destination API
3. Under the Authorization tab select Type **Bearer Token** and paste the token
4. Click Send
5. Result will be generated inside the body

<br />

Example of the API api/region/cases: https://localhost:7088/api/region/cases?region=LJ&startDate=2020-05-20&endDate=2021-05-20

Here is a destination example for both APIs
Example of the API api/region/lastweek: https://localhost:7088/api/region/lastweek

<br />

*A pre-generated Token is included inside token.txt, however, if the token has expired one must send a **POST** Body JSON of the included login credentials.*
<br />
<br />
<br />

## Endpoint api/region/cases

<br />

In order to use the endpoint api/region/cases one must fill the following filters:

- Region (only the following entries will generate a result LJ, CE, KR, NM, KK, KP, MB, MS, NG, PO, SG, ZA)
- From date (Must use the following format YYYY-MM-DD)
- To date (Must use the following format YYYY-MM-DD)

The result will be in the following format E. G.
<br />
```
        "2020-05-20": {
            "Region": "LJ",
            "ActiveCases": "6",
            "DeceasedToDate": "24",
            "Vaccinated1stToDate": "",
            "Vaccinated2ndToDate": ""
        }
```
<br />
The endpoint give us the date followed by region name, number of active cases, deceased to date, 1st vaccination and 2nd vaccination

<br />
<br />
<br />

## Endpoint api/region/lastweek
<br />
Endpoint api/region/lastweek has no filters so it can be ran directly.
The resault of the api will be in the following format E. G.
<br />
<br />

```
    {
      "regionName": "LJ",
      "avgDailyCases": 69.71428571428571
    }
```
<br />
The endpoint gives us the region name, followed by the average number of cases. It is sorted in descending order.

