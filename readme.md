# Ship demo project

It's a project developed by using .net 6 and react. 

---

# Features

- Clean architecture
- Logging: not completed
- Validation: FluentValidation
- Test: not completed
---
To run project
1. docker build --pull --rm -f Dockerfile -t ship:latest .
2. dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p 123456   
3. dotnet dev-certs https --trust 
4. docker run --rm -it  -p 443:443/tcp -p 44335:44335/tcp -e ASPNETCORE_URLS="https://+;http://+" -e 5.ASPNETCORE_Kestrel__Certificates__Default__Password="123456" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v %USERPROFILE%\.aspnet\https:/https/   ship:latest
5. navigate to https://localhost:443