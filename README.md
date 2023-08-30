# Generative AI Research Use Case #1
### Overview
***GenerativeAIResearch*** is an application capable of requesting data from a third party API and operating on that data. The features are sorting, filtering, ordering and pagination of said data which is done in memory after data is received from the third party API.


`'GenerativeAIResearch.API'`  - responsible receiving client request for operating with data.
`'GenerativeAIResearch.Application'` - responsible for application logic for sorting, filtering etc. 
`'GenerativeAIResearch.UnitTests'` - responsible for unit testing the application logic.


### Build and Run
Prerequisites for running and/or developing the application is to have a `dotnet 6` sdk or runtime installed.
You can run the application by navigating to the project's root folder after cloning the repository and running `'dotnet run --project src/GenerativeAIResearch.API/GenerativeAIResearch.API.csproj'` 

### Examples

Example requests
|     Description           |URL|Result|
|----------------|-------------------------------|-----------------------------|
|No parameters|`'GET https://localhost:<port>/Countries'`|'Isn't this fun?'            |
|Filter by name|`GET https://localhost:<port>/Countries?filterByName=es`|All countries that contains "es" in their name|
|Filter by population (millions)|`GET https://localhost:<port>/Countries?filterByPopulation=12`|All countries with population less than 12 million|
|Order ascending |`GET https://localhost:<port>/Countries?sortOrder=ascend`|Ordered by country name in ascending order|
|Order descending |`GET https://localhost:<port>/Countries?sortOrder=descend`|Ordered by country name in descending order|
|Limit results to 12|`GET https://localhost:<port>/Countries?limit=12`|12 results in no particular order|
|Filter by name and take 12 results|`GET https://localhost:<port>/Countries?filterByName=es&limit=12`|12 results for countries that contain "es" in their name|
|Filter by name, order in descending order and take 10 results|`GET https://localhost:<port>/Countries?filterByName=es&sortOrder=descend&limit=10`|10 results for countries that contain "es" ordered in descending order.|
|Filter by population and take 10 results|`GET https://localhost:<port>/Countries?filterByPopulation=12&limit=10`|10 results for countries with population under 10 million|
|Filter by name, population, sort in ascending order by name and display 10 results|`GET https://localhost:<port>/Countries?filterByName=es&filterByPopulation=12&sortOrder=ascend&limit=10`|10 results for countries with population under 12 million ordered by ascending order by name|

