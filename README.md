# CrudDemoD1
This is application is a simple CRUD of Customers, using .NET Framework 5 and MongoDB.

## Before Use It, Make Sure Of:
- Having .Net Framework 5 Installed
- MongoDB Installed

## Getting Started

1-> Clone the repositor into your local workspace

## Running The Application
### Packages
 - You will need to download 3 packages:
   1. MongoDB.Bson
   2. MongoDB.Driver
   3. Swashbuckle.AspNetCore

### API Path
The API use the path `https://localhost:44322´

| Verb | Resource | Description |
|------|----------|-------------|
| Get  |/api/customer | Show all customers |
| Get  |/api/customer/{name}          | Show an specific customer|

| Verb | Resource | Description |
|------|----------|-------------|
| Post  |/api/customer/{name} | Register a new customer          |

| Verb | Resource | Description |
|------|----------|-------------|
| Patch  |/api/customer/{name}/{cpf} | Update an existing customer|

| Verb | Resource | Description |
|------|----------|-------------|
| Delete  |/api/customer/{name}/{cpf} | Delete a customer         |




