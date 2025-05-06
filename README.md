# Formula-API

Formula-API is an API to get full instructions on how to make a medicine.

## Installation

1. clone this repository

```bash
git clone https://github.com/nadulang/formula-API.git
```
```bash
cd formula-API
```

2. input the configuration of the connection string in appsettings.Development.json. the password will be given to you by the author.
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=...;Port=...;Database=...;Username=...;Password=..."
  }
}
```

3. run the app
```bash
dotnet run
```

4. open the browser to access the swagger UI
```bash
https://localhost:7092/swagger/index.html
```

## License

[MIT](https://choosealicense.com/licenses/mit/)