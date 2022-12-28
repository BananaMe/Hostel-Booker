# Hostel Booker

This is an application based on the concept of booking 
rooms and storing room details. Made using Asp .NET Core 7 and SolidJS typescript.

**It is not fully functioning with some missing CRUD operations and a responsive frontend.**

The app  can perform some tasks like:
* **Hostels:** add hostels, update hostels (by changing the name of the hostel) read a specific hostel (returns the name) or all registered hostels, delete specific hostel (by entering the id of the hostel);
* **Rooms:** add rooms, updating rooms (WIP), read available rooms (returns registered rooms in a hostel that are available on the specified date range - WIP), delete specific room (by entering the room id and the hostel id the room belongs to);
* **Guest:** add a guest (by entering the guest's name), read a specific guest (by entering their id) or all registered guests, delete specific guest ( by entering their id).


## Tech

- SolidJS - frontend
- ASP .NET Core 7 Entity Framework - backend
- Swagger - Documentation for HTTP Requests

## Installation Guide

### Prerequisites
- .NET Core 7 SDK
- Visual Studio (optional, but recommended)
### Clone the repository
Clone the repository onto your machine using the following command:

```bash
git clone https://github.com/<BananaMe>/<Hostel-Booker>.git
```
### Install dependencies
Navigate to the root directory of the repository and run the following command to install the necessary dependencies:

```bash
dotnet restore
npm install # in the frontend directory
```

### Build and run the project
Use the following commands to build and run the project:

```bash
dotnet build
dotnet run
npm start # in the frontend directory
```
The project will be available at http://localhost:3000
<br />
To see the Swagger build go to http://localhost:5018/swagger/index.html
